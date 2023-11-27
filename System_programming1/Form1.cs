using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace System_programming1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            foreach (Process process in Process.GetProcesses())
            {
                ListViewItem item = new ListViewItem(process.ProcessName);
                item.SubItems.Add(process.Id.ToString());
                item.SubItems.Add(process.Threads.Count.ToString());
                item.SubItems.Add(process.HandleCount.ToString());

                listView1.Items.Add(item);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            timer1.Interval = (5 * 1000);
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1_Tick(sender, e);
            var processes = new List<ProcessInfo>();

            foreach (ListViewItem item in listView1.Items)
            {
                processes.Add(new ProcessInfo
                {
                    ProcessName = item.SubItems[0].Text,
                    Id = int.Parse(item.SubItems[1].Text),
                    ThreadCount = int.Parse(item.SubItems[2].Text),
                    HandleCount = int.Parse(item.SubItems[3].Text)
                });
            }

            string json = JsonConvert.SerializeObject(processes, Formatting.Indented);

            File.WriteAllText("processes.json", json);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Ping
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Ping();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void Ping()
        {
            Process p = new Process();

            // #tells operating system not to use a shell;
            p.StartInfo.UseShellExecute = false;

            //#need this false to capture results in stdout

            //#allow me to capture stdout, i.e. results
            p.StartInfo.RedirectStandardOutput = true;

            //#my command arguments, i.e. what site to ping
            p.StartInfo.Arguments = textBox1.Text;

            //#the command to invoke under MSDOS
            p.StartInfo.FileName = @"c:\Windows\System32\ping";

            //#do not show MSDOS window
            p.StartInfo.CreateNoWindow = true;

            //#do it!
            p.Start();

            //#capture results
            string output = p.StandardOutput.ReadToEnd();

            //#wait for all results.
            p.WaitForExit();

            //#show results.
            MessageBox.Show(output.ToString(), "result");

        }

    }
}
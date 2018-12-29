using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace hw1
{
    public partial class Find : Form
    {
        public Find()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            notepad.f.Close();
        }
        public static int m;
        public static string d;
        public static TextBox t;
        public void button1_Click(object sender, EventArgs e)
        {
            int i;
            t = textBox1;
            d = textBox1.Text;
            if (m == notepad.rt.Text.Length)
            {
                MessageBox.Show("Cannot find", "notepad", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            }
            if (checkBox1.Checked)
            {
                i = notepad.rt.Find(textBox1.Text,m,notepad .rt .Text .Length , RichTextBoxFinds.MatchCase);
            }
            else
            {
                i = notepad.rt.Find(textBox1.Text,m,notepad .rt.Text .Length ,RichTextBoxFinds.None);
            }
            if (i < 0)
           {
             MessageBox.Show("Cannot find","notepad", MessageBoxButtons.OK, MessageBoxIcon.Information,MessageBoxDefaultButton.Button1 );
           }
           else
           {
             notepad.rt.Focus();
             m = i + textBox1.Text.Length;
           }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                button1.Enabled = true;
            }
        }

        private void Find_Load(object sender, EventArgs e)
        {
            textBox1.Text = d;
        }
    }
}

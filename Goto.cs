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
    public partial class Goto : Form
    {
        public Goto()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || e.KeyChar == 8)
                e.Handled = false;
            else
                e.Handled = true;
            MessageBox.Show("You can only type a number here", "Unacceptable Character", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            notepad.g.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int k = notepad.rt.GetLineFromCharIndex(notepad.rt.SelectionStart);
            if (int.Parse(textBox1.Text) > k)
            {
                textBox1.Text = k.ToString();
                MessageBox.Show("The line number is beyond the total number of lines", "Notepad-Goto Line", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
            }
            else
            {
                int i = notepad.rt.GetFirstCharIndexFromLine(int.Parse(textBox1.Text) - 1);
                notepad.rt.SelectionStart = i;
                notepad.rt.Focus();
            }
        }

        private void Goto_Load(object sender, EventArgs e)
        {
            int k= notepad.rt.GetLineFromCharIndex (notepad .rt.SelectionStart );
            k++;
            textBox1.Text = k.ToString();
        }
    }
}

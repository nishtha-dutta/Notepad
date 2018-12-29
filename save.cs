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
    public partial class save : Form
    {
        public save()
        {
            InitializeComponent();
        }        
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            hw1.notepad.f1.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Rich text file|*.rtf|Text File|*.txt|All Files|*.*";
            saveFileDialog1.ShowDialog();
            hw1.notepad .rt.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
            this.Close();
        }
    }
}

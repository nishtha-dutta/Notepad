using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using hw1;

namespace hw1
{
    public partial class notepad : Form
    {
        public notepad()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Modified)
            {
                DialogResult rs = MessageBox.Show("Do you want to save changes to Untitled?", "Notepad", MessageBoxButtons.YesNoCancel, MessageBoxIcon.None , MessageBoxDefaultButton.Button1);
                if (rs == DialogResult .Yes)
                {
                    saveAsToolStripMenuItem.PerformClick();
                    richTextBox1.Clear();
                    currentfile = null;
                    this.Text = "Untitled - Notepad";
                }
                if (rs == DialogResult.No)
                {
                    richTextBox1.Clear();
                    currentfile = null;
                    this.Text = "Untitled - Notepad";
                }
                if (rs == DialogResult.Cancel)
                {
                }
            }
                else 
                {
                    richTextBox1.Clear();
                    currentfile = null;
                    this.Text = "Untitled - Notepad";
                }
            }
        
        string currentfile;
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
            string fn = Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
            currentfile = openFileDialog1.FileName;
            this.Text = fn + " - Notepad";
            richTextBox1.Modified = false;
        }
        public static Form f1;
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentfile))
            {
                saveAsToolStripMenuItem.PerformClick();
            }
            else
            {
                richTextBox1.SaveFile(currentfile, RichTextBoxStreamType.PlainText);
                richTextBox1.Modified = false;
            }
        }

        public void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Rich text file|*.rtf|Text File|*.txt|All Files|*.*";
            saveFileDialog1.ShowDialog();
            richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
            string fn = Path.GetFileNameWithoutExtension(saveFileDialog1.FileName);
            this.Text = fn + " - Notepad";
            currentfile = saveFileDialog1.FileName;
            richTextBox1.Modified = false;
        }

        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusBarToolStripMenuItem.Checked = statusStrip1 .Visible = !statusStrip1 .Visible;
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            wordWrapToolStripMenuItem.Checked = richTextBox1.WordWrap = !richTextBox1.WordWrap;
            if (richTextBox1.WordWrap)
            {
                statusStrip1.Visible = false;
                statusBarToolStripMenuItem.Enabled = false;
            }
            else
            {
                statusBarToolStripMenuItem.Enabled = true;
                if (statusBarToolStripMenuItem.Checked)
                    statusStrip1.Visible = true;
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionFont = fontDialog1.Font;
            }
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionColor = colorDialog1.Color;
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }
        private void editToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            pasteToolStripMenuItem .Enabled =richTextBox1 .CanPaste (DataFormats.GetFormat (DataFormats .Text ));
            copyToolStripMenuItem.Enabled = cutToolStripMenuItem.Enabled =deleteToolStripMenuItem .Enabled = richTextBox1.SelectedText.Length > 0;
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
            Clipboard.Clear();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            f1 = this;
            this.Text = "Untitled - Notepad";
            pageSetupToolStripMenuItem.Enabled = false;
            notifyIcon1.ShowBalloonTip(3000);
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
        }

        private void pageSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //pageSetupDialog1.ShowDialog();
        }

        private void cutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cutToolStripMenuItem.PerformClick();
        }

        private void copyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            copyToolStripMenuItem.PerformClick();
        }

        private void pasteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            pasteToolStripMenuItem.PerformClick();
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            deleteToolStripMenuItem.PerformClick();
        }

        private void selectAllToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            selectAllToolStripMenuItem.PerformClick();
        }

        private void rToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Clipboard.Clear();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = string.Empty;
            toolStripStatusLabel2.Text = string.Empty;
            int ss = richTextBox1.SelectionStart;
            int l = richTextBox1.GetLineFromCharIndex(ss);
            toolStripStatusLabel1.Text = "Ln " + (l+1);
            int cl = richTextBox1.GetFirstCharIndexFromLine(l);
            int col = ss - cl;
            toolStripStatusLabel2.Text = "col " + (col+1); 
        }

        private void undoToolStripMenuItem1_DropDownOpening(object sender, EventArgs e)
        {
            pasteToolStripMenuItem1.Enabled = richTextBox1.CanPaste(DataFormats.GetFormat(DataFormats.Text));
            copyToolStripMenuItem1.Enabled = cutToolStripMenuItem1.Enabled = deleteToolStripMenuItem1.Enabled = richTextBox1.SelectedText.Length > 0;
        }
        DialogResult rs=0 ;
        public static save s;
        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (s == null)
            {
                if (richTextBox1.Modified)
                {
                    if (rs == 0)
                    {
                        e.Cancel = true;
                        s = new save();
                        s.Show();
                    }
                }
                else
                {
                    Application.Exit();
                }
            }
            else
            {
                Application.Exit();
            }

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void timeDateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text += DateTime.Now;
        }
        public static AboutBox1 obj;
        private void aboutNotepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            obj = new AboutBox1();
            obj.Show();
        }
        public static RichTextBox rt = new RichTextBox();
        public static Find f = new Find();
        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rt = richTextBox1;
            f = new Find();
            f.Show();
        }
        int i;
        private void findNextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rt = richTextBox1;
            if (Find.t==null)
            {
                f.Show();
            }
            else
            {
                i = richTextBox1.Find(Find .d ,Find .m, richTextBox1 . Text.Length, RichTextBoxFinds.None);
                if (i < 0)
                {
                    MessageBox.Show("Cannot find", "notepad", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    Find . m = i + Find.d.Length;
                }
                
            }

        }
        public static Replace r;
        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rt = richTextBox1;
            r = new Replace();
            r.Show();
        }
        public static Goto g;
        private void gotoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rt = richTextBox1;
            g = new Goto();
            g.Show();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (richTextBox1.CanUndo)
            {
                richTextBox1.Undo();
            }
        }

        private void undoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.CanUndo)
            {
                richTextBox1.Undo();
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {

        }

        private void maximizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void normlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
        }

        private void minimizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            Process.Start("http:\\microsoft.com");
        }

        private void notifyIcon1_BalloonTipShown(object sender, EventArgs e)
        {
            //notifyIcon1.ShowBalloonTip(3000);
        }

        //private void InitializeComponent()
        //{
        //    this.SuspendLayout();
        //    // 
        //    // notepad
        //    // 
        //    this.ClientSize = new System.Drawing.Size(284, 262);
        //    this.Name = "notepad";
        //    this.Load += new System.EventHandler(this.notepad_Load);
        //    this.ResumeLayout(false);

        //}

        private void notepad_Load(object sender, EventArgs e)
        {

        }

        //private void InitializeComponent()
        //{
        //    this.SuspendLayout();
        //    // 
        //    // notepad
        //    // 
        //    this.ClientSize = new System.Drawing.Size(412, 334);
        //    this.Name = "notepad";
        //    this.ResumeLayout(false);

        //}
    }
}

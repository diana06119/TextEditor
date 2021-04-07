using System;
using System.Windows.Forms;

namespace TextEditor
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private RichTextBox GetRichTextBox()
        {
            RichTextBox rtb = null;

            if (ActiveMdiChild != null)
            {
                rtb = (RichTextBox) ActiveMdiChild.Controls[0];
            }

            return rtb;
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
                ActiveMdiChild.Close();
        }

        private void tsmiCreate_Click(object sender, EventArgs e)
        {
            FormREB frm = new FormREB {MdiParent = this};
            frm.Show();
        }

        private void tsmiCloseAll_Click(object sender, EventArgs e)
        {
            foreach (Form form in MdiChildren)
            {
                form.Close();
            }
        }

        private void tsmiSave_Click(object sender, EventArgs e)
        {
            if (GetRichTextBox() == null)
                return;

            if (sfd.ShowDialog() == DialogResult.OK && sfd.FileName.Length > 0)
            {
                GetRichTextBox().SaveFile(sfd.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void tsmiOpen_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK && ofd.FileName.Length > 0)
            {
                FormREB frm = new FormREB {MdiParent = this, path = ofd.FileName};
                frm.Show();
            }
        }

        private void tsmiCut_Click(object sender, EventArgs e)
        {
            GetRichTextBox().Cut();
        }

        private void tsmiCopy_Click(object sender, EventArgs e)
        {
            GetRichTextBox().Copy();
        }

        private void tsmiPaste_Click(object sender, EventArgs e)
        {
            GetRichTextBox().Paste();
        }

        private void tsmiSelectAll_Click(object sender, EventArgs e)
        {
            GetRichTextBox().SelectAll();
        }
    }
}

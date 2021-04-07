using System;
using System.Windows.Forms;

namespace TextEditor
{
    public partial class FormREB : Form
    {
        public string path { get; set; }

        public FormREB()
        {
            InitializeComponent();
        }

        private void FormREB_Load(object sender, EventArgs e)
        {
            if (path != null)
                richTextBox1.LoadFile(path, RichTextBoxStreamType.PlainText);
        }
    }
}

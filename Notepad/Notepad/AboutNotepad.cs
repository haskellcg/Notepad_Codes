using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Notepad
{
    public partial class AboutNotepad : Form
    {
        public AboutNotepad()
        {
            InitializeComponent();

            this.Icon = new Icon("AppIco/Word.ico");
            this.StartPosition = FormStartPosition.CenterParent;

            pictureBox.Image = Image.FromFile("AppIco/Word.ico");
        }

        private void AboutNotepad_Load(object sender, EventArgs e)
        {
           
        }
    }
}

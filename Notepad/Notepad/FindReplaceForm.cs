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
    public partial class FindReplaceForm : Form
    {
        public FindReplaceForm(bool isFind)
        {
            this.StartPosition = FormStartPosition.CenterParent;
            InitializeComponent();
            this.isFind = isFind;
           

        }

        private void FindReplaceForm_Load(object sender, EventArgs e)
        {
            if (this.isFind)
            {
                this.ReplaceTxt.Enabled = false;
            }
        }

    }
}

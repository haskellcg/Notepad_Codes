using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Notepad
{
    public class RichTextBoxNotepad:RichTextBox
    {
        private DataGridView data;

        public void BindView(DataGridView dataGV)
        {
            data = dataGV;
        }

        protected override bool ProcessCmdKey(ref Message m, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Down:
                    if (data.Visible == true)
                    {
                        data.Focus();
                        data.Select();
                        return true;
                    }
                    else
                    {
                        return base.ProcessCmdKey(ref m, Keys.Down);
                    }
                    break;
                case Keys.Up:
                    if (data.Visible == true)
                    {
                        data.Focus();
                        data.Select();
                        return true;
                    }
                    else
                    {
                        return base.ProcessCmdKey(ref m, Keys.Up);
                    }
                    break;
                case Keys.Enter:
                    if (data.Visible == true)
                    {
                        data.Visible = false;
                        return true;
                    }
                    else
                    {
                        return base.ProcessCmdKey(ref m, Keys.Enter);
                    }
                    break;
                case Keys.Tab:
                    if (data.Visible == true)
                    {
                        data.Visible = false;
                        return true;
                    }
                    else
                    {
                        return base.ProcessCmdKey(ref m, Keys.Tab);
                    }
                    break;
                case Keys.Space:
                    if (data.Visible == true)
                    {
                        data.Visible = false;
                        return true;
                    }
                    else
                    {
                        return base.ProcessCmdKey(ref m, Keys.Space);
                    }
                    break;
            }
            return base.ProcessCmdKey(ref m, keyData);
        }
    }
}

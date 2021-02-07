using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Notepad
{
    public class DataGridViewNotepad : DataGridView
    {
        private RichTextBox richTB;

        public void BindRichTextBox(RichTextBox richTB)
        {
            this.richTB = richTB;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Enter:
                    int nowIndex = this.richTB.SelectionStart;
                    char nowChar = this.richTB.GetCharFromPosition(this.richTB.GetPositionFromCharIndex(nowIndex));
                    //MessageBox.Show(nowIndex+"::"+nowChar);
                    if ((nowChar >= 'a' && nowChar <= 'z') || (nowChar >= 'A' && nowChar <= 'Z') || (nowChar == '\t') || (nowChar == ' ') || nowChar == '\n')
                    {
                        int wordStartIndex = nowIndex;
                        if ((nowChar == '\t') || (nowChar == ' ') || (nowChar == '\n'))
                        {
                            wordStartIndex--;
                        }
                        char wordStartChar=' ';
                        do
                        {

                            if (wordStartIndex == 0) break;
                            wordStartChar = this.richTB.GetCharFromPosition(this.richTB.GetPositionFromCharIndex(wordStartIndex));
                            //MessageBox.Show(wordStartIndex+":"+wordStartChar);
                            wordStartIndex--;
                        } while (wordStartChar != ' ' && wordStartChar != '\t' && wordStartChar != '\n' && (nowIndex - wordStartIndex) <= 20);

                        if ((nowIndex - wordStartIndex) <= 20)
                        {
                            if ((wordStartIndex != 0) || (wordStartIndex == 0 && wordStartChar == ' '))
                                wordStartIndex += 2;
                           // MessageBox.Show(wordStartIndex+":::"+nowIndex);
                            this.richTB.Select(wordStartIndex, nowIndex - wordStartIndex);
                            //MessageBox.Show(this.richTB.SelectedText);
                            this.richTB.SelectedText = this.SelectedRows[0].Cells[0].Value.ToString();
                            this.richTB.SelectionStart = wordStartIndex+ this.SelectedRows[0].Cells[0].Value.ToString().ToCharArray().Length;
                            //MessageBox.Show("StartPosition"+this.richTB.SelectionStart+"");
                        }
                    }

                    this.Visible = false;
                    this.richTB.Focus();
                    return true;
                case Keys.Space:
                    this.Visible = false;
                    this.richTB.Focus();
                    return true;
                case Keys.Tab:
                    this.Visible = false;
                    this.richTB.Focus();
                    return true;
            }


            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}

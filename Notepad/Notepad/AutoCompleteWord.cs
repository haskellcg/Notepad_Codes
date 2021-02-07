using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Notepad
{
    public partial class AutoCompleteWord : Component
    {
        public AutoCompleteWord()
        {
            InitializeComponent();

            _adapters = new Dictionary<string, IDataAdapter>();
        }

        public void AddListener(RichTextBoxNotepad sender, IDataAdapter adapter)
        {
            this._adapters.Add(sender.Name, adapter);

            this._view.BindRichTextBox(sender);
            sender.BindView(this._view);

            if (_form == null)
            {
                _form = sender;
                while (_form.Parent != null)
                {
                    _form = _form.Parent;
                }
            }


            
            sender.TextChanged+=new EventHandler(sender_TextChanged);
        }
        private void sender_TextChanged(object sender, EventArgs e)
        {
            
            RichTextBox richText = sender as RichTextBox;
            Control container = _form;
            int nowIndex = richText.SelectionStart;
            char nowChar = richText.GetCharFromPosition(richText.GetPositionFromCharIndex(nowIndex));
            //MessageBox.Show(nowIndex+":::"+nowChar);
            if ((nowChar >= 'a' && nowChar <= 'z') || (nowChar >= 'A' && nowChar <= 'Z') || (nowChar == '\t') || (nowChar == ' ') || (nowChar == '\n'))
            {
                int wordStartIndex = nowIndex;
                if ((nowChar == '\t') || (nowChar == ' ') || (nowChar == '\n'))
                    wordStartIndex--;
                string keyString = "";
                char wordStartChar = ' ';
                do
                {

                    if (wordStartIndex == 0) break;
                    wordStartChar = richText.GetCharFromPosition(richText.GetPositionFromCharIndex(wordStartIndex));
                    //MessageBox.Show(wordStartIndex + "::" + wordStartChar);
                    wordStartIndex--;
                } while (wordStartChar != ' ' && wordStartChar != '\t' && wordStartChar != '\n' && (nowIndex - wordStartIndex) <= 20);

                //MessageBox.Show("LastWord:"+wordStartIndex);
                if ((nowIndex - wordStartIndex) <= 20)
                {
                    if ((wordStartIndex != 0) || (wordStartIndex == 0 && wordStartChar == ' '))
                        wordStartIndex += 2;
                    if (wordStartIndex > nowIndex)
                    {
                        _view.Visible = false;
                        return;
                    }
                    richText.Select(wordStartIndex, nowIndex - wordStartIndex);
                    keyString = richText.SelectedText;
                    //MessageBox.Show(keyString);
                    richText.Select(nowIndex, 0);
                }
                else
                {
                    _view.Visible = false;
                    return;
                }

                if (keyString.Equals(""))
                {
                    _view.Visible = false;
                    return;
                }
                _view.DataSource = _adapters[richText.Name].GetFitData(keyString);
                Point editPoint = richText.GetPositionFromCharIndex(richText.SelectionStart);
                _view.Location = new Point(editPoint.X, editPoint.Y + 30 + (int)(richText.Font.Height * richText.ZoomFactor));
                _view.Visible = true;
                container.Controls.Add(_view);
                _view.BringToFront();
                int tableCount = _adapters[richText.Name].GetFitData(keyString).Count;
                if (tableCount == 0)
                {
                    _view.Visible = false;
                }
                else if (tableCount <= viewDisplayNumber)
                {
                    _view.Height = _view.Rows[0].Height * tableCount;
                }
                else
                {
                    _view.Height = _view.Rows[0].Height * viewDisplayNumber;
                }
            }
            else
            {
                _view.Visible = false;
                richText.Focus();
            }
        }

        public void SetVisible(bool visible)
        {
            _view.Visible = visible;
        }

        private void _view_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            string Dic = System.Configuration.ConfigurationManager.AppSettings["Dic"];
            DataTableFromFile data = new DataTableFromFile(Dic);
            data.GetDataTable("Word");
            Dictionary<string, string> wordDictionary = data.WordDictionary;
            string translate = wordDictionary[_view.Rows[e.RowIndex].Cells[0].Value.ToString()];
            string toolTip = "\n\t单词:" + _view.Rows[e.RowIndex].Cells[0].Value.ToString() + "\t\n\n\t" +
                         "解释:"+translate+"\t";
            e.ToolTipText = toolTip;
        }

        private void _view_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            SendKeys.Send("{Enter}");
        }
        

    }
}

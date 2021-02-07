using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace Notepad
{
    public partial class Notepad : Form
    {
        

        public Notepad()
        {
            InitializeComponent();

            this.Icon = new Icon("AppIco/Word.ico");

            this.SetNotifyIconAttr(this.notifyIcon, "AppIco/Word.ico", "提示", "记事本程序正在运行", ToolTipIcon.Info);

            this.SetToolTipAttr(this.toolTip, true, 1000, 20000, 2000, Color.LightYellow, Color.Salmon, true, ToolTipIcon.Info, "提示", true, true);

            

            this.statusBar = new StatusBar();
            this.statusPanelCheck = new StatusBarPanel();
            this.statusPanelSystem = new StatusBarPanel();
            this.statusPanelTime = new StatusBarPanel();
            this.statusPanelFile = new StatusBarPanel();
            this.statusPanelLinenum = new StatusBarPanel();

            this.statusPanelCheck.ToolTipText = "英语单词检查状态";
            this.statusPanelCheck.BorderStyle = StatusBarPanelBorderStyle.Sunken;
            this.statusPanelCheck.Text = "正常";
            this.statusPanelCheck.Icon = new Icon("AppIco/Check.ico");
            this.statusPanelCheck.AutoSize = StatusBarPanelAutoSize.Spring;

            this.statusPanelSystem.ToolTipText = "程序现在状态";
            this.statusPanelSystem.BorderStyle = StatusBarPanelBorderStyle.Sunken;
            this.statusPanelSystem.Text = "就绪";
            this.statusPanelSystem.Icon = new Icon("AppIco/Editable.ico");
            this.statusPanelSystem.AutoSize = StatusBarPanelAutoSize.Spring;

            this.statusPanelTime.ToolTipText = "现在时间";
            this.statusPanelTime.BorderStyle = StatusBarPanelBorderStyle.Sunken;
            this.statusPanelTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            this.statusPanelTime.AutoSize = StatusBarPanelAutoSize.Spring;
            this.statusPanelTime.Icon = new Icon("AppIco/Time.ico");

            this.statusPanelFile.ToolTipText = "现在打开的文件";
            this.statusPanelFile.BorderStyle = StatusBarPanelBorderStyle.Sunken;
            this.statusPanelFile.Text = "文件:";
            this.statusPanelFile.Icon = new Icon("AppIco/FilePath.ico");
            this.statusPanelFile.AutoSize = StatusBarPanelAutoSize.Spring;

            this.statusPanelLinenum.ToolTipText = "此时编辑的位置";
            this.statusPanelLinenum.BorderStyle = StatusBarPanelBorderStyle.Sunken;
            this.statusPanelLinenum.Text = "第1行     第1列";
            this.statusPanelLinenum.Icon = new Icon("AppIco/LineNum.ico");
            this.statusPanelLinenum.AutoSize = StatusBarPanelAutoSize.Spring;

            this.statusBar.ShowPanels = true;
            this.statusBar.Panels.Add(this.statusPanelCheck);
            this.statusBar.Panels.Add(this.statusPanelSystem);
            this.statusBar.Panels.Add(this.statusPanelTime);
            this.statusBar.Panels.Add(this.statusPanelFile);
            this.statusBar.Panels.Add(this.statusPanelLinenum);
            this.statusBar.MouseClick +=new MouseEventHandler(statusBar_MouseClick);
            this.Controls.Add(this.statusBar);

            this.progress = new ProgressBarForm(this);

            this.StartPosition = FormStartPosition.CenterScreen;

            string Dic = System.Configuration.ConfigurationManager.AppSettings["Dic"];
            DataViewAdapter adapter = new DataViewAdapter(new DataTableFromFile(Dic).GetDataTable("Word"));
            adapter.KeyWord = "Word";
            autoCompleteWord.AddListener(ContentTxt,adapter);

            this.searchPosition = 0;
            this.searchString = "";
            this.isFind = false;
            this.isNew = true;
            this.savedFileName = "";
            this.savedTitle = "Notepad";
            this.newTitle = " * Notepad";


            this.checkTree = new TrieTree();
            this.checkTree.BuildTree();
            
        }

        private void Notepad_Load(object sender, EventArgs e)
        {

            //开始显示进程图标
            this.notifyIcon.Visible = true;
            this.notifyIcon.ShowBalloonTip(1);


            if (this.statusBar.Visible)
                this.StatusBarStripItem.Image = Image.FromFile("AppIco/Selected.ico");


            
        }

        #region  控件初始化函数
        /// <summary>
        /// 设置Notify的图标
        /// </summary>
        /// <param name="fileName">icon的文件位置</param>
        /// <param name="title">标题</param>
        /// <param name="text">内容</param>
        /// <param name="icon">提示栏的系统图标</param>
        /// <param name="notifyIcon">需要设置的控件</param>
        private void SetNotifyIconAttr(NotifyIcon notifyIcon, string fileName, string title, string text, ToolTipIcon icon)
        {
            notifyIcon.Icon = new Icon(fileName);
            notifyIcon.BalloonTipTitle = title;
            notifyIcon.BalloonTipText = text;
            notifyIcon.BalloonTipIcon = icon;
        }

        /// <summary>
        /// 设置ToolTip的属性
        /// </summary>
        /// <param name="toolTip">需要设置的控件</param>
        /// <param name="active">是否可以使用</param>
        /// <param name="initTime">初始化事件，即鼠标停留的时间</param>
        /// <param name="popDelay">弹出后的停留时间</param>
        /// <param name="reshowTime">再一次弹出的事件间隔</param>
        /// <param name="backColor">背景色</param>
        /// <param name="foreColor">前景色</param>
        /// <param name="isBalloon">是否为气球状</param>
        /// <param name="icon">显示的系统图标</param>
        /// <param name="title">标题</param>
        /// <param name="useAnimation">是否使用动画</param>
        /// <param name="useFade">是否使用淡入淡出</param>
        private void SetToolTipAttr(ToolTip toolTip, bool active, int initTime, int popDelay, int reshowTime, Color backColor, Color foreColor, bool isBalloon, ToolTipIcon icon, string title, bool useAnimation, bool useFade)
        {
            toolTip.Active = active;
            toolTip.InitialDelay = initTime;
            toolTip.AutoPopDelay = popDelay;
            toolTip.ReshowDelay = reshowTime;
            toolTip.BackColor = backColor;
            toolTip.ForeColor = foreColor;
            toolTip.IsBalloon = isBalloon;
            toolTip.ToolTipIcon = icon;
            toolTip.ToolTipTitle = title;
            toolTip.UseAnimation = useAnimation;
            toolTip.UseFading = useFade;
        }

        #endregion

        #region  窗口命令处理函数

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FormWindowState nowState = this.WindowState;
            if (nowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void NewFileStripItem_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(this.ContentTxt.Text) && this.isNew) || (this.isNew && !this.savedFileName.Equals("")))
            {
                DialogResult result = MessageBox.Show("当前文件未保存，是否保存文件", "提示", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    if (this.isNew && !this.savedFileName.Equals(""))
                    {
                        this.ContentTxt.SaveFile(this.savedFileName, RichTextBoxStreamType.PlainText);
                        this.Text = this.savedTitle;
                        this.isNew = false;
                    }
                    else if (this.isNew)
                    {
                        string fileFullName = this.SaveFile("保存文件");
                        if (fileFullName != null)
                        {
                            this.Text = this.savedTitle;
                            this.statusPanelFile.Text = "文件:" + fileFullName;
                            this.isNew = false;
                            this.savedFileName = fileFullName;
                        }
                    }

                    this.ContentTxt.Clear();
                    this.statusPanelFile.Text = "文件:";
                    this.isNew = true;

                }
                else if (result == DialogResult.No)
                {
                    this.ContentTxt.Clear();
                    this.statusPanelFile.Text = "文件:";
                    this.isNew = true;
                }
                else if (result == DialogResult.Cancel)
                {

                }
            }
            else
            {
                this.ContentTxt.Clear();
                this.statusPanelFile.Text = "文件:";
                this.isNew = true;
            }
        }

        private void OpenFileStripItem_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(this.ContentTxt.Text) && this.isNew) || (this.isNew && !this.savedFileName.Equals("")))
            {
                DialogResult result = MessageBox.Show("当前文件未保存，是否保存文件", "提示", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    if (this.isNew && !this.savedFileName.Equals(""))
                    {
                        this.ContentTxt.SaveFile(this.savedFileName, RichTextBoxStreamType.PlainText);
                        this.Text = this.savedTitle;
                        this.isNew = false;
                    }
                    else if (this.isNew)
                    {
                        string fileFullName = this.SaveFile("保存文件");
                        if (fileFullName != null)
                        {
                            this.Text = this.savedTitle;
                            this.statusPanelFile.Text = "文件:" + fileFullName;
                            this.isNew = false;
                            this.savedFileName = fileFullName;
                        }
                    }

                    string loadFileName = this.OpenFile();
                    if (loadFileName != null)
                    {
                        this.Text = this.savedTitle;
                        this.statusPanelFile.Text = loadFileName;
                        this.isNew = false;
                        this.savedFileName = loadFileName;
                    }
                    this.ContentTxt.SelectionStart = 0;
                }
                else if (result == DialogResult.No)
                {
                    string loadFileName = this.OpenFile();
                    if (loadFileName != null)
                    {
                        this.Text = this.savedTitle;
                        this.statusPanelFile.Text = loadFileName;
                        this.isNew = false;
                        this.savedFileName = loadFileName;
                    }
                    this.ContentTxt.SelectionStart = 0;
                }
                else if (result == DialogResult.Cancel)
                {

                }

            }
            else
            {
                string loadFileName = this.OpenFile();
                if (loadFileName != null)
                {
                    this.Text = this.savedTitle;
                    this.statusPanelFile.Text = loadFileName;
                    this.isNew = false;
                    this.savedFileName = loadFileName;
                }
                this.ContentTxt.SelectionStart = 0;
            }
        }

        private void SaveFileStripItem_Click(object sender, EventArgs e)
        {
            if (this.isNew && !this.savedFileName.Equals(""))
            {
                this.ContentTxt.SaveFile(this.savedFileName,RichTextBoxStreamType.PlainText);
                this.Text = this.savedTitle;
                this.isNew = false;
            }
            else if (this.isNew && !string.IsNullOrEmpty(this.ContentTxt.Text))
            {
                string fileFullName=this.SaveFile("保存文件");
                if (fileFullName != null)
                {
                    this.Text = this.savedTitle;
                    this.statusPanelFile.Text = "文件:" + fileFullName;
                    this.isNew = false;
                    this.savedFileName = fileFullName;
                }
            }

            
        }

        private void ReSaveFileStripItem_Click(object sender, EventArgs e)
        {
            string fileFullName = this.SaveFile("另存为");
            if (fileFullName != null)
            {
                this.Text = this.savedTitle;
                this.statusPanelFile.Text = "文件:" + fileFullName;
                this.isNew = false;
                this.savedFileName = fileFullName;
            }
        }

        private void ExitStripItem_Click(object sender, EventArgs e)
        {
            //if ((!string.IsNullOrEmpty(this.ContentTxt.Text) && this.isNew) || (this.isNew && !this.savedFileName.Equals("")))
            //{
            //    DialogResult result = MessageBox.Show("当前文件未保存，是否保存文件", "提示", MessageBoxButtons.YesNoCancel);
            //    if (result == DialogResult.Yes)
            //    {
            //        if (this.isNew && !this.savedFileName.Equals(""))
            //        {
            //            this.ContentTxt.SaveFile(this.savedFileName, RichTextBoxStreamType.PlainText);
            //            this.Text = this.savedTitle;
            //            this.isNew = false;
            //        }
            //        else if (this.isNew)
            //        {
            //            string fileFullName = this.SaveFile("保存文件");
            //            if (fileFullName != null)
            //            {
            //                this.Text = this.savedTitle;
            //                this.statusPanelFile.Text = "文件:" + fileFullName;
            //                this.isNew = false;
            //                this.savedFileName = fileFullName;
            //            }
            //        }

            //        this.Close();

            //    }
            //    else if (result == DialogResult.No)
            //    {
            //        this.Close();
            //    }
            //    else if (result == DialogResult.Cancel)
            //    {
 
            //    }

            //}
            //else
            //{
            //    this.Close();
            //}

            this.Close();
        }

        private void FindStripItem_Click(object sender, EventArgs e)
        {
            FindReplaceForm findReplaceForm = new FindReplaceForm(true);
            if (DialogResult.OK == findReplaceForm.ShowDialog())
            {
                if (!this.isFind)
                {
                    this.searchPosition = 0;
                }
                string findString = findReplaceForm.FindTxt.Text;
                searchString = findString;
                if (!this.searchString.Equals(findString))
                    searchPosition=0;
                int nowIndex = this.ContentTxt.Find(findString, searchPosition, RichTextBoxFinds.None);
                if (nowIndex != -1)
                {
                    searchPosition = nowIndex + this.ContentTxt.SelectionLength;
                }
                else
                {
                    searchPosition = 0;
                }


                this.isFind = true;
            }
                
        }

        private void ReplaceStripItem_Click(object sender, EventArgs e)
        {
            FindReplaceForm findReplaceForm = new FindReplaceForm(false);
            if (DialogResult.OK == findReplaceForm.ShowDialog())
            {
                if (this.isFind)
                {
                    this.searchPosition = 0;
                }
                string findString = findReplaceForm.FindTxt.Text;
                searchString = findString;
                if (!this.searchString.Equals(findString))
                    searchPosition = 0;
                int nowIndex = this.ContentTxt.Find(findString, searchPosition, RichTextBoxFinds.None);
                if (nowIndex != -1)
                {
                    this.ContentTxt.SelectedText = findReplaceForm.ReplaceTxt.Text;
                    searchPosition = nowIndex + this.ContentTxt.SelectionLength;
                }
                else
                {
                    searchPosition = 0;
                }


                this.isFind = false;
            }
        }

        private void WordWrapStripItem_Click(object sender, EventArgs e)
        {
            this.ContentTxt.WordWrap = !this.ContentTxt.WordWrap;
            if (this.ContentTxt.WordWrap)
            {
                this.WordWrapStripItem.Image = Image.FromFile("AppIco/Selected.ico");
                this.WordWrapContextMI.Image = Image.FromFile("AppIco/Selected.ico");
            }
            else
            {
                this.WordWrapStripItem.Image = null;
                this.WordWrapContextMI.Image = null;
            }
        }

        private void FontStripItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDg=new FontDialog();
            fontDg.ShowApply=true;
            fontDg.ShowColor=true;
            fontDg.Apply +=new EventHandler(fontDg_Apply);
            if (DialogResult.OK == fontDg.ShowDialog())
            {
                this.autoCompleteWord.SetVisible(false);
                this.ContentTxt.Font = fontDg.Font;
                this.ContentTxt.ForeColor = fontDg.Color;
            }
        }

        private void fontDg_Apply(object sender, EventArgs e)
        {
            
            FontDialog fontDg = sender as FontDialog;
            this.autoCompleteWord.SetVisible(false);
            this.ContentTxt.Font = fontDg.Font;
            this.ContentTxt.ForeColor = fontDg.Color;
        }

        private void StatusBarStripItem_Click(object sender, EventArgs e)
        {
            this.statusBar.Visible = !this.statusBar.Visible;
            if (this.statusBar.Visible)
                this.StatusBarStripItem.Image = Image.FromFile("AppIco/Selected.ico");
            else
                this.StatusBarStripItem.Image = null;
        }

        private void AboutStripItem_Click(object sender, EventArgs e)
        {
            AboutNotepad aboutNotepad = new AboutNotepad();
            aboutNotepad.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.statusPanelTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 快捷键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContentTxt_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Add && e.Control)
            {
                if (this.ContentTxt.ZoomFactor >= 1 && this.ContentTxt.ZoomFactor < 32)
                {
                    this.ContentTxt.ZoomFactor *= 2;
                }
                return;
            }

            if (e.KeyCode == Keys.Subtract && e.Control)
            {
                if (this.ContentTxt.ZoomFactor > 1 && this.ContentTxt.ZoomFactor < 64)
                {
                    this.ContentTxt.ZoomFactor /= 2;
                }
                return;
            }

            if (e.KeyCode == Keys.Space && e.Control)
            {
                this.ContentTxt.ZoomFactor = 1;
                return;
            }
        }

        private void ContentTxt_TextChanged(object sender, EventArgs e)
        {
            this.Text = this.newTitle;
            this.isNew = true;
        }

        private void Notepad_MouseClick(object sender, MouseEventArgs e)
        {
            this.autoCompleteWord.SetVisible(false);
        }

        private void ContentTxt_MouseClick(object sender, MouseEventArgs e)
        {
            this.autoCompleteWord.SetVisible(false);
        }

        private void statusBar_MouseClick(object sender, MouseEventArgs e)
        {
            this.autoCompleteWord.SetVisible(false);
        }

        private void MenuStrip_MouseClick(object sender, MouseEventArgs e)
        {
            this.autoCompleteWord.SetVisible(false);
        }

        private void ContentTxt_SelectionChanged(object sender, EventArgs e)
        {
            int nowIndex = this.ContentTxt.SelectionStart;
            int rowIndex = this.ContentTxt.GetLineFromCharIndex(nowIndex);
            int columnIndex = nowIndex - this.ContentTxt.GetFirstCharIndexFromLine(rowIndex);

            this.statusPanelLinenum.Text = "第" + (rowIndex + 1) + "行        第" + columnIndex + "列";
        }

        private void Notepad_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ((!string.IsNullOrEmpty(this.ContentTxt.Text) && this.isNew) || (this.isNew && !this.savedFileName.Equals("")))
            {
                DialogResult result = MessageBox.Show("当前文件未保存，是否保存文件", "提示", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    if (this.isNew && !this.savedFileName.Equals(""))
                    {
                        this.ContentTxt.SaveFile(this.savedFileName, RichTextBoxStreamType.PlainText);
                        this.Text = this.savedTitle;
                        this.isNew = false;
                    }
                    else if (this.isNew)
                    {
                        string fileFullName = this.SaveFile("保存文件");
                        if (fileFullName != null)
                        {
                            this.Text = this.savedTitle;
                            this.statusPanelFile.Text = "文件:" + fileFullName;
                            this.isNew = false;
                            this.savedFileName = fileFullName;
                        }
                    }



                }
                else if (result == DialogResult.No)
                {

                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }

            }
            else
            {

            }
        }

        private void CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.Cancel == this.progress.ShowDialog())
            {
                
            }
                
        }

        #endregion


        #region 辅助函数
        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="title">对话框的标题</param>
        /// <returns>选择文件的绝对路径</returns>
        private string SaveFile(string title)
        {
            SaveFileDialog saveFiledg = new SaveFileDialog();
            saveFiledg.Title = title;
            saveFiledg.AddExtension = true;
            saveFiledg.CheckFileExists = false;
            saveFiledg.CheckPathExists = true;
            saveFiledg.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            saveFiledg.FilterIndex = 0;
            if (saveFiledg.ShowDialog() == DialogResult.OK)
            {
                this.ContentTxt.SaveFile(saveFiledg.FileNames[0], RichTextBoxStreamType.PlainText);
                return saveFiledg.FileNames[0];
            }

            return null;
        }
        /// <summary>
        /// 打开文件
        /// </summary>
        /// <returns></returns>
        private string OpenFile()
        {
            OpenFileDialog openFiledg = new OpenFileDialog();
            openFiledg.AddExtension = false;
            openFiledg.CheckFileExists = true;
            openFiledg.CheckPathExists = true;
            openFiledg.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
            openFiledg.FilterIndex = 0;
            if (openFiledg.ShowDialog() == DialogResult.OK)
            {
                this.ContentTxt.LoadFile(openFiledg.FileNames[0],RichTextBoxStreamType.PlainText);
                return openFiledg.FileNames[0];
            }
            return null;
        }
        /// <summary>
        /// 检测单行的语法错误
        /// </summary>
        /// <param name="lineIndex"></param>
        /// <returns></returns>
        public string CheckLineError(int lineIndex)
        {
            if (lineIndex > this.ContentTxt.Lines.Length - 1)
                return "正确";
            string currentLine = this.ContentTxt.Lines[lineIndex];
            char[] splitChars = { ' ','\t','\n'};
            string[] lineWords = currentLine.Split(splitChars);

            for (int i = 0; i < lineWords.Length; i++)
            {
                if (!lineWords[i].Equals("") && this.isWord(lineWords[i].Trim().ToLower()) && !this.checkTree.CheckExists(lineWords[i].Trim().ToLower()))
                {
                   return "第" + (lineIndex + 1) + "行单词\""+lineWords[i].Trim()+"\"拼写错误";
                }
            }
            return "正确";
        }
        /// <summary>
        /// 检测整个文本的单词拼写错误  注意中文的检测 换行的设置
        /// </summary>

        /// <summary>
        /// 判断给定字符创是否为单词
        /// </summary>
        /// <param name="word"></param>
        /// <returns></returns>
        private bool isWord(string word)
        {
            char[] wordArray = word.ToCharArray();
            for (int i = 0; i < wordArray.Length; i++)
            {
                if (wordArray[i] < 'a' || wordArray[i] > 'z')
                    return false;
            }

            return true;
        }

        #endregion

      

       




    }
}

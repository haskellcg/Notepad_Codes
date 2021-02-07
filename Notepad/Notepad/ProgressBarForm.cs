using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Notepad
{
    public partial class ProgressBarForm : Form
    {
        public ProgressBarForm(Notepad notepad)
        {
            InitializeComponent();
            this.notepad = notepad;
            this.Icon = new Icon("AppIco/Word.ico");
            this.StartPosition = FormStartPosition.CenterParent;
            threadRun = new Thread(new ThreadStart(CheckTextWordError));
        }

        private void ProgressBarForm_Load(object sender, EventArgs e)
        {
        }

        private void CheckTextWordError()
        {
            int linesCount = this.notepad.ContentTxt.Lines.Length;
            string info = "正确";
            this.notepad.statusPanelCheck.Text = "检测中......";
            this.notepad.statusPanelCheck.ToolTipText = "检测中......";

            this.progressBar1.Maximum = linesCount == 0 ? 100 : linesCount;
            this.progressBar1.Value = 0;
            this.Text = "当前进度：" + 0 + " %";


            for (int i = 0; i < linesCount; i++)
            {
                this.notepad.statusPanelCheck.Text = "检测第" + (i + 1) + "行";
                this.notepad.statusPanelCheck.ToolTipText = "检测第" + (i + 1) + "行";

                this.progressBar1.Value = i;
                this.Text = "当前进度：" + ((i/(double)linesCount)*100).ToString("#0.0") + " %";

                info = this.notepad.CheckLineError(i);
                if (!info.Equals("正确"))
                    break;
            }
            this.notepad.statusPanelCheck.Text = info;
            this.notepad.statusPanelCheck.ToolTipText = info;

            if (info.Equals("正确"))
            {
                this.progressBar1.Value = this.progressBar1.Maximum;
                this.Text = "当前进度：" + 100 + " %";
            }

            threadRun.Abort();
        }

        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            if (threadRun.ThreadState == ThreadState.Running)
            {
 
            }
            else
            {
                threadRun = new Thread(new ThreadStart(CheckTextWordError));
                threadRun.Start();
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            if(threadRun.ThreadState== ThreadState.Running)
                    threadRun.Abort();
        }

        private void ProgressBarForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (threadRun.ThreadState == ThreadState.Running)
                threadRun.Abort();

            this.progressBar1.Value = 0;
            this.Text = "当前进度：" + 0 + " %";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (threadRun.ThreadState == ThreadState.Running)
                threadRun.Abort();
        }
    }
}

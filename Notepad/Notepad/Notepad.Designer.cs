using System.Threading;
namespace Notepad
{
    partial class Notepad
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.ContentTxt = new RichTextBoxNotepad();
            this.ContextMenuStripMI = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.findContextMI = new System.Windows.Forms.ToolStripMenuItem();
            this.ReplaceContextMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.SaveFileContextMI = new System.Windows.Forms.ToolStripMenuItem();
            this.WordWrapContextMI = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitContextMI = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.FileStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NewFileStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFileStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveFileStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReSaveFileStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FindStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReplaceStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FormatStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WordWrapStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FontStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusBarStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutStripItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.autoCompleteWord = new AutoCompleteWord();
            this.CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextMenuStripMI.SuspendLayout();
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContentTxt
            // 
            this.ContentTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ContentTxt.AutoWordSelection = true;
            this.ContentTxt.ContextMenuStrip = this.ContextMenuStripMI;
            this.ContentTxt.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ContentTxt.Location = new System.Drawing.Point(0, 27);
            this.ContentTxt.Name = "ContentTxt";
            this.ContentTxt.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.ContentTxt.Size = new System.Drawing.Size(843, 385);
            this.ContentTxt.TabIndex = 0;
            this.ContentTxt.TabStop = false;
            this.ContentTxt.Text = "";
            this.ContentTxt.WordWrap = false;
            this.ContentTxt.SelectionChanged += new System.EventHandler(this.ContentTxt_SelectionChanged);
            this.ContentTxt.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ContentTxt_MouseClick);
            this.ContentTxt.TextChanged += new System.EventHandler(this.ContentTxt_TextChanged);
            this.ContentTxt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ContentTxt_KeyUp);
            // 
            // ContextMenuStripMI
            // 
            this.ContextMenuStripMI.Font = new System.Drawing.Font("隶书", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ContextMenuStripMI.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findContextMI,
            this.ReplaceContextMI,
            this.toolStripSeparator2,
            this.SaveFileContextMI,
            this.WordWrapContextMI,
            this.CToolStripMenuItem,
            this.ExitContextMI});
            this.ContextMenuStripMI.Name = "ContextMenuStripMI";
            this.ContextMenuStripMI.Size = new System.Drawing.Size(159, 164);
            // 
            // findContextMI
            // 
            this.findContextMI.Name = "findContextMI";
            this.findContextMI.Size = new System.Drawing.Size(158, 22);
            this.findContextMI.Text = "查找(&F)";
            this.findContextMI.Click += new System.EventHandler(this.FindStripItem_Click);
            // 
            // ReplaceContextMI
            // 
            this.ReplaceContextMI.Name = "ReplaceContextMI";
            this.ReplaceContextMI.Size = new System.Drawing.Size(158, 22);
            this.ReplaceContextMI.Text = "替换(&R)";
            this.ReplaceContextMI.Click += new System.EventHandler(this.ReplaceStripItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(155, 6);
            // 
            // SaveFileContextMI
            // 
            this.SaveFileContextMI.Name = "SaveFileContextMI";
            this.SaveFileContextMI.Size = new System.Drawing.Size(158, 22);
            this.SaveFileContextMI.Text = "保存(&S)";
            this.SaveFileContextMI.Click += new System.EventHandler(this.SaveFileStripItem_Click);
            // 
            // WordWrapContextMI
            // 
            this.WordWrapContextMI.Name = "WordWrapContextMI";
            this.WordWrapContextMI.Size = new System.Drawing.Size(158, 22);
            this.WordWrapContextMI.Text = "自动换行(&W)";
            this.WordWrapContextMI.Click += new System.EventHandler(this.WordWrapStripItem_Click);
            // 
            // ExitContextMI
            // 
            this.ExitContextMI.Name = "ExitContextMI";
            this.ExitContextMI.Size = new System.Drawing.Size(158, 22);
            this.ExitContextMI.Text = "退出(&X)";
            this.ExitContextMI.Click += new System.EventHandler(this.ExitStripItem_Click);
            // 
            // MenuStrip
            // 
            this.MenuStrip.Font = new System.Drawing.Font("隶书", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileStripItem,
            this.EditStripItem,
            this.FormatStripItem,
            this.ViewStripItem,
            this.HelpStripItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(843, 24);
            this.MenuStrip.TabIndex = 1;
            this.MenuStrip.Text = "menuStrip1";
            this.MenuStrip.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MenuStrip_MouseClick);
            // 
            // FileStripItem
            // 
            this.FileStripItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewFileStripItem,
            this.OpenFileStripItem,
            this.SaveFileStripItem,
            this.ReSaveFileStripItem,
            this.toolStripSeparator1,
            this.ExitStripItem});
            this.FileStripItem.Name = "FileStripItem";
            this.FileStripItem.Size = new System.Drawing.Size(64, 20);
            this.FileStripItem.Text = "文件(&F)";
            // 
            // NewFileStripItem
            // 
            this.NewFileStripItem.Name = "NewFileStripItem";
            this.NewFileStripItem.Size = new System.Drawing.Size(130, 22);
            this.NewFileStripItem.Text = "新建(&N)";
            this.NewFileStripItem.Click += new System.EventHandler(this.NewFileStripItem_Click);
            // 
            // OpenFileStripItem
            // 
            this.OpenFileStripItem.Name = "OpenFileStripItem";
            this.OpenFileStripItem.Size = new System.Drawing.Size(130, 22);
            this.OpenFileStripItem.Text = "打开(&O)";
            this.OpenFileStripItem.Click += new System.EventHandler(this.OpenFileStripItem_Click);
            // 
            // SaveFileStripItem
            // 
            this.SaveFileStripItem.Name = "SaveFileStripItem";
            this.SaveFileStripItem.Size = new System.Drawing.Size(130, 22);
            this.SaveFileStripItem.Text = "保存(&S)";
            this.SaveFileStripItem.Click += new System.EventHandler(this.SaveFileStripItem_Click);
            // 
            // ReSaveFileStripItem
            // 
            this.ReSaveFileStripItem.Name = "ReSaveFileStripItem";
            this.ReSaveFileStripItem.Size = new System.Drawing.Size(130, 22);
            this.ReSaveFileStripItem.Text = "另存为(&A)";
            this.ReSaveFileStripItem.Click += new System.EventHandler(this.ReSaveFileStripItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(127, 6);
            // 
            // ExitStripItem
            // 
            this.ExitStripItem.Name = "ExitStripItem";
            this.ExitStripItem.Size = new System.Drawing.Size(130, 22);
            this.ExitStripItem.Text = "退出(&X)";
            this.ExitStripItem.Click += new System.EventHandler(this.ExitStripItem_Click);
            // 
            // EditStripItem
            // 
            this.EditStripItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FindStripItem,
            this.ReplaceStripItem});
            this.EditStripItem.Name = "EditStripItem";
            this.EditStripItem.Size = new System.Drawing.Size(64, 20);
            this.EditStripItem.Text = "编辑(&E)";
            // 
            // FindStripItem
            // 
            this.FindStripItem.Name = "FindStripItem";
            this.FindStripItem.Size = new System.Drawing.Size(117, 22);
            this.FindStripItem.Text = "查找(&F)";
            this.FindStripItem.Click += new System.EventHandler(this.FindStripItem_Click);
            // 
            // ReplaceStripItem
            // 
            this.ReplaceStripItem.Name = "ReplaceStripItem";
            this.ReplaceStripItem.Size = new System.Drawing.Size(117, 22);
            this.ReplaceStripItem.Text = "替换(&R)";
            this.ReplaceStripItem.Click += new System.EventHandler(this.ReplaceStripItem_Click);
            // 
            // FormatStripItem
            // 
            this.FormatStripItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WordWrapStripItem,
            this.FontStripItem});
            this.FormatStripItem.Name = "FormatStripItem";
            this.FormatStripItem.Size = new System.Drawing.Size(64, 20);
            this.FormatStripItem.Text = "格式(&O)";
            // 
            // WordWrapStripItem
            // 
            this.WordWrapStripItem.Name = "WordWrapStripItem";
            this.WordWrapStripItem.Size = new System.Drawing.Size(117, 22);
            this.WordWrapStripItem.Text = "换行(&W)";
            this.WordWrapStripItem.Click += new System.EventHandler(this.WordWrapStripItem_Click);
            // 
            // FontStripItem
            // 
            this.FontStripItem.Name = "FontStripItem";
            this.FontStripItem.Size = new System.Drawing.Size(117, 22);
            this.FontStripItem.Text = "字体(&F)";
            this.FontStripItem.Click += new System.EventHandler(this.FontStripItem_Click);
            // 
            // ViewStripItem
            // 
            this.ViewStripItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusBarStripItem});
            this.ViewStripItem.Name = "ViewStripItem";
            this.ViewStripItem.Size = new System.Drawing.Size(64, 20);
            this.ViewStripItem.Text = "查看(&V)";
            // 
            // StatusBarStripItem
            // 
            this.StatusBarStripItem.Name = "StatusBarStripItem";
            this.StatusBarStripItem.Size = new System.Drawing.Size(130, 22);
            this.StatusBarStripItem.Text = "状态栏(&S)";
            this.StatusBarStripItem.Click += new System.EventHandler(this.StatusBarStripItem_Click);
            // 
            // HelpStripItem
            // 
            this.HelpStripItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutStripItem});
            this.HelpStripItem.Name = "HelpStripItem";
            this.HelpStripItem.Size = new System.Drawing.Size(64, 20);
            this.HelpStripItem.Text = "帮助(&H)";
            // 
            // AboutStripItem
            // 
            this.AboutStripItem.Name = "AboutStripItem";
            this.AboutStripItem.Size = new System.Drawing.Size(166, 22);
            this.AboutStripItem.Text = "关于Notepad(&A)";
            this.AboutStripItem.Click += new System.EventHandler(this.AboutStripItem_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.ContextMenuStripMI;
            this.notifyIcon.Text = "notifyIcon1";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // CToolStripMenuItem
            // 
            this.CToolStripMenuItem.Name = "CToolStripMenuItem";
            this.CToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.CToolStripMenuItem.Text = "单词检错(&C)";
            this.CToolStripMenuItem.Click += new System.EventHandler(this.CToolStripMenuItem_Click);
            // 
            // Notepad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 437);
            this.ContextMenuStrip = this.ContextMenuStripMI;
            this.Controls.Add(this.ContentTxt);
            this.Controls.Add(this.MenuStrip);
            this.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.MenuStrip;
            this.Name = "Notepad";
            this.Text = "Notepad";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Notepad_FormClosing);
            this.Load += new System.EventHandler(this.Notepad_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Notepad_MouseClick);
            this.ContextMenuStripMI.ResumeLayout(false);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public RichTextBoxNotepad ContentTxt;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem FileStripItem;
        private System.Windows.Forms.ToolStripMenuItem NewFileStripItem;
        private System.Windows.Forms.ToolStripMenuItem OpenFileStripItem;
        private System.Windows.Forms.ToolStripMenuItem SaveFileStripItem;
        private System.Windows.Forms.ToolStripMenuItem ReSaveFileStripItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ExitStripItem;
        private System.Windows.Forms.ToolStripMenuItem EditStripItem;
        private System.Windows.Forms.ToolStripMenuItem FindStripItem;
        private System.Windows.Forms.ToolStripMenuItem ReplaceStripItem;
        private System.Windows.Forms.ToolStripMenuItem FormatStripItem;
        private System.Windows.Forms.ToolStripMenuItem WordWrapStripItem;
        private System.Windows.Forms.ToolStripMenuItem FontStripItem;
        private System.Windows.Forms.ToolStripMenuItem ViewStripItem;
        private System.Windows.Forms.ToolStripMenuItem StatusBarStripItem;
        private System.Windows.Forms.ToolStripMenuItem HelpStripItem;
        private System.Windows.Forms.ToolStripMenuItem AboutStripItem;
        private System.Windows.Forms.ContextMenuStrip ContextMenuStripMI;
        private System.Windows.Forms.ToolStripMenuItem findContextMI;
        private System.Windows.Forms.ToolStripMenuItem ReplaceContextMI;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem SaveFileContextMI;
        private System.Windows.Forms.ToolStripMenuItem WordWrapContextMI;
        private System.Windows.Forms.ToolStripMenuItem ExitContextMI;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ToolTip toolTip;


        private System.Windows.Forms.StatusBar statusBar;
        public System.Windows.Forms.StatusBarPanel statusPanelCheck;
        private System.Windows.Forms.StatusBarPanel statusPanelSystem;
        private System.Windows.Forms.StatusBarPanel statusPanelTime;
        private System.Windows.Forms.StatusBarPanel statusPanelFile;
        private System.Windows.Forms.StatusBarPanel statusPanelLinenum;
        private System.Windows.Forms.Timer timer1;
        private AutoCompleteWord autoCompleteWord;

        //搜索时记录历史以及位置
        private int searchPosition;
        private string searchString;
        private bool isFind;

        //记录文件是否新建
        private bool isNew;

        //记录文件名(如果已经保存)
        private string savedFileName;

        //定义窗口标题常量
        private string savedTitle;
        private string newTitle;

        private TrieTree checkTree;
        private System.Windows.Forms.ToolStripMenuItem CToolStripMenuItem;
        private ProgressBarForm progress;

        }
}


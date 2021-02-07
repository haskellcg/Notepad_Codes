namespace Notepad
{
    partial class AutoCompleteWord
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

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this._view = new DataGridViewNotepad();
            ((System.ComponentModel.ISupportInitialize)(this._view)).BeginInit();
            // 
            // _view
            // 
            this._view.AllowUserToAddRows = false;
            this._view.AllowUserToDeleteRows = false;
            this._view.AllowUserToResizeColumns = false;
            this._view.AllowUserToResizeRows = false;
            this._view.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this._view.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._view.ColumnHeadersVisible = false;
            this._view.Location = new System.Drawing.Point(0, 0);
            this._view.MultiSelect = false;
            this._view.Name = "_view";
            this._view.ReadOnly = true;
            this._view.RowHeadersVisible = false;
            this._view.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this._view.RowTemplate.Height = 23;
            this._view.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this._view.Size = new System.Drawing.Size(120, 140);
            this._view.TabIndex = 0;
            this._view.CellToolTipTextNeeded += new System.Windows.Forms.DataGridViewCellToolTipTextNeededEventHandler(this._view_CellToolTipTextNeeded);
            this._view.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this._view_MouseDoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this._view)).EndInit();

        }

        #endregion

        private DataGridViewNotepad _view;
        
        private System.Windows.Forms.Control _form;

        private System.Collections.Generic.Dictionary<string, IDataAdapter> _adapters;

        private const int viewDisplayNumber = 7;
    }
}

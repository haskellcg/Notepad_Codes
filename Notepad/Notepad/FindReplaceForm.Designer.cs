namespace Notepad
{
    partial class FindReplaceForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.FindTxt = new System.Windows.Forms.TextBox();
            this.ReplaceTxt = new System.Windows.Forms.TextBox();
            this.FindReplaceBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "查找";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "替换";
            // 
            // FindTxt
            // 
            this.FindTxt.Location = new System.Drawing.Point(77, 30);
            this.FindTxt.Name = "FindTxt";
            this.FindTxt.Size = new System.Drawing.Size(192, 21);
            this.FindTxt.TabIndex = 2;
            // 
            // ReplaceTxt
            // 
            this.ReplaceTxt.Location = new System.Drawing.Point(77, 84);
            this.ReplaceTxt.Name = "ReplaceTxt";
            this.ReplaceTxt.Size = new System.Drawing.Size(192, 21);
            this.ReplaceTxt.TabIndex = 3;
            // 
            // FindReplaceBtn
            // 
            this.FindReplaceBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.FindReplaceBtn.Location = new System.Drawing.Point(303, 27);
            this.FindReplaceBtn.Name = "FindReplaceBtn";
            this.FindReplaceBtn.Size = new System.Drawing.Size(53, 23);
            this.FindReplaceBtn.TabIndex = 4;
            this.FindReplaceBtn.Text = "确定";
            this.FindReplaceBtn.UseVisualStyleBackColor = true;
            
            // 
            // CancelBtn
            // 
            this.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBtn.Location = new System.Drawing.Point(303, 82);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(53, 23);
            this.CancelBtn.TabIndex = 5;
            this.CancelBtn.Text = "取消";
            this.CancelBtn.UseVisualStyleBackColor = true;
            // 
            // FindReplaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 148);
            this.ControlBox = false;
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.FindReplaceBtn);
            this.Controls.Add(this.ReplaceTxt);
            this.Controls.Add(this.FindTxt);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FindReplaceForm";
            this.Text = "查找 替换";
            this.Load += new System.EventHandler(this.FindReplaceForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox FindTxt;
        public System.Windows.Forms.TextBox ReplaceTxt;
        private System.Windows.Forms.Button FindReplaceBtn;
        private System.Windows.Forms.Button CancelBtn;

        public bool isFind;
    }
}
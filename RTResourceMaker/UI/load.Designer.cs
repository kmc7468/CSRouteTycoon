namespace RTResourceMaker.UI
{
    partial class load
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbTitle = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lbLoadTip = new System.Windows.Forms.Label();
            this.listboxSln = new System.Windows.Forms.ListBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbTitle.Location = new System.Drawing.Point(60, 90);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(202, 21);
            this.lbTitle.TabIndex = 9;
            this.lbTitle.Text = "프로젝트 불러 오기";
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Location = new System.Drawing.Point(87, 314);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(145, 30);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBrowse.Location = new System.Drawing.Point(87, 196);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(145, 30);
            this.btnBrowse.TabIndex = 20;
            this.btnBrowse.Text = "찾아 보기";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lbLoadTip
            // 
            this.lbLoadTip.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbLoadTip.Location = new System.Drawing.Point(250, 347);
            this.lbLoadTip.Name = "lbLoadTip";
            this.lbLoadTip.Size = new System.Drawing.Size(270, 30);
            this.lbLoadTip.TabIndex = 23;
            this.lbLoadTip.Text = "더블 클릭하여 프로젝트를 불러 옵니다.";
            this.lbLoadTip.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // listboxSln
            // 
            this.listboxSln.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listboxSln.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.listboxSln.FormattingEnabled = true;
            this.listboxSln.Location = new System.Drawing.Point(250, 160);
            this.listboxSln.Name = "listboxSln";
            this.listboxSln.Size = new System.Drawing.Size(270, 184);
            this.listboxSln.TabIndex = 21;
            this.listboxSln.SelectedIndexChanged += new System.EventHandler(this.listboxSln_SelectedIndexChanged);
            this.listboxSln.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listboxSln_MouseDoubleClick);
            // 
            // btnRemove
            // 
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRemove.Location = new System.Drawing.Point(87, 160);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(145, 30);
            this.btnRemove.TabIndex = 24;
            this.btnRemove.Text = "삭제";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // load
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.lbLoadTip);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.listboxSln);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.lbTitle);
            this.DoubleBuffered = true;
            this.Name = "load";
            this.Size = new System.Drawing.Size(580, 440);
            this.Load += new System.EventHandler(this.load_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lbLoadTip;
        private System.Windows.Forms.ListBox listboxSln;
        private System.Windows.Forms.Button btnRemove;
    }
}

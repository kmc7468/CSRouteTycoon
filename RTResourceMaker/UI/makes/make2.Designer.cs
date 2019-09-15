namespace RTResourceMaker.UI.makes
{
    partial class make2
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
            this.txtLoc = new System.Windows.Forms.TextBox();
            this.lbResLoc = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnFinish = new System.Windows.Forms.Button();
            this.lbResTip = new System.Windows.Forms.Label();
            this.btnPrevious = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbTitle.Location = new System.Drawing.Point(60, 90);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(128, 21);
            this.lbTitle.TabIndex = 9;
            this.lbTitle.Text = "새 프로젝트";
            // 
            // txtLoc
            // 
            this.txtLoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLoc.Font = new System.Drawing.Font("굴림", 10F);
            this.txtLoc.Location = new System.Drawing.Point(182, 158);
            this.txtLoc.Name = "txtLoc";
            this.txtLoc.ReadOnly = true;
            this.txtLoc.Size = new System.Drawing.Size(250, 23);
            this.txtLoc.TabIndex = 12;
            // 
            // lbResLoc
            // 
            this.lbResLoc.AutoSize = true;
            this.lbResLoc.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbResLoc.Location = new System.Drawing.Point(100, 160);
            this.lbResLoc.Name = "lbResLoc";
            this.lbResLoc.Size = new System.Drawing.Size(76, 13);
            this.lbResLoc.TabIndex = 11;
            this.lbResLoc.Text = "리소스 경로";
            this.lbResLoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnBrowse
            // 
            this.btnBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBrowse.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnBrowse.Location = new System.Drawing.Point(432, 158);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(30, 23);
            this.btnBrowse.TabIndex = 16;
            this.btnBrowse.Text = "...";
            this.btnBrowse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnFinish
            // 
            this.btnFinish.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFinish.Location = new System.Drawing.Point(430, 340);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(100, 30);
            this.btnFinish.TabIndex = 18;
            this.btnFinish.Text = "완료";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // lbResTip
            // 
            this.lbResTip.AutoSize = true;
            this.lbResTip.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbResTip.Location = new System.Drawing.Point(30, 359);
            this.lbResTip.Name = "lbResTip";
            this.lbResTip.Size = new System.Drawing.Size(262, 11);
            this.lbResTip.TabIndex = 19;
            this.lbResTip.Text = "리소스 정보는 추후에 다시 변경이 가능합니다.";
            this.lbResTip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnPrevious
            // 
            this.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPrevious.Location = new System.Drawing.Point(324, 340);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(100, 30);
            this.btnPrevious.TabIndex = 20;
            this.btnPrevious.Text = "뒤로";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // make2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.lbResTip);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtLoc);
            this.Controls.Add(this.lbResLoc);
            this.Controls.Add(this.lbTitle);
            this.DoubleBuffered = true;
            this.Name = "make2";
            this.Size = new System.Drawing.Size(564, 401);
            this.Load += new System.EventHandler(this.make2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.TextBox txtLoc;
        private System.Windows.Forms.Label lbResLoc;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.Label lbResTip;
        private System.Windows.Forms.Button btnPrevious;
    }
}

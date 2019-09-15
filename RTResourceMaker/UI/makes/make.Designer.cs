namespace RTResourceMaker.UI.makes
{
    partial class make
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbTitle = new System.Windows.Forms.Label();
            this.lbResName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtMaker = new System.Windows.Forms.TextBox();
            this.lbResMaker = new System.Windows.Forms.Label();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.lbResInfo = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.lbResTip = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtver = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbTitle.Location = new System.Drawing.Point(60, 90);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(128, 21);
            this.lbTitle.TabIndex = 8;
            this.lbTitle.Text = "새 프로젝트";
            // 
            // lbResName
            // 
            this.lbResName.AutoSize = true;
            this.lbResName.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbResName.Location = new System.Drawing.Point(100, 160);
            this.lbResName.Name = "lbResName";
            this.lbResName.Size = new System.Drawing.Size(76, 13);
            this.lbResName.TabIndex = 9;
            this.lbResName.Text = "리소스 이름";
            this.lbResName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Font = new System.Drawing.Font("굴림", 10F);
            this.txtName.Location = new System.Drawing.Point(182, 158);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(250, 23);
            this.txtName.TabIndex = 10;
            // 
            // txtMaker
            // 
            this.txtMaker.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMaker.Font = new System.Drawing.Font("굴림", 10F);
            this.txtMaker.Location = new System.Drawing.Point(182, 187);
            this.txtMaker.Name = "txtMaker";
            this.txtMaker.Size = new System.Drawing.Size(250, 23);
            this.txtMaker.TabIndex = 12;
            // 
            // lbResMaker
            // 
            this.lbResMaker.AutoSize = true;
            this.lbResMaker.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbResMaker.Location = new System.Drawing.Point(87, 189);
            this.lbResMaker.Name = "lbResMaker";
            this.lbResMaker.Size = new System.Drawing.Size(89, 13);
            this.lbResMaker.TabIndex = 11;
            this.lbResMaker.Text = "리소스 제작자";
            this.lbResMaker.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtInfo
            // 
            this.txtInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInfo.Font = new System.Drawing.Font("굴림", 10F);
            this.txtInfo.Location = new System.Drawing.Point(182, 216);
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(250, 23);
            this.txtInfo.TabIndex = 14;
            // 
            // lbResInfo
            // 
            this.lbResInfo.AutoSize = true;
            this.lbResInfo.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbResInfo.Location = new System.Drawing.Point(100, 218);
            this.lbResInfo.Name = "lbResInfo";
            this.lbResInfo.Size = new System.Drawing.Size(76, 13);
            this.lbResInfo.TabIndex = 13;
            this.lbResInfo.Text = "리소스 설명";
            this.lbResInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnNext
            // 
            this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNext.Location = new System.Drawing.Point(430, 340);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(100, 30);
            this.btnNext.TabIndex = 16;
            this.btnNext.Text = "다음";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lbResTip
            // 
            this.lbResTip.AutoSize = true;
            this.lbResTip.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbResTip.Location = new System.Drawing.Point(30, 359);
            this.lbResTip.Name = "lbResTip";
            this.lbResTip.Size = new System.Drawing.Size(262, 11);
            this.lbResTip.TabIndex = 16;
            this.lbResTip.Text = "리소스 정보는 추후에 다시 변경이 가능합니다.";
            this.lbResTip.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Location = new System.Drawing.Point(324, 340);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex = 17;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtver
            // 
            this.txtver.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtver.Font = new System.Drawing.Font("굴림", 10F);
            this.txtver.Location = new System.Drawing.Point(182, 245);
            this.txtver.Name = "txtver";
            this.txtver.Size = new System.Drawing.Size(250, 23);
            this.txtver.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(87, 247);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "호환되는 버전";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // make
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.txtver);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lbResTip);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.lbResInfo);
            this.Controls.Add(this.txtMaker);
            this.Controls.Add(this.lbResMaker);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lbResName);
            this.Controls.Add(this.lbTitle);
            this.DoubleBuffered = true;
            this.Name = "make";
            this.Size = new System.Drawing.Size(564, 401);
            this.Load += new System.EventHandler(this.make_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Label lbResName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtMaker;
        private System.Windows.Forms.Label lbResMaker;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.Label lbResInfo;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lbResTip;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtver;
        private System.Windows.Forms.Label label1;
    }
}

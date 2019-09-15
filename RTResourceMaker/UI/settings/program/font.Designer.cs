namespace RTResourceMaker.UI.settings.programs
{
    partial class font
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
            this.lbPreview = new System.Windows.Forms.Label();
            this.txtboxPreview = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.comboboxFonts = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lbPreview
            // 
            this.lbPreview.AutoSize = true;
            this.lbPreview.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbPreview.Location = new System.Drawing.Point(17, 104);
            this.lbPreview.Name = "lbPreview";
            this.lbPreview.Size = new System.Drawing.Size(63, 13);
            this.lbPreview.TabIndex = 19;
            this.lbPreview.Text = "미리보기";
            this.lbPreview.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtboxPreview
            // 
            this.txtboxPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtboxPreview.Font = new System.Drawing.Font("굴림", 10F);
            this.txtboxPreview.Location = new System.Drawing.Point(20, 120);
            this.txtboxPreview.Name = "txtboxPreview";
            this.txtboxPreview.ReadOnly = true;
            this.txtboxPreview.Size = new System.Drawing.Size(250, 23);
            this.txtboxPreview.TabIndex = 20;
            this.txtboxPreview.Text = "TempText";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(18, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 22;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnApply
            // 
            this.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnApply.Location = new System.Drawing.Point(190, 46);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(80, 20);
            this.btnApply.TabIndex = 23;
            this.btnApply.Text = "적용";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // comboboxFonts
            // 
            this.comboboxFonts.BackColor = System.Drawing.Color.WhiteSmoke;
            this.comboboxFonts.FormattingEnabled = true;
            this.comboboxFonts.Location = new System.Drawing.Point(20, 20);
            this.comboboxFonts.Name = "comboboxFonts";
            this.comboboxFonts.Size = new System.Drawing.Size(250, 20);
            this.comboboxFonts.TabIndex = 24;
            this.comboboxFonts.SelectedIndexChanged += new System.EventHandler(this.comboboxFonts_SelectedIndexChanged);
            // 
            // font
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.comboboxFonts);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtboxPreview);
            this.Controls.Add(this.lbPreview);
            this.DoubleBuffered = true;
            this.Name = "font";
            this.Size = new System.Drawing.Size(350, 184);
            this.Load += new System.EventHandler(this.font_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbPreview;
        private System.Windows.Forms.TextBox txtboxPreview;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.ComboBox comboboxFonts;
    }
}

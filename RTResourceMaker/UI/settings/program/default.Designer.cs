namespace RTResourceMaker.UI.settings.programs
{
    partial class _default
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
            this.checkboxUseAutoSave = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // checkboxUseAutoSave
            // 
            this.checkboxUseAutoSave.AutoSize = true;
            this.checkboxUseAutoSave.Font = new System.Drawing.Font("굴림", 9.75F);
            this.checkboxUseAutoSave.Location = new System.Drawing.Point(20, 20);
            this.checkboxUseAutoSave.Name = "checkboxUseAutoSave";
            this.checkboxUseAutoSave.Size = new System.Drawing.Size(220, 17);
            this.checkboxUseAutoSave.TabIndex = 18;
            this.checkboxUseAutoSave.Text = "프로젝트를 자동으로 저장합니다.";
            this.checkboxUseAutoSave.UseVisualStyleBackColor = true;
            this.checkboxUseAutoSave.CheckedChanged += new System.EventHandler(this.checkboxUseAutoSave_CheckedChanged);
            // 
            // setedit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.checkboxUseAutoSave);
            this.DoubleBuffered = true;
            this.Name = "setedit";
            this.Size = new System.Drawing.Size(350, 184);
            this.Load += new System.EventHandler(this.setedit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkboxUseAutoSave;
    }
}

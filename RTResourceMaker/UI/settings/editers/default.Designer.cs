namespace RTResourceMaker.UI.settings.editers
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
            this.checkboxUseIntelliSense = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // checkboxUseIntelliSense
            // 
            this.checkboxUseIntelliSense.AutoSize = true;
            this.checkboxUseIntelliSense.Font = new System.Drawing.Font("굴림", 9.75F);
            this.checkboxUseIntelliSense.Location = new System.Drawing.Point(20, 20);
            this.checkboxUseIntelliSense.Name = "checkboxUseIntelliSense";
            this.checkboxUseIntelliSense.Size = new System.Drawing.Size(263, 17);
            this.checkboxUseIntelliSense.TabIndex = 19;
            this.checkboxUseIntelliSense.Text = "편집기에 인텔리센스 기능을 사용합니다.";
            this.checkboxUseIntelliSense.UseVisualStyleBackColor = true;
            this.checkboxUseIntelliSense.CheckedChanged += new System.EventHandler(this.checkboxUseIntelliSense_CheckedChanged);
            // 
            // _default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.checkboxUseIntelliSense);
            this.DoubleBuffered = true;
            this.Name = "_default";
            this.Size = new System.Drawing.Size(350, 184);
            this.Load += new System.EventHandler(this.setprogram_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkboxUseIntelliSense;
    }
}

namespace RTTrainTool
{
	partial class frmMain
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
			this.lbVerInfo = new System.Windows.Forms.Label();
			this.lbTitle = new System.Windows.Forms.Label();
			this.btnInstitutionsCarriage = new System.Windows.Forms.Button();
			this.btnData = new System.Windows.Forms.Button();
			this.btnCar = new System.Windows.Forms.Button();
			this.btnLoc = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lbVerInfo
			// 
			this.lbVerInfo.AutoSize = true;
			this.lbVerInfo.Font = new System.Drawing.Font("맑은 고딕", 10F);
			this.lbVerInfo.Location = new System.Drawing.Point(9, 396);
			this.lbVerInfo.Name = "lbVerInfo";
			this.lbVerInfo.Size = new System.Drawing.Size(299, 76);
			this.lbVerInfo.TabIndex = 0;
			this.lbVerInfo.Text = "기관차 호환 버전 : 1.0.0 Beta 1 ~\r\n기관객차 호환 버전 : 1.0.0 Beta 2 Preview 2 ~\r\n객차 호환 버전 : 1.0" +
    ".0 Beta 2 Preview 2 ~\r\n편성 호환 버전 : (개발 중)";
			// 
			// lbTitle
			// 
			this.lbTitle.AutoSize = true;
			this.lbTitle.Font = new System.Drawing.Font("맑은 고딕", 48F);
			this.lbTitle.ForeColor = System.Drawing.SystemColors.Highlight;
			this.lbTitle.Location = new System.Drawing.Point(131, 34);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new System.Drawing.Size(379, 86);
			this.lbTitle.TabIndex = 10;
			this.lbTitle.Text = "RTTrainTool";
			// 
			// btnInstitutionsCarriage
			// 
			this.btnInstitutionsCarriage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.btnInstitutionsCarriage.Font = new System.Drawing.Font("맑은 고딕", 11F);
			this.btnInstitutionsCarriage.Location = new System.Drawing.Point(37, 196);
			this.btnInstitutionsCarriage.Name = "btnInstitutionsCarriage";
			this.btnInstitutionsCarriage.Size = new System.Drawing.Size(567, 51);
			this.btnInstitutionsCarriage.TabIndex = 18;
			this.btnInstitutionsCarriage.Text = "기관객차 제작";
			this.btnInstitutionsCarriage.UseVisualStyleBackColor = false;
			this.btnInstitutionsCarriage.Click += new System.EventHandler(this.btnInstitutionsCarriage_Click);
			// 
			// btnData
			// 
			this.btnData.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
			this.btnData.Font = new System.Drawing.Font("맑은 고딕", 11F);
			this.btnData.Location = new System.Drawing.Point(37, 310);
			this.btnData.Name = "btnData";
			this.btnData.Size = new System.Drawing.Size(567, 51);
			this.btnData.TabIndex = 17;
			this.btnData.Text = "편성 제작";
			this.btnData.UseVisualStyleBackColor = false;
			this.btnData.Click += new System.EventHandler(this.btnData_Click);
			// 
			// btnCar
			// 
			this.btnCar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.btnCar.Font = new System.Drawing.Font("맑은 고딕", 11F);
			this.btnCar.Location = new System.Drawing.Point(37, 253);
			this.btnCar.Name = "btnCar";
			this.btnCar.Size = new System.Drawing.Size(567, 51);
			this.btnCar.TabIndex = 16;
			this.btnCar.Text = "객차 제작";
			this.btnCar.UseVisualStyleBackColor = false;
			this.btnCar.Click += new System.EventHandler(this.btnCar_Click);
			// 
			// btnLoc
			// 
			this.btnLoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
			this.btnLoc.Font = new System.Drawing.Font("맑은 고딕", 11F);
			this.btnLoc.Location = new System.Drawing.Point(37, 139);
			this.btnLoc.Name = "btnLoc";
			this.btnLoc.Size = new System.Drawing.Size(567, 51);
			this.btnLoc.TabIndex = 15;
			this.btnLoc.Text = "기관차 제작";
			this.btnLoc.UseVisualStyleBackColor = false;
			this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
			// 
			// frmMain
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(640, 480);
			this.Controls.Add(this.btnInstitutionsCarriage);
			this.Controls.Add(this.btnData);
			this.Controls.Add(this.btnCar);
			this.Controls.Add(this.btnLoc);
			this.Controls.Add(this.lbTitle);
			this.Controls.Add(this.lbVerInfo);
			this.DoubleBuffered = true;
			this.Font = new System.Drawing.Font("맑은 고딕", 9F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "frmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "RTTrainTool 1.0.0.2";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lbVerInfo;
		private System.Windows.Forms.Label lbTitle;
		private System.Windows.Forms.Button btnInstitutionsCarriage;
		private System.Windows.Forms.Button btnData;
		private System.Windows.Forms.Button btnCar;
		private System.Windows.Forms.Button btnLoc;
	}
}
namespace RTMapTool
{
	partial class frmTool
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
			this.btnEditCity = new System.Windows.Forms.Button();
			this.btnNew = new System.Windows.Forms.Button();
			this.btnLoad = new System.Windows.Forms.Button();
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnDelRegion = new System.Windows.Forms.Button();
			this.btnAddRegion = new System.Windows.Forms.Button();
			this.lstRegion = new System.Windows.Forms.ListBox();
			this.lbRegion = new System.Windows.Forms.Label();
			this.lbImage = new System.Windows.Forms.Label();
			this.btnSelectImage = new System.Windows.Forms.Button();
			this.txtImage = new System.Windows.Forms.TextBox();
			this.lbTitle = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnEditCity
			// 
			this.btnEditCity.Location = new System.Drawing.Point(103, 551);
			this.btnEditCity.Name = "btnEditCity";
			this.btnEditCity.Size = new System.Drawing.Size(86, 27);
			this.btnEditCity.TabIndex = 25;
			this.btnEditCity.Text = "도시 편집";
			this.btnEditCity.UseVisualStyleBackColor = true;
			this.btnEditCity.Click += new System.EventHandler(this.btnEditCity_Click);
			// 
			// btnNew
			// 
			this.btnNew.Location = new System.Drawing.Point(142, 639);
			this.btnNew.Name = "btnNew";
			this.btnNew.Size = new System.Drawing.Size(87, 31);
			this.btnNew.TabIndex = 24;
			this.btnNew.Text = "새로 만들기";
			this.btnNew.UseVisualStyleBackColor = true;
			this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
			// 
			// btnLoad
			// 
			this.btnLoad.Location = new System.Drawing.Point(49, 676);
			this.btnLoad.Name = "btnLoad";
			this.btnLoad.Size = new System.Drawing.Size(87, 31);
			this.btnLoad.TabIndex = 23;
			this.btnLoad.Text = "불러오기";
			this.btnLoad.UseVisualStyleBackColor = true;
			this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.Location = new System.Drawing.Point(11, 551);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(86, 27);
			this.btnEdit.TabIndex = 22;
			this.btnEdit.Text = "이름 변경";
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(142, 676);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(87, 31);
			this.btnSave.TabIndex = 21;
			this.btnSave.Text = "저장";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnDelRegion
			// 
			this.btnDelRegion.Location = new System.Drawing.Point(103, 518);
			this.btnDelRegion.Name = "btnDelRegion";
			this.btnDelRegion.Size = new System.Drawing.Size(86, 27);
			this.btnDelRegion.TabIndex = 20;
			this.btnDelRegion.Text = "지역 제거";
			this.btnDelRegion.UseVisualStyleBackColor = true;
			this.btnDelRegion.Click += new System.EventHandler(this.btnDelRegion_Click);
			// 
			// btnAddRegion
			// 
			this.btnAddRegion.Location = new System.Drawing.Point(11, 518);
			this.btnAddRegion.Name = "btnAddRegion";
			this.btnAddRegion.Size = new System.Drawing.Size(86, 27);
			this.btnAddRegion.TabIndex = 19;
			this.btnAddRegion.Text = "지역 추가";
			this.btnAddRegion.UseVisualStyleBackColor = true;
			this.btnAddRegion.Click += new System.EventHandler(this.btnAddRegion_Click);
			// 
			// lstRegion
			// 
			this.lstRegion.FormattingEnabled = true;
			this.lstRegion.ItemHeight = 12;
			this.lstRegion.Location = new System.Drawing.Point(11, 136);
			this.lstRegion.Name = "lstRegion";
			this.lstRegion.Size = new System.Drawing.Size(218, 376);
			this.lstRegion.TabIndex = 18;
			this.lstRegion.SelectedIndexChanged += new System.EventHandler(this.lstRegion_SelectedIndexChanged);
			// 
			// lbRegion
			// 
			this.lbRegion.AutoSize = true;
			this.lbRegion.Location = new System.Drawing.Point(13, 115);
			this.lbRegion.Name = "lbRegion";
			this.lbRegion.Size = new System.Drawing.Size(29, 12);
			this.lbRegion.TabIndex = 17;
			this.lbRegion.Text = "지역";
			// 
			// lbImage
			// 
			this.lbImage.AutoSize = true;
			this.lbImage.Location = new System.Drawing.Point(13, 51);
			this.lbImage.Name = "lbImage";
			this.lbImage.Size = new System.Drawing.Size(69, 12);
			this.lbImage.TabIndex = 16;
			this.lbImage.Text = "배경 이미지";
			// 
			// btnSelectImage
			// 
			this.btnSelectImage.Location = new System.Drawing.Point(206, 66);
			this.btnSelectImage.Name = "btnSelectImage";
			this.btnSelectImage.Size = new System.Drawing.Size(24, 20);
			this.btnSelectImage.TabIndex = 15;
			this.btnSelectImage.Text = "...";
			this.btnSelectImage.UseVisualStyleBackColor = true;
			this.btnSelectImage.Click += new System.EventHandler(this.btnSelectImage_Click);
			// 
			// txtImage
			// 
			this.txtImage.BackColor = System.Drawing.Color.White;
			this.txtImage.Location = new System.Drawing.Point(12, 66);
			this.txtImage.Name = "txtImage";
			this.txtImage.Size = new System.Drawing.Size(188, 21);
			this.txtImage.TabIndex = 14;
			this.txtImage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImage_KeyPress);
			// 
			// lbTitle
			// 
			this.lbTitle.AutoSize = true;
			this.lbTitle.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
			this.lbTitle.Location = new System.Drawing.Point(11, 17);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new System.Drawing.Size(49, 19);
			this.lbTitle.TabIndex = 13;
			this.lbTitle.Text = "도구";
			// 
			// frmTool
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(234, 719);
			this.Controls.Add(this.btnEditCity);
			this.Controls.Add(this.btnNew);
			this.Controls.Add(this.btnLoad);
			this.Controls.Add(this.btnEdit);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.btnDelRegion);
			this.Controls.Add(this.btnAddRegion);
			this.Controls.Add(this.lstRegion);
			this.Controls.Add(this.lbRegion);
			this.Controls.Add(this.lbImage);
			this.Controls.Add(this.btnSelectImage);
			this.Controls.Add(this.txtImage);
			this.Controls.Add(this.lbTitle);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmTool";
			this.Text = "frmTool";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnEditCity;
		private System.Windows.Forms.Button btnNew;
		private System.Windows.Forms.Button btnLoad;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnDelRegion;
		private System.Windows.Forms.Button btnAddRegion;
		private System.Windows.Forms.ListBox lstRegion;
		private System.Windows.Forms.Label lbRegion;
		private System.Windows.Forms.Label lbImage;
		private System.Windows.Forms.Button btnSelectImage;
		private System.Windows.Forms.TextBox txtImage;
		private System.Windows.Forms.Label lbTitle;
	}
}
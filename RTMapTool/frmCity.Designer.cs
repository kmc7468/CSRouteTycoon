namespace RTMapTool
{
	partial class frmCity
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
			this.btnPop = new System.Windows.Forms.Button();
			this.btnPrice = new System.Windows.Forms.Button();
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnDel = new System.Windows.Forms.Button();
			this.btnAdd = new System.Windows.Forms.Button();
			this.lstCity = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.btnDes = new System.Windows.Forms.Button();
			this.btnLocation = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnPop
			// 
			this.btnPop.Location = new System.Drawing.Point(355, 413);
			this.btnPop.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnPop.Name = "btnPop";
			this.btnPop.Size = new System.Drawing.Size(104, 30);
			this.btnPop.TabIndex = 11;
			this.btnPop.Text = "인구 변경";
			this.btnPop.UseVisualStyleBackColor = true;
			this.btnPop.Click += new System.EventHandler(this.btnPop_Click);
			// 
			// btnPrice
			// 
			this.btnPrice.Location = new System.Drawing.Point(575, 413);
			this.btnPrice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnPrice.Name = "btnPrice";
			this.btnPrice.Size = new System.Drawing.Size(104, 30);
			this.btnPrice.TabIndex = 10;
			this.btnPrice.Text = "땅값 변경";
			this.btnPrice.UseVisualStyleBackColor = true;
			this.btnPrice.Click += new System.EventHandler(this.btnPrice_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.Location = new System.Drawing.Point(465, 413);
			this.btnEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(104, 30);
			this.btnEdit.TabIndex = 9;
			this.btnEdit.Text = "이름 변경";
			this.btnEdit.UseVisualStyleBackColor = true;
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnDel
			// 
			this.btnDel.Location = new System.Drawing.Point(574, 379);
			this.btnDel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnDel.Name = "btnDel";
			this.btnDel.Size = new System.Drawing.Size(104, 30);
			this.btnDel.TabIndex = 8;
			this.btnDel.Text = "제거";
			this.btnDel.UseVisualStyleBackColor = true;
			this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(465, 379);
			this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(104, 30);
			this.btnAdd.TabIndex = 7;
			this.btnAdd.Text = "추가";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// lstCity
			// 
			this.lstCity.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
			this.lstCity.Dock = System.Windows.Forms.DockStyle.Top;
			this.lstCity.Location = new System.Drawing.Point(0, 0);
			this.lstCity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.lstCity.Name = "lstCity";
			this.lstCity.Size = new System.Drawing.Size(682, 361);
			this.lstCity.TabIndex = 6;
			this.lstCity.UseCompatibleStateImageBehavior = false;
			this.lstCity.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "이름";
			this.columnHeader1.Width = 355;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "가격";
			this.columnHeader2.Width = 147;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "인구";
			this.columnHeader3.Width = 174;
			// 
			// btnDes
			// 
			this.btnDes.Location = new System.Drawing.Point(6, 379);
			this.btnDes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnDes.Name = "btnDes";
			this.btnDes.Size = new System.Drawing.Size(104, 30);
			this.btnDes.TabIndex = 12;
			this.btnDes.Text = "도시 설명 변경";
			this.btnDes.UseVisualStyleBackColor = true;
			this.btnDes.Click += new System.EventHandler(this.btnDes_Click);
			// 
			// btnLocation
			// 
			this.btnLocation.Location = new System.Drawing.Point(6, 413);
			this.btnLocation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
			this.btnLocation.Name = "btnLocation";
			this.btnLocation.Size = new System.Drawing.Size(104, 30);
			this.btnLocation.TabIndex = 13;
			this.btnLocation.Text = "도시 위치 변경";
			this.btnLocation.UseVisualStyleBackColor = true;
			this.btnLocation.Click += new System.EventHandler(this.btnLocation_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(116, 388);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(109, 12);
			this.label1.TabIndex = 14;
			this.label1.Text = "기본 값 : 빈 텍스트";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(116, 422);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(165, 12);
			this.label2.TabIndex = 15;
			this.label2.Text = "기본 값 : 도시 소속 지역 위치";
			// 
			// frmCity
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(682, 446);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnLocation);
			this.Controls.Add(this.btnDes);
			this.Controls.Add(this.btnPop);
			this.Controls.Add(this.btnPrice);
			this.Controls.Add(this.btnEdit);
			this.Controls.Add(this.btnDel);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.lstCity);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "frmCity";
			this.Text = "도시 편집";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnPop;
		private System.Windows.Forms.Button btnPrice;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Button btnDel;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.ListView lstCity;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.Button btnDes;
		private System.Windows.Forms.Button btnLocation;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
	}
}
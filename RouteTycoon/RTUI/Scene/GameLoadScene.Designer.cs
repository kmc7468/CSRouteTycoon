namespace RouteTycoon.RTUI
{
	partial class GameLoadScene
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
			this.components = new System.ComponentModel.Container();
			this.lbBack = new RouteTycoon.RTCore.TextButton();
			this.lbTitle = new System.Windows.Forms.Label();
			this.menuFiles = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.itemDelete = new System.Windows.Forms.ToolStripMenuItem();
			this.itemAllDelete = new System.Windows.Forms.ToolStripMenuItem();
			this.itemBuild = new System.Windows.Forms.ToolStripMenuItem();
			this.menuFiles.SuspendLayout();
			this.SuspendLayout();
			// 
			// lbBack
			// 
			this.lbBack.AutoSize = true;
			this.lbBack.BackColor = System.Drawing.Color.Transparent;
			this.lbBack.Font = new System.Drawing.Font("굴림", 30F);
			this.lbBack.ForeColor = System.Drawing.Color.White;
			this.lbBack.Location = new System.Drawing.Point(688, 401);
			this.lbBack.Name = "lbBack";
			this.lbBack.SelColor = System.Drawing.Color.Gray;
			this.lbBack.Size = new System.Drawing.Size(137, 40);
			this.lbBack.TabIndex = 6;
			this.lbBack.Text = "(back)";
			this.lbBack.Click += new System.EventHandler(this.lbBack_Click);
			// 
			// lbTitle
			// 
			this.lbTitle.AutoSize = true;
			this.lbTitle.BackColor = System.Drawing.Color.Transparent;
			this.lbTitle.Font = new System.Drawing.Font("굴림", 30F);
			this.lbTitle.ForeColor = System.Drawing.Color.White;
			this.lbTitle.Location = new System.Drawing.Point(100, 132);
			this.lbTitle.Name = "lbTitle";
			this.lbTitle.Size = new System.Drawing.Size(231, 40);
			this.lbTitle.TabIndex = 5;
			this.lbTitle.Text = "(gameload)";
			// 
			// menuFiles
			// 
			this.menuFiles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemDelete,
            this.itemAllDelete,
            this.itemBuild});
			this.menuFiles.Name = "contextMenuStrip1";
			this.menuFiles.Size = new System.Drawing.Size(153, 92);
			// 
			// itemDelete
			// 
			this.itemDelete.Name = "itemDelete";
			this.itemDelete.Size = new System.Drawing.Size(126, 22);
			this.itemDelete.Text = "삭제";
			this.itemDelete.Click += new System.EventHandler(this.itemDelete_Click);
			// 
			// itemAllDelete
			// 
			this.itemAllDelete.Name = "itemAllDelete";
			this.itemAllDelete.Size = new System.Drawing.Size(126, 22);
			this.itemAllDelete.Text = "모두 삭제";
			this.itemAllDelete.Click += new System.EventHandler(this.itemAllDelete_Click);
			// 
			// itemBuild
			// 
			this.itemBuild.Name = "itemBuild";
			this.itemBuild.Size = new System.Drawing.Size(152, 22);
			this.itemBuild.Text = "빌드";
			this.itemBuild.Click += new System.EventHandler(this.itemBuild_Click);
			// 
			// GameLoadScene
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.Black;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.Controls.Add(this.lbBack);
			this.Controls.Add(this.lbTitle);
			this.DoubleBuffered = true;
			this.Name = "GameLoadScene";
			this.Size = new System.Drawing.Size(879, 546);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.GameLoadScene_Paint);
			this.Resize += new System.EventHandler(this.GameLoadScene_Resize);
			this.menuFiles.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private RTCore.TextButton lbBack;
		private System.Windows.Forms.Label lbTitle;
		private System.Windows.Forms.ContextMenuStrip menuFiles;
		private System.Windows.Forms.ToolStripMenuItem itemDelete;
		private System.Windows.Forms.ToolStripMenuItem itemAllDelete;
		private System.Windows.Forms.ToolStripMenuItem itemBuild;
	}
}

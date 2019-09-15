namespace RTResourceMaker.UI
{
    partial class setting
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("기본");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("글꼴");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("프로그램", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("기본");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("이미지 탭");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("사운드 탭");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("에디터", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5,
            treeNode6});
            this.lbTitle = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.myPanel = new System.Windows.Forms.Panel();
            this.treeSettingCategory = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbTitle.Location = new System.Drawing.Point(60, 90);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(54, 21);
            this.lbTitle.TabIndex = 10;
            this.lbTitle.Text = "설정";
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Location = new System.Drawing.Point(87, 314);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.button3_Click);
            // 
            // myPanel
            // 
            this.myPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.myPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.myPanel.Location = new System.Drawing.Point(200, 160);
            this.myPanel.Name = "myPanel";
            this.myPanel.Size = new System.Drawing.Size(350, 184);
            this.myPanel.TabIndex = 23;
            // 
            // treeSettingCategory
            // 
            this.treeSettingCategory.BackColor = System.Drawing.Color.WhiteSmoke;
            this.treeSettingCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeSettingCategory.Location = new System.Drawing.Point(87, 160);
            this.treeSettingCategory.Name = "treeSettingCategory";
            treeNode1.Name = "programDefault";
            treeNode1.Text = "기본";
            treeNode2.Name = "programFont";
            treeNode2.Text = "글꼴";
            treeNode3.Name = "노드0";
            treeNode3.Text = "프로그램";
            treeNode4.Name = "editDefault";
            treeNode4.Text = "기본";
            treeNode5.Name = "editImageTab";
            treeNode5.Text = "이미지 탭";
            treeNode6.Name = "editSoundTab";
            treeNode6.Text = "사운드 탭";
            treeNode7.Name = "노드3";
            treeNode7.Text = "에디터";
            this.treeSettingCategory.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode7});
            this.treeSettingCategory.ShowLines = false;
            this.treeSettingCategory.Size = new System.Drawing.Size(100, 140);
            this.treeSettingCategory.TabIndex = 24;
            this.treeSettingCategory.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeSettingCategory_AfterSelect);
            // 
            // setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.myPanel);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lbTitle);
            this.Controls.Add(this.treeSettingCategory);
            this.DoubleBuffered = true;
            this.Name = "setting";
            this.Size = new System.Drawing.Size(564, 401);
            this.Load += new System.EventHandler(this.setting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel myPanel;
        private System.Windows.Forms.TreeView treeSettingCategory;
    }
}

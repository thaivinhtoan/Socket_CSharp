namespace ProxyServer
{
    partial class ProxyServer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProxyServer));
            this.tbBlockLink = new System.Windows.Forms.TextBox();
            this.btAdd = new System.Windows.Forms.Button();
            this.btRemove = new System.Windows.Forms.Button();
            this.lvBackList = new System.Windows.Forms.ListView();
            this.lbBlackList = new System.Windows.Forms.Label();
            this.lbShow = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btGuide = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // tbBlockLink
            // 
            this.tbBlockLink.Location = new System.Drawing.Point(587, 306);
            this.tbBlockLink.Name = "tbBlockLink";
            this.tbBlockLink.Size = new System.Drawing.Size(201, 20);
            this.tbBlockLink.TabIndex = 0;
            // 
            // btAdd
            // 
            this.btAdd.Location = new System.Drawing.Point(587, 347);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(109, 23);
            this.btAdd.TabIndex = 2;
            this.btAdd.Text = "ADD";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.BtAdd_Click);
            // 
            // btRemove
            // 
            this.btRemove.Location = new System.Drawing.Point(713, 347);
            this.btRemove.Name = "btRemove";
            this.btRemove.Size = new System.Drawing.Size(75, 23);
            this.btRemove.TabIndex = 3;
            this.btRemove.Text = "REMOVE";
            this.btRemove.UseVisualStyleBackColor = true;
            this.btRemove.Click += new System.EventHandler(this.BtRemove_Click);
            // 
            // lvBackList
            // 
            this.lvBackList.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvBackList.Location = new System.Drawing.Point(587, 43);
            this.lvBackList.Name = "lvBackList";
            this.lvBackList.Size = new System.Drawing.Size(201, 247);
            this.lvBackList.TabIndex = 4;
            this.lvBackList.UseCompatibleStateImageBehavior = false;
            this.lvBackList.View = System.Windows.Forms.View.List;
            // 
            // lbBlackList
            // 
            this.lbBlackList.AutoSize = true;
            this.lbBlackList.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBlackList.Location = new System.Drawing.Point(582, 12);
            this.lbBlackList.Name = "lbBlackList";
            this.lbBlackList.Size = new System.Drawing.Size(91, 22);
            this.lbBlackList.TabIndex = 5;
            this.lbBlackList.Text = "BlackList";
            // 
            // lbShow
            // 
            this.lbShow.AutoSize = true;
            this.lbShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbShow.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbShow.Location = new System.Drawing.Point(12, 12);
            this.lbShow.Name = "lbShow";
            this.lbShow.Size = new System.Drawing.Size(84, 22);
            this.lbShow.TabIndex = 6;
            this.lbShow.Text = "Connect";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 43);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(569, 327);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // btGuide
            // 
            this.btGuide.Location = new System.Drawing.Point(12, 347);
            this.btGuide.Name = "btGuide";
            this.btGuide.Size = new System.Drawing.Size(75, 23);
            this.btGuide.TabIndex = 8;
            this.btGuide.Text = "GUIDE";
            this.btGuide.UseVisualStyleBackColor = true;
            this.btGuide.Click += new System.EventHandler(this.BtGuide_Click);
            // 
            // ProxyServer
            // 
            this.AcceptButton = this.btAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 381);
            this.Controls.Add(this.btGuide);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbShow);
            this.Controls.Add(this.lbBlackList);
            this.Controls.Add(this.lvBackList);
            this.Controls.Add(this.btRemove);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.tbBlockLink);
            this.Name = "ProxyServer";
            this.Text = "ProxyServer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ProxyServer_FormClosed);
            this.Load += new System.EventHandler(this.ProxyServer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbBlockLink;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button btRemove;
        private System.Windows.Forms.ListView lvBackList;
        private System.Windows.Forms.Label lbBlackList;
        private System.Windows.Forms.Label lbShow;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btGuide;
    }
}


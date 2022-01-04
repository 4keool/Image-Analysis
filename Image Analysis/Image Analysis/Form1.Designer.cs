
namespace Image_Analysis
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.TAB1_FILE_EXPLORER_TREEVIEW = new System.Windows.Forms.TreeView();
            this.FILE_EXPLORER_IMAGELIST = new System.Windows.Forms.ImageList(this.components);
            this.TAB1_FILE_LISTVIEW = new System.Windows.Forms.ListView();
            this.TAB1_TEXTBOX_RGB = new System.Windows.Forms.TextBox();
            this.TAB1_PICTUREBOX = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.TAB1_CONTEXTMENUSTRIP = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TAB1_PICTUREBOX)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(1, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1100, 700);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.splitContainer1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1092, 672);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.VSplit;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.TAB1_TEXTBOX_RGB);
            this.splitContainer1.Panel2.Controls.Add(this.TAB1_PICTUREBOX);
            this.splitContainer1.Size = new System.Drawing.Size(1086, 666);
            this.splitContainer1.SplitterDistance = 362;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Cursor = System.Windows.Forms.Cursors.HSplit;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.TAB1_FILE_EXPLORER_TREEVIEW);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.TAB1_FILE_LISTVIEW);
            this.splitContainer2.Size = new System.Drawing.Size(362, 666);
            this.splitContainer2.SplitterDistance = 454;
            this.splitContainer2.TabIndex = 0;
            // 
            // TAB1_FILE_EXPLORER_TREEVIEW
            // 
            this.TAB1_FILE_EXPLORER_TREEVIEW.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.TAB1_FILE_EXPLORER_TREEVIEW.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TAB1_FILE_EXPLORER_TREEVIEW.ImageIndex = 0;
            this.TAB1_FILE_EXPLORER_TREEVIEW.ImageList = this.FILE_EXPLORER_IMAGELIST;
            this.TAB1_FILE_EXPLORER_TREEVIEW.Location = new System.Drawing.Point(0, 0);
            this.TAB1_FILE_EXPLORER_TREEVIEW.Name = "TAB1_FILE_EXPLORER_TREEVIEW";
            this.TAB1_FILE_EXPLORER_TREEVIEW.SelectedImageIndex = 0;
            this.TAB1_FILE_EXPLORER_TREEVIEW.Size = new System.Drawing.Size(362, 454);
            this.TAB1_FILE_EXPLORER_TREEVIEW.TabIndex = 0;
            this.TAB1_FILE_EXPLORER_TREEVIEW.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.TAB1_FILE_EXPLORER_TREEVIEW_BeforeCollapse);
            this.TAB1_FILE_EXPLORER_TREEVIEW.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.TAB1_FILE_EXPLORER_TREEVIEW_BeforeExpand);
            this.TAB1_FILE_EXPLORER_TREEVIEW.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TAB1_FILE_EXPLORER_TREEVIEW_NodeMouseClick);
            this.TAB1_FILE_EXPLORER_TREEVIEW.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TAB1_FILE_EXPLORER_TREEVIEW_MouseClick);
            // 
            // FILE_EXPLORER_IMAGELIST
            // 
            this.FILE_EXPLORER_IMAGELIST.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.FILE_EXPLORER_IMAGELIST.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("FILE_EXPLORER_IMAGELIST.ImageStream")));
            this.FILE_EXPLORER_IMAGELIST.TransparentColor = System.Drawing.Color.Transparent;
            this.FILE_EXPLORER_IMAGELIST.Images.SetKeyName(0, "Windows-Client.ico");
            this.FILE_EXPLORER_IMAGELIST.Images.SetKeyName(1, "Ssd.ico");
            this.FILE_EXPLORER_IMAGELIST.Images.SetKeyName(2, "Folder.ico");
            this.FILE_EXPLORER_IMAGELIST.Images.SetKeyName(3, "Folder-Open.ico");
            this.FILE_EXPLORER_IMAGELIST.Images.SetKeyName(4, "Usb-Connected.ico");
            this.FILE_EXPLORER_IMAGELIST.Images.SetKeyName(5, "Picture.ico");
            // 
            // TAB1_FILE_LISTVIEW
            // 
            this.TAB1_FILE_LISTVIEW.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.TAB1_FILE_LISTVIEW.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TAB1_FILE_LISTVIEW.HideSelection = false;
            this.TAB1_FILE_LISTVIEW.Location = new System.Drawing.Point(0, 0);
            this.TAB1_FILE_LISTVIEW.Name = "TAB1_FILE_LISTVIEW";
            this.TAB1_FILE_LISTVIEW.Size = new System.Drawing.Size(362, 208);
            this.TAB1_FILE_LISTVIEW.SmallImageList = this.FILE_EXPLORER_IMAGELIST;
            this.TAB1_FILE_LISTVIEW.TabIndex = 0;
            this.TAB1_FILE_LISTVIEW.UseCompatibleStateImageBehavior = false;
            this.TAB1_FILE_LISTVIEW.MouseClick += new System.Windows.Forms.MouseEventHandler(this.TAB1_FILE_LISTVIEW_MouseClick);
            // 
            // TAB1_TEXTBOX_RGB
            // 
            this.TAB1_TEXTBOX_RGB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TAB1_TEXTBOX_RGB.Location = new System.Drawing.Point(289, 325);
            this.TAB1_TEXTBOX_RGB.Name = "TAB1_TEXTBOX_RGB";
            this.TAB1_TEXTBOX_RGB.ReadOnly = true;
            this.TAB1_TEXTBOX_RGB.Size = new System.Drawing.Size(90, 16);
            this.TAB1_TEXTBOX_RGB.TabIndex = 1;
            this.TAB1_TEXTBOX_RGB.TabStop = false;
            // 
            // TAB1_PICTUREBOX
            // 
            this.TAB1_PICTUREBOX.Cursor = System.Windows.Forms.Cursors.Cross;
            this.TAB1_PICTUREBOX.Location = new System.Drawing.Point(0, 0);
            this.TAB1_PICTUREBOX.Name = "TAB1_PICTUREBOX";
            this.TAB1_PICTUREBOX.Size = new System.Drawing.Size(720, 635);
            this.TAB1_PICTUREBOX.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.TAB1_PICTUREBOX.TabIndex = 0;
            this.TAB1_PICTUREBOX.TabStop = false;
            this.TAB1_PICTUREBOX.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TAB1_PICTUREBOX_MouseMove);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1092, 672);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // TAB1_CONTEXTMENUSTRIP
            // 
            this.TAB1_CONTEXTMENUSTRIP.Name = "TAB1_CONTEXTMENUSTRIP";
            this.TAB1_CONTEXTMENUSTRIP.Size = new System.Drawing.Size(61, 4);
            this.TAB1_CONTEXTMENUSTRIP.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.TAB1_CONTEXTMENUSTRIP_ItemClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1101, 703);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TAB1_PICTUREBOX)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TreeView TAB1_FILE_EXPLORER_TREEVIEW;
        private System.Windows.Forms.ListView TAB1_FILE_LISTVIEW;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ImageList FILE_EXPLORER_IMAGELIST;
        private System.Windows.Forms.TextBox TAB1_TEXTBOX_RGB;
        private System.Windows.Forms.PictureBox TAB1_PICTUREBOX;
        private System.Windows.Forms.ContextMenuStrip TAB1_CONTEXTMENUSTRIP;
    }
}


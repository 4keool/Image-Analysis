using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Image_Analysis
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckDrives();

            // 첫번째 노드 확장
            TAB1_FILE_EXPLORER_TREEVIEW.Nodes[0].Expand();

            TAB1_FILE_LISTVIEW.View = View.Tile;
            TAB1_FILE_LISTVIEW.TileSize = new Size(100, 100);

            // 행단위 선택 가능
            TAB1_FILE_LISTVIEW.FullRowSelect = true;
        }

        void CheckDrives()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo dname in allDrives)
            {
                TreeNode rootNode;
                rootNode = new TreeNode(dname.Name);
                switch (dname.DriveType)
                {
                    case DriveType.Fixed:
                        {
                            if (dname.Name == @"C:\")
                                ChangeImageIndex(rootNode, 0);
                            else
                                ChangeImageIndex(rootNode, 1);
                            break;
                        }
                    case DriveType.Removable:
                        {
                            ChangeImageIndex(rootNode, 12);
                            break;
                        }
                    default:
                        {
                            continue;
                        }
                }
                TAB1_FILE_EXPLORER_TREEVIEW.Nodes.Add(rootNode);
                CheckDirectory(rootNode);
            }
        }

        void ChangeImageIndex(TreeNode dirNode, int idx)
        {
            dirNode.ImageIndex = idx;
            dirNode.SelectedImageIndex = idx;
        }

        void CheckDirectory(TreeNode dirNode)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(dirNode.FullPath);
                foreach (DirectoryInfo dirItem in dir.GetDirectories())
                {
                    if (dirItem.Name.CompareTo("Windows") == 0)
                        continue;

                    TreeNode newNode = new TreeNode(dirItem.Name);
                    if (CheckDirectoryBelow(dirItem))
                    {
                        ChangeImageIndex(newNode, 2);
                        newNode.Nodes.Add("");
                    }
                    else
                        ChangeImageIndex(newNode, 3);
                    dirNode.Nodes.Add(newNode);
                }
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("경로를 찾을 수 없습니다. 해당 디렉터리 제거");
                dirNode.Remove();
            }
            catch (Exception ex)
            {
                MessageBox.Show("에러 발생 : " + ex.Message);
            }
        }

        bool CheckDirectoryBelow(DirectoryInfo ParentDir)
        {
            if ((ParentDir.Attributes & FileAttributes.System) == FileAttributes.System)
                return false;
            if ((ParentDir.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                return false;
            if (ParentDir.GetDirectories().Length > 0)
                return true;
            else
                return false;
        }

        private void TAB1_FILE_EXPLORER_TREEVIEW_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            //if (e.Node.Nodes[0].Text == "*")
            //{
            ChangeImageIndex(e.Node, 2);
            //}
        }

        private void TAB1_FILE_EXPLORER_TREEVIEW_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            //if(e.Node.Nodes[0].Text == "")
            //{
            e.Node.Nodes.Clear();
            ChangeImageIndex(e.Node, 3);
            CheckDirectory(e.Node);
            //}
        }

        private void TAB1_FILE_EXPLORER_TREEVIEW_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            SettingListView(e.Node);
        }

        private void DelayManual(int iDelay)
        {
            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, iDelay * 1000);

            DateTime AfterTime = ThisMoment.Add(duration);
            while(true)
            {
                ThisMoment = DateTime.Now;
                System.Windows.Forms.Application.DoEvents();

                if (AfterTime <= ThisMoment) break;
            }
        }

        private void TAB1_PICTUREBOX_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.TAB1_PICTUREBOX.Image != null)
            {
                try
                {
                    Bitmap bitmap = new Bitmap(this.TAB1_PICTUREBOX.Image);
                    Color color = bitmap.GetPixel(e.X, e.Y);
                    this.TAB1_TEXTBOX_RGB.Location = new Point(e.X, e.Y);
                    this.TAB1_TEXTBOX_RGB.Text = $"R : {color.R} G : {color.G} B : {color.B}";
                    this.TAB1_TEXTBOX_RGB.Width = this.TAB1_TEXTBOX_RGB.PreferredSize.Width;

                    DelayManual(5000);
                }
                catch (Exception)
                {
                }
            }
        }

        private void TAB1_FILE_LISTVIEW_MouseClick(object sender, MouseEventArgs e)
        {
            //string szFile = TAB1_FILE_EXPLORER_TREEVIEW.SelectedNode.FullPath + "\\" + TAB1_FILE_LISTVIEW.SelectedItems[0].Text;

            //FileInfo fileInfo = new FileInfo(szFile);
            //if (fileInfo.Exists)
            //{
            //    TAB1_PICTUREBOX.Image = Image.FromFile(szFile);
            //}

            if (e.Button.Equals(MouseButtons.Left))
            {
                string szFile = TAB1_FILE_EXPLORER_TREEVIEW.SelectedNode.FullPath + "\\" + TAB1_FILE_LISTVIEW.SelectedItems[0].Text;

                FileInfo fileInfo = new FileInfo(szFile);
                if (fileInfo.Exists)
                {
                    TAB1_PICTUREBOX.Image = Image.FromFile(szFile);
                }
            }
            else if (e.Button.Equals(MouseButtons.Right))
            {
                TAB1_CONTEXTMENUSTRIP.Items.Clear();
                AddMenuItem(TAB1_CONTEXTMENUSTRIP, "RUn");
                AddMenuItem(TAB1_CONTEXTMENUSTRIP, "CAncel");
                AddMenuItem(TAB1_CONTEXTMENUSTRIP, "COpy");
                AddMenuItem(TAB1_CONTEXTMENUSTRIP, "DElete");

                TAB1_CONTEXTMENUSTRIP.Show(TAB1_FILE_LISTVIEW, e.Location);
            }
        }

        private void SettingListView(TreeNode dirNode)
        {
            try
            {
                int Count = 0;
                float thumbnailSize = 70;
                Image thumbnail;
                ImageList myImageList;

                // 기존의 목록 제거
                TAB1_FILE_LISTVIEW.Items.Clear();
                TAB1_FILE_LISTVIEW.Columns.Clear();

                // 디렉토리에 존재하는 파일목록 보여주기
                myImageList = new ImageList();
                //FileInfo[] files = CheckImageFileNum(dirNode.FullPath);

                DirectoryInfo dir = new DirectoryInfo(dirNode.FullPath);
                FileInfo[] fis = dir.GetFiles();
                if (CheckImageFileNum(fis) >= 5)
                {
                    TAB1_FILE_LISTVIEW.View = View.Details;
                    TAB1_FILE_LISTVIEW.Columns.Add("파일명", 100, HorizontalAlignment.Left);
                    TAB1_FILE_LISTVIEW.Columns.Add("크기", 150, HorizontalAlignment.Left);
                    TAB1_FILE_LISTVIEW.Columns.Add("날짜", 200, HorizontalAlignment.Left);
                }
                else
                {
                    TAB1_FILE_LISTVIEW.View = View.Tile;
                    TAB1_FILE_LISTVIEW.TileSize = new Size(100, 100);
                }


                foreach (FileInfo fileinfo in fis)
                {
                    if (fileinfo.Extension == ".bmp" || fileinfo.Extension == ".png" || fileinfo.Extension == ".jpg")
                    {
                        if (TAB1_FILE_LISTVIEW.View == View.Details)
                        {
                            //detail list;
                            ListViewItem lvi = new ListViewItem(fileinfo.Name, 16);
                            lvi.SubItems.Add(fileinfo.Length.ToString() + " Byte");
                            lvi.SubItems.Add(fileinfo.LastWriteTime.ToString());
                            TAB1_FILE_LISTVIEW.Items.Add(lvi);
                        }
                        else
                        {
                            // thumbnail list
                            thumbnail = MakeThumbnail(fileinfo.FullName, thumbnailSize);
                            if (thumbnail != null)
                            {
                                myImageList.ImageSize = new Size((int)thumbnailSize, (int)thumbnailSize);
                                myImageList.Images.Add(thumbnail);
                                TAB1_FILE_LISTVIEW.LargeImageList = myImageList;
                                TAB1_FILE_LISTVIEW.Items.Add(fileinfo.Name);
                                TAB1_FILE_LISTVIEW.Items[Count].ImageIndex = Count;
                                Count++;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("에러 발생 : " + ex.Message);
            }
        }

        private int CheckImageFileNum(FileInfo[] fis)
        {
            int res = 0;

            foreach (FileInfo fi in fis)
            {
                if (fi.Extension == ".bmp" || fi.Extension == ".jpg" || fi.Extension == ".png")
                    res++;
            }
            return res;
        }

        Image MakeThumbnail(string szPath, float fThumbnailSize)
        {
            Image Original, thumbnail;
            float fResizeRatio;
            float fOri_w, fOri_h, fThum_w, fThum_h;

            FileInfo file = new FileInfo(szPath);
            if (file.Exists)
            {
                Original = Image.FromFile(szPath);

                fOri_w = fThumbnailSize / Original.Width;
                fOri_h = fThumbnailSize / Original.Height;
                fResizeRatio = Math.Min(fOri_w, fOri_h);
                fThum_w = Original.Width * fResizeRatio;
                fThum_h = Original.Height * fResizeRatio;

                thumbnail = new Bitmap(Original, (int)fThum_w, (int)fThum_h);

                return thumbnail;
            }
            return null;
        }

        private void TAB1_FILE_EXPLORER_TREEVIEW_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Right))
            {
                TAB1_CONTEXTMENUSTRIP.Items.Clear();
                AddMenuItem(TAB1_CONTEXTMENUSTRIP, "Run");
                AddMenuItem(TAB1_CONTEXTMENUSTRIP, "Cancel");
                AddMenuItem(TAB1_CONTEXTMENUSTRIP, "Copy");
                AddMenuItem(TAB1_CONTEXTMENUSTRIP, "Delete");

                TAB1_CONTEXTMENUSTRIP.Show(TAB1_FILE_EXPLORER_TREEVIEW, e.Location);
            }
        }

        private ToolStripMenuItem AddMenuItem(ContextMenuStrip cm, string text)
        {
            ToolStripMenuItem item = new ToolStripMenuItem(text);
            cm.Items.Add(item);
            return item;
        }

        private void TAB1_CONTEXTMENUSTRIP_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if(e.ClickedItem.Text.Equals("DElete"))
            {
                string szFile = TAB1_FILE_EXPLORER_TREEVIEW.SelectedNode.FullPath + "\\" + TAB1_FILE_LISTVIEW.SelectedItems[0].Text;
                if(File.Exists(szFile))
                {
                    File.Delete(szFile);
                }
            }
        }
    }
}

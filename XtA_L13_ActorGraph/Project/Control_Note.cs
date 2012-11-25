using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

namespace Xenon.Aims.ActorGraph
{
    public partial class Control_Note : UserControl
    {


        #region 生成と破棄
        //────────────────────────────────────────

        public Control_Note()
        {
            InitializeComponent();
            this.Painter = new PainterImpl();
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 表示される行数。
        /// </summary>
        /// <returns></returns>
        public int GetRow_Viewed()
        {
            int row=0;

            if (this.Parent is Control_Perspective)
            {
                Control_Perspective perspective1 = (Control_Perspective)this.Parent;

                if (perspective1.Parent is Form1)
                {
                    Form1 form1 = (Form1)perspective1.Parent;

                    row = this.Height / form1.Document.HeightLine;

                    if (0 < this.Height % form1.Document.HeightLine)
                    {
                        //端数
                        row++;
                    }
                }
            }

            return row;
        }

        //────────────────────────────────────────
        #endregion



        #region イベントハンドラー
        //────────────────────────────────────────

        private void Control_Note_Paint(object sender, PaintEventArgs e)
        {
            if (this.Parent is Control_Perspective)
            {
                Control_Perspective perspective1 = (Control_Perspective)this.Parent;

                if (perspective1.Parent is Form1)
                {
                    Form1 form1 = (Form1)perspective1.Parent;

                    Graphics g = e.Graphics;

                    if (null != this.Painter)
                    {
                        this.Painter.Paint(
                            g,
                            this.Width,
                            this.Height,
                            form1.Document.RowBeginview,
                            this.GetRow_Viewed(),
                            form1.Document
                            );
                    }

                    g.DrawString("開始行"+form1.Document.RowBeginview, this.Font, Brushes.Black, new Point());
                }

            }
            else
            {
                //ビジュアルエディターなど
            }
        }

        private void Control_Note_Load(object sender, EventArgs e)
        {
            Control parent = this.Parent;
            if (parent is Control_Perspective)
            {
                Control_Perspective perspective1 = (Control_Perspective)parent;

                if (perspective1.Parent is Form1)
                {
                    Form1 form1 = (Form1)perspective1.Parent;

                    form1.Document.Font = this.Font;
                    form1.Document.LoadImage();
                }
            }
        }

        //────────────────────────────────────────

        private void Control_Note_DragEnter(object sender, DragEventArgs e)
        {
            // ファイルドロップ
            if (
                e.Data.GetDataPresent(DataFormats.FileDrop)//ファイルパス
                ||
                e.Data.GetDataPresent(DataFormats.StringFormat)//文字列
                )
            {
                // ドロップした時の効果を Copy として見えるようにします。
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
            }
        }

        private void Control_Note_DragDrop(object sender, DragEventArgs e)
        {
            Point locationMouse = this.PointToClient(new Point(e.X, e.Y));

            string droppedText = null;
            string fileSave = "";
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                // ファイルドロップ
                string[] fileNames = (string[])e.Data.GetData(DataFormats.FileDrop, false);

                if (this.Bounds.Contains(locationMouse.X, locationMouse.Y))
                {
                    foreach (string fileName in fileNames)
                    {
                        //System.Console.WriteLine(fileName);

                        droppedText = File.ReadAllText(fileName);
                        fileSave = fileName;

                        //最初のファイルだけ対応
                        break;
                    }
                }
            }
            else if (e.Data.GetDataPresent(DataFormats.StringFormat))
            {
                // 文字列として読み取れる形式のデータがドロップされた場合、
                // テキストボックスに、その文字列データを表示します。
                if (this.Bounds.Contains(locationMouse.X, locationMouse.Y))
                {
                    droppedText = (string)e.Data.GetData(typeof(string));
                    //System.Console.WriteLine(droppedText);
                }
            }
            else
            {
                //log_Method.WriteDebug_ToConsole("ファイル以外のものをドロップした。");
            }

            if (null != droppedText)
            {
                System.Console.WriteLine("ドロップがあったとき。");

                if (this.Parent is Control_Perspective)
                {
                    Control_Perspective perspective = (Control_Perspective)this.Parent;

                    if (perspective.Parent is Form1)
                    {
                        Form1 form1 = (Form1)perspective.Parent;
                        form1.Document = DocumentImpl.Import(droppedText, fileSave, form1.Document);
                    }
                }

                this.Refresh();
            }

        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private PainterImpl painter;

        public PainterImpl Painter
        {
            get
            {
                return this.painter;
            }
            set
            {
                this.painter = value;
            }
        }

        //────────────────────────────────────────
        #endregion


    }
}

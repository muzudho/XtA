using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Xenon.Aims.ActorGraph
{

    [Serializable]
    public class DocumentImpl
    {



        #region 用意
        //────────────────────────────────────────

        public const int WIDTH_CELL = 20;

        //────────────────────────────────────────
        #endregion



        #region 生成と破棄
        //────────────────────────────────────────

        public DocumentImpl()
        {
            this.Font = new Font("MS ゴシック", 18);
            this.heightLine = 20;
            this.Lines = new List<LineImpl>();

            this.FileSave = "";


            //this.Lines.Add(new LineImpl(new DecorationImpl[] { }, this));//空行
            //this.Lines.Add(new LineImpl(new DecorationImpl[] { new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, "boot") }, this));
            //this.Lines.Add(new LineImpl(new DecorationImpl[] { new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, EnumShape.ArrowMiddle) }, this));//矢印の尾。
            //this.Lines.Add(new LineImpl(new DecorationImpl[] { new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, EnumShape.ArrowBranch), new DecorationImpl(EnumNode.Scene, EnumShape.ArrowPointer1), new DecorationImpl(EnumNode.Scene, EnumShape.ArrowPointer2), new DecorationImpl(EnumNode.Scene, EnumShape.ArrowPointer3), new DecorationImpl(EnumNode.Scene, "frame") }, this));//frameシーン追加。
            //this.Lines.Add(new LineImpl(new DecorationImpl[] { new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, EnumShape.ArrowMiddle), new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, EnumShape.Joint) }, this));//シーンのつなぎ
            //this.Lines.Add(new LineImpl(new DecorationImpl[] { new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, EnumShape.ArrowMiddle), new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, "logo") }, this));
            //this.Lines.Add(new LineImpl(new DecorationImpl[] { new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, EnumShape.ArrowMiddle), new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, EnumShape.Joint) }, this));//シーンのつなぎ
            //this.Lines.Add(new LineImpl(new DecorationImpl[] { new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, EnumShape.ArrowMiddle), new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, "title") }, this));
            //this.Lines.Add(new LineImpl(new DecorationImpl[] { new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, EnumShape.ArrowMiddle), new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, EnumShape.Joint) }, this));//シーンのつなぎ
            //this.Lines.Add(new LineImpl(new DecorationImpl[] { new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, EnumShape.ArrowMiddle), new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, "game") }, this));
            //this.Lines.Add(new LineImpl(new DecorationImpl[] { new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, EnumShape.ArrowMiddle), new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, EnumShape.Joint), new DecorationImpl(EnumNode.Actor, EnumShape.ArrowMiddle) }, this));//シーンのつなぎ
            //this.Lines.Add(new LineImpl(new DecorationImpl[] { new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, EnumShape.ArrowMiddle), new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, EnumShape.Joint), new DecorationImpl(EnumNode.Actor, EnumShape.ArrowCurve), new DecorationImpl(EnumNode.Actor, EnumShape.ArrowPointer1), new DecorationImpl(EnumNode.Actor, EnumShape.ArrowPointer2), new DecorationImpl(EnumNode.Actor, EnumShape.ArrowPointer3), new DecorationImpl(EnumNode.Scene, "padlistener") }, this));//アクター生成
            //this.Lines.Add(new LineImpl(new DecorationImpl[] { new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, EnumShape.ArrowMiddle), new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, EnumShape.Joint) }, this));//シーンのつなぎ
            //this.Lines.Add(new LineImpl(new DecorationImpl[] { new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, EnumShape.ArrowMiddle), new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, "gameover") }, this));
            //this.Lines.Add(new LineImpl(new DecorationImpl[] { new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, EnumShape.ArrowMiddle) }, this));
            //this.Lines.Add(new LineImpl(new DecorationImpl[] { new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, EnumShape.Space), new DecorationImpl(EnumNode.Scene, EnumShape.ArrowCurve), new DecorationImpl(EnumNode.Scene, EnumShape.ArrowPointer1), new DecorationImpl(EnumNode.Scene, EnumShape.ArrowPointer2), new DecorationImpl(EnumNode.Scene, EnumShape.ArrowPointer3), new DecorationImpl(EnumNode.Scene, "frame0") }, this));//frame0シーン追加。
        }

        public static DocumentImpl Import(string text, string fileSave, DocumentImpl oldDocument_OrNull)
        {
            DocumentImpl document = new DocumentImpl();
            document.Lines.Clear();

            string[] lines = text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            foreach (string line in lines)
            {
                LineImpl lineElement = LineImpl.Import(line, document);
                document.Lines.Add(lineElement);
            }

            document.FileSave = fileSave;

            if (null != oldDocument_OrNull)
            {
                document.Font = oldDocument_OrNull.Font;
                document.Image = oldDocument_OrNull.Image;
                document.HeightLine = oldDocument_OrNull.HeightLine;
            }
            return document;
        }

        //────────────────────────────────────────
        #endregion




        #region アクション
        //────────────────────────────────────────

        public void LoadImage()
        {
            string filepath = Path.Combine(Application.StartupPath, "img/ActorGraph.png");

            //ビジュアルエディターではファイルパスが別の場所になる。
            if (File.Exists(filepath))
            {
                this.Image = Image.FromFile(filepath);
            }
            else
            {
                //ダミー画像。
                this.Image = new Bitmap(1, 1);
            }
        }

        //────────────────────────────────────────

        /// <summary>
        /// 
        /// </summary>
        public Brush CreateBrush(EnumNode enumNode)
        {
            Brush result;

            switch (enumNode)
            {
                case EnumNode.Scene:
                    //シーン用ブラシ。
                    result = new SolidBrush(Color.FromArgb(255, 192, 0, 0));
                    break;
                case EnumNode.Actor:
                    //アクター用ブラシ。
                    result = new SolidBrush(Color.FromArgb(255, 179, 183, 0));
                    break;
                case EnumNode.Thread:
                    //スレッド用ブラシ。
                    result = new SolidBrush(Color.FromArgb(255, 64, 0, 164));
                    break;
                case EnumNode.Comment:
                    result = new SolidBrush(Color.FromArgb(255, 192, 192, 192));
                    break;
                case EnumNode.Error:
                default:
                    result = new SolidBrush(Color.FromArgb(255, 212, 0, 0));
                    break;
            }

            return result;
        }

        //────────────────────────────────────────

        /// <summary>
        /// 
        /// </summary>
        public Pen CreatePen(EnumNode enumNode)
        {
            Pen result;

            switch(enumNode)
            {
                case EnumNode.Scene:
                    //シーン用ペン。
                    result = new Pen(Color.FromArgb(255, 192, 0, 0));
                    break;
                case EnumNode.Actor:
                    //アクター用ペン。
                    result = new Pen(Color.FromArgb(255, 179, 183, 0));
                    break;
                case EnumNode.Thread:
                    //スレッド用ペン。
                    result = new Pen(Color.FromArgb(255,  64, 0, 164));
                    break;
                case EnumNode.Comment:
                    result = new Pen(Color.FromArgb(255, 192, 192, 192));
                    break;
                case EnumNode.Error:
                default:
                    result = new Pen(Color.FromArgb(255, 212, 0, 0));
                    break;
            }
            return result;
        }

        //────────────────────────────────────────

        /// <summary>
        /// グリッド用ペン。
        /// </summary>
        public Pen CreatePenGrid()
        {
            return new Pen(Color.FromArgb(255, 241, 241, 241));
        }

        //────────────────────────────────────────
        #endregion





        #region プロパティー
        //────────────────────────────────────────

        private int rowBeginview;

        /// <summary>
        /// 先頭行。先頭を 0 とする。
        /// </summary>
        public int RowBeginview
        {
            get
            {
                return this.rowBeginview;
            }
            set
            {
                this.rowBeginview = value;
            }
        }

        //────────────────────────────────────────

        private string fileSave;

        /// <summary>
        /// セーブファイルのパス。指定が無ければ空文字列。
        /// </summary>
        public string FileSave
        {
            get
            {
                return this.fileSave;
            }
            set
            {
                this.fileSave = value;
            }
        }

        //────────────────────────────────────────

        private Image image;

        public Image Image
        {
            get
            {
                return image;
            }
            set
            {
                this.image = value;
            }
        }

        //────────────────────────────────────────

        private List<LineImpl> lines;

        public List<LineImpl> Lines
        {
            get
            {
                return lines;
            }
            set
            {
                this.lines = value;
            }
        }

        //────────────────────────────────────────

        private int heightLine;

        /// <summary>
        /// 行の高さ。
        /// </summary>
        public int HeightLine
        {
            get
            {
                return this.heightLine;
            }
            set
            {
                this.heightLine = value;
            }
        }

        //────────────────────────────────────────

        private Font font;

        /// <summary>
        /// 行の高さ。
        /// </summary>
        public Font Font
        {
            get
            {
                return this.font;
            }
            set
            {
                this.font = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Xenon.Aims.ActorGraph
{

    [Serializable]
    public class LineImpl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public LineImpl( DecorationImpl[] decorations, DocumentImpl ownerDocument)
        {
            this.Decorations = new List<DecorationImpl>( decorations);
            this.OwnerDocument = ownerDocument;
            this.width = 1.0f;
        }

        public LineImpl( List<DecorationImpl> decorations, DocumentImpl ownerDocument)
        {
            this.Decorations = decorations;
            this.OwnerDocument = ownerDocument;
            this.width = 1.0f;
        }

        //────────────────────────────────────────

        public static LineImpl Import(string line, DocumentImpl ownerDocument)
        {
            List<DecorationImpl> decorations = new List<DecorationImpl>();

            for (int i = 0; i < line.Length; i++)
            {
                char ch = line[i];

                switch (ch)
                {
                    //
                    //シーン。
                    //
                    case '┣':
                        decorations.Add(new DecorationImpl(EnumNode.Scene, EnumShape.ArrowBranch));
                        break;
                    case '┗':
                        decorations.Add(new DecorationImpl(EnumNode.Scene, EnumShape.ArrowCurve));
                        break;
                    case '┃':
                        decorations.Add(new DecorationImpl(EnumNode.Scene, EnumShape.ArrowMiddle));
                        break;
                    case '追':
                        decorations.Add(new DecorationImpl(EnumNode.Scene, EnumShape.ArrowPointer1));
                        break;
                    case '加':
                        decorations.Add(new DecorationImpl(EnumNode.Scene, EnumShape.ArrowPointer2));
                        break;
                    case '＞':
                        decorations.Add(new DecorationImpl(EnumNode.Scene, EnumShape.ArrowPointer3));
                        break;
                    case '：':
                        decorations.Add(new DecorationImpl(EnumNode.Scene, EnumShape.Joint));
                        break;
                    case '　':
                        decorations.Add(new DecorationImpl(EnumNode.Scene, EnumShape.Space));
                        break;
                    //
                    //アクター。
                    //
                    case '├':
                        decorations.Add(new DecorationImpl(EnumNode.Actor, EnumShape.ArrowBranch));
                        break;
                    case '└':
                        decorations.Add(new DecorationImpl(EnumNode.Actor, EnumShape.ArrowCurve));
                        break;
                    case '│':
                        decorations.Add(new DecorationImpl(EnumNode.Actor, EnumShape.ArrowMiddle));
                        break;
                    case '作':
                        decorations.Add(new DecorationImpl(EnumNode.Actor, EnumShape.ArrowPointer1));
                        break;
                    case '成':
                        decorations.Add(new DecorationImpl(EnumNode.Actor, EnumShape.ArrowPointer2));
                        break;
                    case '→':
                        decorations.Add(new DecorationImpl(EnumNode.Actor, EnumShape.ArrowPointer3));
                        break;
                    case '・':
                        decorations.Add(new DecorationImpl(EnumNode.Actor, EnumShape.Joint));
                        break;
                    //
                    //スレッド。
                    //
                    case 'Ｔ':
                        decorations.Add(new DecorationImpl(EnumNode.Thread, EnumShape.ArrowBranch));
                        break;
                    case 'Ｌ':
                        decorations.Add(new DecorationImpl(EnumNode.Thread, EnumShape.ArrowCurve));
                        break;
                    case 'Ｉ':
                        decorations.Add(new DecorationImpl(EnumNode.Thread, EnumShape.ArrowMiddle));
                        break;
                    case '開':
                        decorations.Add(new DecorationImpl(EnumNode.Thread, EnumShape.ArrowPointer1));
                        break;
                    case '始':
                        decorations.Add(new DecorationImpl(EnumNode.Thread, EnumShape.ArrowPointer2));
                        break;
                    case 'Ｖ':
                        decorations.Add(new DecorationImpl(EnumNode.Thread, EnumShape.ArrowPointer3));
                        break;
                    //case '・':
                    //    decorations.Add(new DecorationImpl(EnumNode.Actor, EnumShape.Joint));
                    //    break;
                    //
                    //
                    //
                    case '<':
                        {
                            //シーン名
                            StringBuilder s = new StringBuilder();
                            i++;
                            for (; i < line.Length; i++)
                            {
                                ch = line[i];

                                if (ch == '>')
                                {
                                    break;
                                }
                                else
                                {
                                    s.Append(ch);
                                }
                            }
                            decorations.Add(new DecorationImpl(EnumNode.Scene, s.ToString()));

                        }
                        break;
                    case '[':
                        {
                            //アクター名
                            StringBuilder s = new StringBuilder();
                            i++;
                            for (; i < line.Length; i++)
                            {
                                ch = line[i];

                                if (ch == ']')
                                {
                                    break;
                                }
                                else
                                {
                                    s.Append(ch);
                                }
                            }
                            decorations.Add(new DecorationImpl(EnumNode.Actor, s.ToString()));
                        }
                        break;
                    case '(':
                        {
                            //スレッド名
                            StringBuilder s = new StringBuilder();
                            i++;
                            for (; i < line.Length; i++)
                            {
                                ch = line[i];

                                if (ch == ')')
                                {
                                    break;
                                }
                                else
                                {
                                    s.Append(ch);
                                }
                            }
                            decorations.Add(new DecorationImpl(EnumNode.Thread, s.ToString()));
                        }
                        break;
                    case '{':
                        {
                            //コメント
                            StringBuilder s = new StringBuilder();
                            i++;
                            for (; i < line.Length; i++)
                            {
                                ch = line[i];

                                if (ch == '}')
                                {
                                    break;
                                }
                                else
                                {
                                    s.Append(ch);
                                }
                            }
                            decorations.Add(new DecorationImpl(EnumNode.Comment, s.ToString()));
                        }
                        break;
                    default:
                        //エラー
                        decorations.Add(new DecorationImpl(EnumNode.Error, "×"));
                        break;
                }
            }

            System.Console.WriteLine("line=[" + line + "] line.Length=[" + line.Length + "] decorations.Count=[" + decorations.Count + "]");
            return new LineImpl( decorations, ownerDocument);
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        public bool ContainsName()
        {
            bool result = false;

            foreach (DecorationImpl decoration in this.Decorations)
            {
                if ("" != decoration.Name)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

        public void Paint(Graphics g, int top)
        {
            int left;
            left = 0;

            if (null != this.OwnerDocument.Image)
            {

                foreach (DecorationImpl decoration in this.Decorations)
                {
                    int areaY;

                    //エリア判定
                    Pen penForeground = this.OwnerDocument.CreatePen(decoration.Node);
                    Brush brushForeground = this.OwnerDocument.CreateBrush(decoration.Node);
                    if (EnumNode.Thread == decoration.Node)
                    {
                        //スレッド
                        areaY = 2;
                    }
                    else if (EnumNode.Actor == decoration.Node)
                    {
                        //アクター
                        areaY = 1;
                    }
                    else
                    {
                        //シーン
                        areaY = 0;
                    }

                    switch (decoration.Shape)
                    {
                        case EnumShape.ArrowBranch:
                            {
                                g.DrawImage(this.OwnerDocument.Image, new Rectangle(left, top, 20, 20), ChipPosition.GetArrowBranch(areaY), GraphicsUnit.Pixel);
                                left += DocumentImpl.WIDTH_CELL;
                            }
                            break;
                        case EnumShape.ArrowCurve:
                            {
                                g.DrawImage(this.OwnerDocument.Image, new Rectangle(left, top, 20, 20), ChipPosition.GetArrowCurve(areaY), GraphicsUnit.Pixel);
                                left += DocumentImpl.WIDTH_CELL;
                            }
                            break;
                        case EnumShape.ArrowMiddle:
                            {
                                g.DrawImage(this.OwnerDocument.Image, new Rectangle(left, top, 20, 20), ChipPosition.GetArrowMiddle(areaY), GraphicsUnit.Pixel);
                                left += DocumentImpl.WIDTH_CELL;
                            }
                            break;
                        case EnumShape.ArrowPointer1:
                            {
                                g.DrawImage(this.OwnerDocument.Image, new Rectangle(left, top, 20, 20), ChipPosition.GetArrowPointer1(areaY), GraphicsUnit.Pixel);
                                left += DocumentImpl.WIDTH_CELL;
                            }
                            break;
                        case EnumShape.ArrowPointer2:
                            {
                                g.DrawImage(this.OwnerDocument.Image, new Rectangle(left, top, 20, 20), ChipPosition.GetArrowPointer2(areaY), GraphicsUnit.Pixel);
                                left += DocumentImpl.WIDTH_CELL;
                            }
                            break;
                        case EnumShape.ArrowPointer3:
                            {
                                g.DrawImage(this.OwnerDocument.Image, new Rectangle(left, top - 2, 20, 20 + 8), ChipPosition.GetArrowPointer3(areaY), GraphicsUnit.Pixel);
                                left += DocumentImpl.WIDTH_CELL;
                            }
                            break;
                        case EnumShape.Joint:
                            {
                                g.DrawImage(this.OwnerDocument.Image, new Rectangle(left, top, 20, 20), ChipPosition.GetJointSingle(areaY), GraphicsUnit.Pixel);
                                left += DocumentImpl.WIDTH_CELL;
                            }
                            break;
                        case EnumShape.Name:
                            {
                                //名前の描画
                                SizeF sizeF = g.MeasureString(decoration.Name, this.OwnerDocument.Font);

                                //枠線
                                if (EnumNode.Actor == decoration.Node)
                                {
                                    //アクター

                                    //ただの矩形。
                                    g.DrawRectangle(penForeground, left, top, sizeF.Width - 1, sizeF.Height - 1);
                                    g.DrawString(decoration.Name, this.OwnerDocument.Font, brushForeground, new Point(left, top));
                                    this.width = sizeF.Width;
                                    left += (int)sizeF.Width;
                                }
                                else if (
                                    EnumNode.Scene == decoration.Node
                                    )
                                {
                                    //シーン

                                    //10px横に伸ばして、三角括弧気味にする。
                                    int height = (int)sizeF.Height - 2;
                                    g.DrawLines(penForeground,
                                        new Point[]{
                                            new Point(5+left,top),//左上
                                            new Point(5+left+(int)sizeF.Width-1,top),//右上
                                            new Point(5+left+(int)sizeF.Width-1+5,top+height/2),//右＞頂点
                                            new Point(5+left+(int)sizeF.Width-1,top+height),//右下
                                            new Point(5+left,top+height),//左下
                                            new Point(left,top+height/2),//左＜頂点
                                            new Point(5+left,top),//左上
                                        });
                                    g.DrawString(decoration.Name, this.OwnerDocument.Font, brushForeground, new Point(left + 5, top));
                                    this.width = sizeF.Width + 10;
                                    left += (int)sizeF.Width + 10;
                                }
                                else if (
                                    EnumNode.Thread == decoration.Node
                                    )
                                {
                                    //スレッド

                                    //10px横に伸ばして、三角括弧気味にする。
                                    int height = (int)sizeF.Height - 2;
                                    g.DrawLines(penForeground,
                                        new Point[]{
                                            //天辺
                                            new Point(5+left,top),//左上
                                            new Point(5+left+(int)sizeF.Width-1,top),//右上

                                            //右辺
                                            new Point(5+left+(int)sizeF.Width-1+3,top+height/2-7),
                                            new Point(5+left+(int)sizeF.Width-1+4,top+height/2-6),
                                            new Point(5+left+(int)sizeF.Width-1+5,top+height/2-3),//右＞頂点
                                            new Point(5+left+(int)sizeF.Width-1+5,top+height/2+4),
                                            new Point(5+left+(int)sizeF.Width-1+4,top+height/2+7),
                                            new Point(5+left+(int)sizeF.Width-1+3,top+height/2+8),

                                            //底辺
                                            new Point(5+left+(int)sizeF.Width-1,top+height),//右下
                                            new Point(5+left,top+height),//左下

                                            //左辺
                                            new Point(left+2,top+height/2+8),
                                            new Point(left+1,top+height/2+7),
                                            new Point(left,top+height/2+4),//左＜頂点
                                            new Point(left,top+height/2-3),
                                            new Point(left+1,top+height/2-6),
                                            new Point(left+2,top+height/2-7),
                                            new Point(5+left,top),//左上
                                        });
                                    g.DrawString(decoration.Name, this.OwnerDocument.Font, brushForeground, new Point(left + 5, top));
                                    this.width = sizeF.Width + 10;
                                    left += (int)sizeF.Width + 10;
                                }
                                else
                                {
                                    //コメント、またはエラー。
                                    g.DrawString(decoration.Name, this.OwnerDocument.Font, brushForeground, new Point(left, top));
                                    this.width = sizeF.Width;
                                    left += (int)sizeF.Width;
                                }

                            }
                            break;
                        case EnumShape.Space:
                            {
                                left += DocumentImpl.WIDTH_CELL;
                            }
                        break;
                        //default:
                        //    {
                        //        left += DocumentImpl.WIDTH_CELL;
                        //    }
                            //break;
                    }
                }
            }

        }

        //────────────────────────────────────────

        public string ToString_Export()
        {
            StringBuilder s = new StringBuilder();

            foreach (DecorationImpl decoration in this.Decorations)
            {
                if (EnumNode.Scene == decoration.Node)
                {
                    //シーン
                    switch (decoration.Shape)
                    {
                        case EnumShape.ArrowBranch:
                            s.Append("┣");
                            break;
                        case EnumShape.ArrowCurve:
                            s.Append("┗");
                            break;
                        case EnumShape.ArrowMiddle:
                            s.Append("┃");
                            break;
                        case EnumShape.ArrowPointer1:
                            s.Append("追");
                            break;
                        case EnumShape.ArrowPointer2:
                            s.Append("加");
                            break;
                        case EnumShape.ArrowPointer3:
                            s.Append("＞");
                            break;
                        case EnumShape.Joint:
                            s.Append("：");
                            break;
                        case EnumShape.Space:
                            s.Append("　");
                            break;
                        case EnumShape.Name:
                            s.Append("<");
                            s.Append(decoration.Name);
                            s.Append(">");
                            break;
                    }
                }
                else if (EnumNode.Actor == decoration.Node)
                {
                    //アクター
                    switch (decoration.Shape)
                    {
                        case EnumShape.ArrowBranch:
                            s.Append("├");
                            break;
                        case EnumShape.ArrowCurve:
                            s.Append("└");
                            break;
                        case EnumShape.ArrowMiddle:
                            s.Append("│");
                            break;
                        case EnumShape.ArrowPointer1:
                            s.Append("作");
                            break;
                        case EnumShape.ArrowPointer2:
                            s.Append("成");
                            break;
                        case EnumShape.ArrowPointer3:
                            s.Append("→");
                            break;
                        case EnumShape.Joint:
                            s.Append("・");
                            break;
                        case EnumShape.Space:
                            s.Append("　");
                            break;
                        case EnumShape.Name:
                            s.Append("[");
                            s.Append(decoration.Name);
                            s.Append("]");
                            break;
                    }
                }
                else
                {
                    //空白専用。
                    switch (decoration.Shape)
                    {
                        case EnumShape.Space:
                            s.Append("　");
                            break;
                        default:
                            s.Append("×");
                            break;
                    }
                }
            }


            return s.ToString();
        }

        //────────────────────────────────────────
        #endregion




        #region プロパティー
        //────────────────────────────────────────

        private List<DecorationImpl> decorations;

        /// <summary>
        /// 装飾。矢印や空行なら真。
        /// </summary>
        public List<DecorationImpl> Decorations
        {
            get
            {
                return this.decorations;
            }
            set
            {
                this.decorations = value;
            }
        }

        //────────────────────────────────────────

        private DocumentImpl ownerDocument;

        public DocumentImpl OwnerDocument
        {
            get
            {
                return this.ownerDocument;
            }
            set
            {
                this.ownerDocument = value;
            }
        }

        //────────────────────────────────────────

        private float width;

        /// <summary>
        /// 名前を囲む枠の横幅。
        /// </summary>
        public float Width
        {
            get
            {
                return this.width;
            }
            set
            {
                this.width = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}

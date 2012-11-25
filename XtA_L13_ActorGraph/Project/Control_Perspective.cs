using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xenon.Aims.ActorGraph
{
    public partial class Control_Perspective : UserControl
    {


        #region 用意
        //────────────────────────────────────────

        private const int PIXEL_HEIGHT_MAX_TOOLBOX = 40;

        //────────────────────────────────────────
        #endregion



        #region 生成と破棄
        //────────────────────────────────────────

        public Control_Perspective()
        {
            InitializeComponent();
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        public Control_Note GetControl_Note1()
        {
            return this.control_Note1;
        }

        public void ExportScreenshot(DocumentImpl document)
        {
            PainterImpl painter = new PainterImpl();

            painter.ExportScreenshot(
                new SolidBrush( this.control_Note1.BackColor),
                this.control_Note1.Width,
                document
                );
        }

        public void ExportDocument(DocumentImpl document)
        {
            PainterImpl painter = new PainterImpl();

            painter.ExportDocument(
                document
                );
        }

        //────────────────────────────────────────

        public int GetTopSeparator()
        {
            int top = this.Height * 20 / 100;

            //上限
            if (Control_Perspective.PIXEL_HEIGHT_MAX_TOOLBOX < top)
            {
                top = Control_Perspective.PIXEL_HEIGHT_MAX_TOOLBOX;
            }

            return top;
        }

        public int GetHeightNote()
        {
            int height = this.Height - this.GetTopSeparator();
            return height;
        }

        //────────────────────────────────────────
        #endregion



        #region イベントハンドラー
        //────────────────────────────────────────

        private void Control_Canvas_Load(object sender, EventArgs e)
        {
            int topSeparator = this.GetTopSeparator();
            int heightNote = this.GetHeightNote();

            this.control_Toolbox1.Bounds = new Rectangle(0, 0, this.Width, topSeparator);
            this.control_Note1.Bounds = new Rectangle(0, topSeparator, this.Width, heightNote);
        }

        private void Control_Canvas_Resize(object sender, EventArgs e)
        {
            int topSeparator = this.GetTopSeparator();
            int heightNote = this.GetHeightNote();

            this.control_Toolbox1.Bounds = new Rectangle(0, 0, this.Width, topSeparator);
            this.control_Note1.Bounds = new Rectangle(0, topSeparator, this.Width, heightNote);
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        //────────────────────────────────────────
        #endregion



    }
}

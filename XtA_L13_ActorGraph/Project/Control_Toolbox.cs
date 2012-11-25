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



    public partial class Control_Toolbox : UserControl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public Control_Toolbox()
        {
            InitializeComponent();
        }

        //────────────────────────────────────────
        #endregion



        #region イベントハンドラー
        //────────────────────────────────────────

        private void Control_Toolbox_Paint(object sender, PaintEventArgs e)
        {
        }

        /// <summary>
        /// 「スクリーンショット保存」
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.Parent is Control_Perspective)
            {
                Control_Perspective perspective1 = (Control_Perspective)this.Parent;

                if (perspective1.Parent is Form1)
                {
                    Form1 form1 = (Form1)perspective1.Parent;

                    perspective1.ExportDocument(form1.Document);

                    perspective1.ExportScreenshot(form1.Document);
                }
            }
        }

        //────────────────────────────────────────
        #endregion



    }



}

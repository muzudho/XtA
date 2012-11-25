using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Xenon.Aims.Actorslist
{
    public partial class Form1 : Form
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public Form1()
        {
            InitializeComponent();
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        public void Fitsize()
        {
            this.controlCanvas1.Location = new Point();
            this.controlCanvas1.Width = this.ClientSize.Width;
            this.controlCanvas1.Height = this.ClientSize.Height;
        }

        //────────────────────────────────────────
        #endregion



        #region イベントハンドラー
        //────────────────────────────────────────

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Fitsize();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.Fitsize();
        }

        //────────────────────────────────────────
        #endregion


    }
}

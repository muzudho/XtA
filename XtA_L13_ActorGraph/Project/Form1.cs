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

namespace Xenon.Aims.ActorGraph
{
    public partial class Form1 : Form
    {


        #region 生成と破棄
        //────────────────────────────────────────

        public Form1()
        {
            InitializeComponent();
            //this.Document = new DocumentImpl();
            //初期ドキュメント
            {
                StringBuilder sb = new StringBuilder();

                sb.Append("");
                sb.Append(Environment.NewLine);
                sb.Append("{AIMSサンプル『suica32』調査中}");
                sb.Append(Environment.NewLine);
                sb.Append("");
                sb.Append(Environment.NewLine);
                sb.Append("　<boot>{boot.lua}");
                sb.Append(Environment.NewLine);
                sb.Append("　　┃");
                sb.Append(Environment.NewLine);
                sb.Append("　　┗追加＞<frame>{s/frame.lua}");
                sb.Append(Environment.NewLine);
                sb.Append("　　　　　　：│");
                sb.Append(Environment.NewLine);
                sb.Append("　　　　　　：├作成→[黒画面左]");
                sb.Append(Environment.NewLine);
                sb.Append("　　　　　　：│");
                sb.Append(Environment.NewLine);
                sb.Append("　　　　　　：└作成→[黒画面右]");
                sb.Append(Environment.NewLine);
                sb.Append("　　　　　　：");
                sb.Append(Environment.NewLine);
                sb.Append("　　　　　　<logo>{s/logo.lua}");
                sb.Append(Environment.NewLine);
                sb.Append("　　　　　　：│");
                sb.Append(Environment.NewLine);
                sb.Append("　　　　　　：├作成→[「Loading...」]");
                sb.Append(Environment.NewLine);
                sb.Append("　　　　　　：│");
                sb.Append(Environment.NewLine);
                sb.Append("　　　　　　：└作成→[ロゴ]");
                sb.Append(Environment.NewLine);
                sb.Append("　　　　　　：");
                sb.Append(Environment.NewLine);
                sb.Append("　　　　　　<title>{s/title.lua}");
                sb.Append(Environment.NewLine);
                sb.Append("　　　　　　：│");
                sb.Append(Environment.NewLine);
                sb.Append("　　　　　　：└作成→[タイトル]");
                sb.Append(Environment.NewLine);
                sb.Append("　　　　　　：");
                sb.Append(Environment.NewLine);
                sb.Append("　　　　　　<game>{s/game.lua}");
                sb.Append(Environment.NewLine);
                sb.Append("　　　　　　：│");
                sb.Append(Environment.NewLine);
                sb.Append("　　　　　　：├作成→[\"padlistener\"／ゲームパッド制御]");
                sb.Append(Environment.NewLine);
                sb.Append("　　　　　　：│");
                sb.Append(Environment.NewLine);
                sb.Append("　　　　　　：├作成→[A.bg／背景]");
                sb.Append(Environment.NewLine);
                sb.Append("　　　　　　：│");
                sb.Append(Environment.NewLine);
                sb.Append("　　　　　　：├作成→[A.player \"player\"／プレイヤー]");
                sb.Append(Environment.NewLine);
                sb.Append("　　　　　　：│");
                sb.Append(Environment.NewLine);
                sb.Append("　　　　　　：├作成→[A.score \"pxf\"／スコアボード「SCORE 0000000000        HI 0000000000」]");
                sb.Append(Environment.NewLine);
                sb.Append("　　　　　　：│");
                sb.Append(Environment.NewLine);
                sb.Append("　　　　　　：├作成→[A.extend \"pxf\"／エクステンド「EXTEND0000000000」]");
                sb.Append(Environment.NewLine);
                sb.Append("　　　　　　：│");
                sb.Append(Environment.NewLine);
                sb.Append("　　　　　　：├作成→[A.level \"pxf\"／レベル「LEVEL 00」]");
                sb.Append(Environment.NewLine);
                sb.Append("　　　　　　：│");
                sb.Append(Environment.NewLine);
                sb.Append("　　　　　　：├作成→[A.lives \"lifecounter\"／ライフカウンター」]");
                sb.Append(Environment.NewLine);
                sb.Append("　　　　　　：│");
                sb.Append(Environment.NewLine);
                sb.Append("　　　　　　：├作成→[enemy]");
                sb.Append(Environment.NewLine);
                sb.Append("　　　　　　：│");
                sb.Append(Environment.NewLine);
                sb.Append("　　　　　　：├作成→[bullets]");
                sb.Append(Environment.NewLine);
                sb.Append("　　　　　　：│");
                sb.Append(Environment.NewLine);
                sb.Append("　　　　　　：├作成→[font]");
                sb.Append(Environment.NewLine);
                sb.Append("　　　　　　：│");
                sb.Append(Environment.NewLine);
                sb.Append("　　　　　　：├作成→[common.black]");
                sb.Append(Environment.NewLine);
                sb.Append("　　　　　　：│");
                sb.Append(Environment.NewLine);
                sb.Append("　　　　　　：├作成→[common.white]");
                sb.Append(Environment.NewLine);
                sb.Append("　　　　　　：│");
                sb.Append(Environment.NewLine);
                sb.Append("　　　　　　：├作成→[common.clear]");
                sb.Append(Environment.NewLine);
                sb.Append("　　　　　　：Ｉ");
                sb.Append(Environment.NewLine);
                sb.Append("　　　　　　：Ｌ開始Ｖ(thread_gameover){game.lua。<gameover>へチェンジ・シーンします。}");
                sb.Append(Environment.NewLine);
                sb.Append("　　　　　　：");
                sb.Append(Environment.NewLine);
                sb.Append("　　　　　　<gameover>{s/game.lua}");
                sb.Append(Environment.NewLine);
                sb.Append("");
                sb.Append(Environment.NewLine);
                sb.Append("{以上}");
                sb.Append(Environment.NewLine);

                this.Document = DocumentImpl.Import(sb.ToString(), "", null);
            }
        }

        //────────────────────────────────────────
        #endregion



        #region イベントハンドラー
        //────────────────────────────────────────

        private void Form1_Load(object sender, EventArgs e)
        {
            this.control_Perspective1.Bounds = new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height);
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseWheel);
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            this.control_Perspective1.Bounds = new Rectangle(0, 0, this.ClientSize.Width, this.ClientSize.Height);
            this.Refresh();
        }

        //────────────────────────────────────────

        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            //スクロール量。なぜか120単位？
            int valueScroll = e.Delta / 120;
            //System.Console.WriteLine("Form1_MouseWheel: スクロール量=[" + valueScroll + "] e.Delta=[" + e.Delta + "] SystemInformation.MouseWheelScrollLines=[" + SystemInformation.MouseWheelScrollLines + "]");

            this.Document.RowBeginview -= valueScroll;
            if (this.Document.RowBeginview < 0)
            {
                this.Document.RowBeginview = 0;
            }
            this.Refresh();

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Keys keys = e.KeyCode;

            int rowViewed = this.control_Perspective1.GetControl_Note1().GetRow_Viewed();

            switch (keys)
            {
                case Keys.F5:
                    //ドキュメントの再読込み。
                    if (File.Exists(this.Document.FileSave))
                    {
                        string text = File.ReadAllText(this.Document.FileSave);
                        int oldRowBeginview = this.Document.RowBeginview;
                        this.Document = DocumentImpl.Import(text, this.Document.FileSave, this.Document);
                        this.Document.RowBeginview = oldRowBeginview;
                        this.Refresh();
                    }
                    break;
                case Keys.PageDown:
                    this.Document.RowBeginview += rowViewed / 2;
                    this.Refresh();
                    break;
                case Keys.PageUp:
                    this.Document.RowBeginview -= rowViewed / 2;
                    if (this.Document.RowBeginview < 0)
                    {
                        this.Document.RowBeginview = 0;
                    }
                    this.Refresh();
                    break;
            }
            //System.Console.WriteLine("keyDown=["+keys.ToString()+"] "+Keys.PageDown+" "+Keys.PageUp);

        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private DocumentImpl document;

        public DocumentImpl Document
        {
            get
            {
                return this.document;
            }
            set
            {
                this.document = value;
            }
        }

        //────────────────────────────────────────
        #endregion



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace Xenon.Aims.ActorGraph
{
    public class PainterImpl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public PainterImpl()
        {
        }

        //────────────────────────────────────────
        #endregion




        #region アクション
        //────────────────────────────────────────

        public void ExportDocument(
            DocumentImpl document
            )
        {
            StringBuilder s_Body = new StringBuilder();

            foreach (LineImpl line in document.Lines)
            {
                s_Body.Append(line.ToString_Export());
                s_Body.Append(Environment.NewLine);
            }

            //バックアップ出力
            string timestamp;
            {
                // ファイル名を適当に作成。
                StringBuilder s = new StringBuilder();
                DateTime now = System.DateTime.Now;
                s.Append(now.Year);
                s.Append("_");
                s.Append(now.Month);
                s.Append("_");
                s.Append(now.Day);
                s.Append("_");
                s.Append(now.Hour);
                s.Append("_");
                s.Append(now.Minute);
                s.Append("_");
                s.Append(now.Second);
                s.Append("_");
                s.Append(now.Millisecond);
                timestamp = s.ToString();

                File.WriteAllText(Path.Combine(Application.StartupPath, "backup-"+timestamp + ".txt"), s_Body.ToString());
            }

            //セーブファイル出力
            {
                if ("" == document.FileSave)
                {
                    StringBuilder s = new StringBuilder();
                    s.Append("save-since");
                    s.Append(timestamp);
                    s.Append(".txt");
                    document.FileSave = Path.Combine(Application.StartupPath, s.ToString());
                }

                File.WriteAllText(document.FileSave, s_Body.ToString());
            }
        }

        public void ExportScreenshot(
            Brush brushBackground,
            int width,
            DocumentImpl document
            )
        {
            //タイムスタンプ
            string timestamp;
            {
                StringBuilder s = new StringBuilder();
                DateTime now = System.DateTime.Now;
                s.Append(now.Year);
                s.Append("_");
                s.Append(now.Month);
                s.Append("_");
                s.Append(now.Day);
                s.Append("_");
                s.Append(now.Hour);
                s.Append("_");
                s.Append(now.Minute);
                s.Append("_");
                s.Append(now.Second);
                s.Append("_");
                s.Append(now.Millisecond);
                timestamp = s.ToString();
            }

            //行数。
            int rows = document.Lines.Count;
            //１枚のスクリーンショットに収める行数。
            int rowsByOne = 20;//仮。
            int numberPage = 0;

            int lastPage = rows / rowsByOne;
            if (0 < rows % rowsByOne)
            {
                lastPage++;
            }
            //System.Console.WriteLine("rows=[" + rows + "] rowsByOne=[" + rowsByOne + "] lastPage=[" + lastPage + "]");

            // １ページ分を保存できる高さとします。
            int height = rowsByOne * document.HeightLine;

            while (numberPage < lastPage)
            {
                //Graphicsオブジェクトを取得
                Graphics g = null;

                try
                {
                    Bitmap bitmap;
                    bitmap = new Bitmap(width, height);
                    g = Graphics.FromImage(bitmap);

                    //背景を塗りつぶします。
                    g.FillRectangle(brushBackground, 0, 0, width, height);

                    this.Paint(g, width, height, numberPage*rowsByOne, rowsByOne, document);

                    bitmap.Save(Path.Combine(Application.StartupPath, timestamp + "_P" + numberPage + ".png"), System.Drawing.Imaging.ImageFormat.Png);
                }
                finally
                {
                    if (null != g)
                    {
                        g.Dispose();
                    }
                }

                numberPage++;
            }
        }

        public void Paint(
            Graphics g,
            int width,
            int height,
            int rowBeginview,
            int rowViewed,
            DocumentImpl document
            )
        {
            int top;
            for (top = 0; top < height; top += document.HeightLine)
            {
                g.DrawLine(document.CreatePenGrid(), 0, top, width, top);
            }

            Stack<LineImpl> breadcrumbLocation = new Stack<LineImpl>();
            top = 0;
            int row = 0;
            int lastRowViewed = rowBeginview + rowViewed;
            foreach (LineImpl line in document.Lines)
            {
                if (rowBeginview <= row && row <= lastRowViewed)
                {
                    //表示

                    line.Paint(g, top);
                    top += document.HeightLine;
                }
                else
                {
                }

                row++;
            }
        }

        //────────────────────────────────────────
        #endregion


    }
}

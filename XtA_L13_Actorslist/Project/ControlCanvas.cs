using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Text.RegularExpressions;
using System.IO;
using System.Xml;
using Xenon.Syntax;
using Xenon.Table;

namespace Xenon.Aims.Actorslist
{
    public partial class ControlCanvas : UserControl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public ControlCanvas()
        {
            InitializeComponent();
        }

        //────────────────────────────────────────
        #endregion



        #region イベントハンドラー
        //────────────────────────────────────────

        /// <summary>
        /// 「.luaファイルを一覧」ボタン。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Log_ReportsImpl.BDebugmode_Static = true;
            Log_Reports log_Reports;
            //（２）メソッド開始
            Log_Method log_Method = new Log_MethodImpl();
            // デバッグモード静的設定の後で。
            log_Method.BeginMethod(Info_Actorslist.Name_Library, this, "button1_Click", out log_Reports);




            //コンフィグファイル
            ConfigxmlImpl configxml = new ConfigxmlImpl();
            configxml.Read(log_Reports);



            //サーチ
            List<string> listFilepath = new List<string>();
            FinderLuaImpl finder = new FinderLuaImpl();
            finder.SearchLua(listFilepath, configxml.FolderpathProject, log_Reports);

            //出力
            if (log_Reports.Successful)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("NO,FILE,END");//,EOL
                sb.Append(Environment.NewLine);
                sb.Append("int,string,");
                sb.Append(Environment.NewLine);
                sb.Append("-1,ファイルパス,");
                sb.Append(Environment.NewLine);
                int row = 0;
                foreach (string filepath in listFilepath)
                {
                    string filepath2;
                    if (filepath.StartsWith(configxml.FolderpathProject))
                    {
                        // プロジェクト・フォルダーからの相対パスに変換
                        filepath2 = filepath.Substring(configxml.FolderpathProject.Length);
                        if (filepath2.StartsWith("\\"))
                        {
                            //頭に \ が付いていれば除去します。
                            filepath2 = filepath2.Substring(1);
                        }
                    }
                    else
                    {
                        filepath2 = filepath;
                    }

                    sb.Append(row);
                    sb.Append(",");
                    sb.Append(filepath2);
                    sb.Append(",");
                    sb.Append(Environment.NewLine);
                    //System.Console.WriteLine("filepath=[" + filepath + "] filepath2=[" + filepath2 + "]");
                    row++;
                }
                sb.Append("EOF,,");
                sb.Append(Environment.NewLine);

                string csvfile = Path.Combine(Application.StartupPath, configxml.FilepathExportLualist);
                System.Console.WriteLine("csvfile=[" + csvfile + "]");
                File.WriteAllText(csvfile, sb.ToString(), Encoding.UTF8);
            }



            goto gt_EndMethod;

        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            log_Reports.EndLogging(log_Method);
        }

        /// <summary>
        /// 大雑把にfunctionを一覧。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Log_ReportsImpl.BDebugmode_Static = true;
            Log_Reports log_Reports;
            //（２）メソッド開始
            Log_Method log_Method = new Log_MethodImpl();
            // デバッグモード静的設定の後で。
            log_Method.BeginMethod(Info_Actorslist.Name_Library, this, "button2_Click", out log_Reports);


            Exception error_Exception;


            //コンフィグファイル
            ConfigxmlImpl configxml = new ConfigxmlImpl();
            configxml.Read(log_Reports);



            //CSV→テーブル
            Table_Humaninput tableH;
            if (log_Reports.Successful)
            {
                if(!File.Exists(configxml.FilepathExportLualist))
                {
                    goto gt_Error_File1;
                }

                string csvtext = File.ReadAllText(configxml.FilepathExportLualist);
                CsvTo_Table_HumaninputImpl trans = new CsvTo_Table_HumaninputImpl();
                tableH = trans.Read(
                    csvtext,
                    new Request_ReadsTableImpl(),
                    new Format_Table_HumaninputImpl(),
                    //true,
                    log_Reports
                    );
            }
            else
            {
                tableH = null;
            }



            //各.luaファイル
            List<string> listFile = new List<string>();
            List<string> listRow = new List<string>();
            List<string> listFunction = new List<string>();
            if (log_Reports.Successful)
            {
                Regex regex2 = new Regex(@"^\s*function\s+(.*)$", RegexOptions.Compiled);
                tableH.ForEach_Datapart(
                    (Record_Humaninput recordH, ref bool isBreak2, Log_Reports log_Reports2) =>
                    {
                        string filepathRelational = recordH.TextAt("FILE");
                        string filepath = Path.Combine(configxml.FolderpathProject, filepathRelational);
                        //ystem.Console.WriteLine("filepath=[" + filepath + "]");

                        string luatext = File.ReadAllText(filepath, Encoding.GetEncoding("Shift-JIS"));
                        string[] lines = luatext.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

                        int row = 1;//行番号
                        foreach (string line in lines)
                        {
                            Match m2 = regex2.Match(line);
                            if (m2.Success)
                            {
                                listFile.Add(filepathRelational);
                                listRow.Add(row.ToString());
                                listFunction.Add(line);
                                //System.Console.WriteLine("ファイル=[" + filepathRelational + "] [" + row + "]行 関数line=[" + line + "]");
                            }
                            else
                            {
                            }

                            row++;
                        }

                    }, log_Reports);
            }





            //配列（空回し）；buffer
            Dictionary<string, string> dictionary1 = new Dictionary<string, string>();// 関数名の問題文字列:["シーン","クラスネーム"]
            if (log_Reports.Successful)
            {
                Regex regex4 = new Regex(@"^\s*function\s+(.*?)(_OnClose|_OnVanish)\s*\(.*$", RegexOptions.Compiled);


                //「_OnClose」ならシーン、
                //「_OnVanish」ならクラスネームに確定します。

                for (int i = 0; i < listFunction.Count; i++)
                {
                    string function = listFunction[i];

                    Match m4 = regex4.Match(function);
                    if (m4.Success)
                    {
                        if ("_OnClose" == m4.Groups[2].Value)
                        {
                            //シーン
                            dictionary1.Add(m4.Groups[1].Value, "シーン");
                        }
                        else if ("_OnVanish" == m4.Groups[2].Value)
                        {
                            //クラスネーム
                            dictionary1.Add(m4.Groups[1].Value, "クラスネーム");
                        }
                        else
                        {
                        }
                    }
                }
            }



            //配列→CSV
            if (log_Reports.Successful)
            {
                Regex regex3 = new Regex(@"^\s*function\s+(.*?)(?:_OnStart|_OnStep|_OnClose|_OnVanish|_OnDraw)\s*\(.*$", RegexOptions.Compiled);
                Regex regex4 = new Regex(@"^\s*function\s+(?:OnLoad|OnVanish)\s*\(.*$", RegexOptions.Compiled);
                Regex regex5 = new Regex(@"^\s*function\s+(.*?)_init\s*\(.*$", RegexOptions.Compiled);
                Regex regex6 = new Regex(@"^\s*function\s+(.*?)Thread\s*\(.*$", RegexOptions.Compiled);
                Regex regex7 = new Regex(@"^\s*function\s+thread_(.*?)\s*\(.*$", RegexOptions.Compiled);

                CsvLineParserImpl parser = new CsvLineParserImpl();

                StringBuilder sb = new StringBuilder();
                sb.Append("NO,FILE,ROW,INITIALIZER,SCENE,THREAD,CLASS_NAME,FUNCTION,END");//,EOL
                sb.Append(Environment.NewLine);
                sb.Append("int,string,int,string,string,string,string,string,");
                sb.Append(Environment.NewLine);
                sb.Append("-1,ファイルパス,行番号,suica32用ローダースレッド・ハンドラ？,シーン,スレッド？,クラス名,関数シグネチャー,");
                sb.Append(Environment.NewLine);
                int row = 0;
                for (int i = 0; i < listFunction.Count; i++)
                {
                    string file = listFile[i];
                    string numberRow = listRow[i];
                    string function = listFunction[i];

                    string initializer = "";
                    string scene = "";
                    string thread = "";
                    string classname = "";

                    Match m3 = regex3.Match(function);
                    if (m3.Success)
                    {
                        string functionname2 = m3.Groups[1].Value;

                        if (dictionary1.ContainsKey(functionname2))
                        {
                            switch (dictionary1[functionname2])
                            {
                                case "シーン":
                                    scene = functionname2;
                                    break;
                                case "クラスネーム":
                                    classname = functionname2;
                                    break;
                                default:
                                    break;
                            }
                        }

                        goto gt_Csv;
                    }

                    Match m4 = regex4.Match(function);
                    if (m4.Success)
                    {
                        scene = Path.GetFileNameWithoutExtension(file);
                        goto gt_Csv;
                    }

                    Match m5 = regex5.Match(function);
                    if (m5.Success)
                    {
                        initializer = m5.Groups[1].Value;
                        goto gt_Csv;
                    }

                    Match m6 = regex6.Match(function);
                    if (m6.Success)
                    {
                        thread = m6.Groups[1].Value;
                        goto gt_Csv;
                    }

                    Match m7 = regex7.Match(function);
                    if (m7.Success)
                    {
                        thread = m7.Groups[1].Value;
                        goto gt_Csv;
                    }

                gt_Csv:
                    sb.Append(row);
                    sb.Append(",");
                    sb.Append(file);
                    sb.Append(",");
                    sb.Append(numberRow);
                    sb.Append(",");
                    sb.Append(initializer);
                    sb.Append(",");
                    sb.Append(scene);
                    sb.Append(",");
                    sb.Append(thread);
                    sb.Append(",");
                    sb.Append(classname);
                    sb.Append(",");
                    sb.Append(parser.EscapeCell(function));
                    sb.Append(",");
                    sb.Append(Environment.NewLine);
                    //ystem.Console.WriteLine("row=[" + row + "] file=[" + file + "] numberRow=[" + numberRow + "] initializer=[" + initializer + "] scene=[" + scene + "] thread=[" + thread + "] classname=[" + classname + "] classname=[" + classname + "] function=[" + parser.EscapeCell(function) + "]");
                    row++;
                }

                sb.Append("EOF,,,,,,,,");
                sb.Append(Environment.NewLine);

                string csvfile = Path.Combine(Application.StartupPath, configxml.FilepathExportFunctionlist);
                System.Console.WriteLine("csvfile=[" + csvfile + "]");
                File.WriteAllText(csvfile, sb.ToString(), Encoding.UTF8);
            }



            goto gt_EndMethod;
            #region 異常系
        //────────────────────────────────────────
        gt_Error_File1:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー13007！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append("ファイルが足りません。");
                s.Append(Environment.NewLine);
                s.Append("readme.txtを読んで、手順を踏んでください。");
                s.Append(Environment.NewLine);
                s.Append("　　.lua一覧CSVファイル=[");
                s.Append(configxml.FilepathExportLualist);
                s.Append("]");

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion

        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
            log_Reports.EndLogging(log_Method);
        }

        //────────────────────────────────────────
        #endregion



    }
}

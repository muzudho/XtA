using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;
using System.IO;
using Xenon.Syntax;

namespace Xenon.Aims.Actorslist
{


    /// <summary>
    /// 指定フォルダーと、そのサブフォルダーにある「～.lua」ファイルのパスを一覧します。
    /// </summary>
    public class FinderLuaImpl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public FinderLuaImpl()
        {
            this.regex = new Regex(@".*\.lua", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        }

        //────────────────────────────────────────
        #endregion



        #region アクション
        //────────────────────────────────────────

        /// <summary>
        /// 再帰関数です。
        /// </summary>
        /// <param name="result">.luaファイルのパスが追加されます。</param>
        /// <param name="folderpath"></param>
        public void SearchLua(List<string> result, string folderpath, Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl();
            log_Method.BeginMethod(Info_Actorslist.Name_Library, this, "SearchLua", log_Reports);


            if (log_Reports.Successful)
            {
                if (!Directory.Exists(folderpath))
                {
                    System.Console.WriteLine("SearchLua エラー");
                    goto gt_Error_Folder;
                }

                string[] filepaths = Directory.GetFileSystemEntries(folderpath);
                foreach (string filepath in filepaths)
                {
                    if (Directory.Exists(filepath))
                    {
                        //System.Console.WriteLine("dir=[" + filepath + "]");
                        this.SearchLua(result, filepath, log_Reports);
                    }
                    else
                    {
                        Match m1 = this.Regex.Match(filepath);
                        if (m1.Success)
                        {
                            result.Add(filepath);
                            //System.Console.WriteLine("file=[" + filepath + "]");
                        }

                    }
                }
            }

            goto gt_EndMethod;
            #region 異常系
        //────────────────────────────────────────
        gt_Error_Folder:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー13001！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append("存在するフォルダーを指定してください。");
                s.Append(Environment.NewLine);
                s.Append("　　folderpath=[");
                s.Append(folderpath);
                s.Append("]");

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion



        #region プロパティー
        //────────────────────────────────────────

        private Regex regex;

        public Regex Regex
        {
            get
            {
                return regex;
            }
        }

        //────────────────────────────────────────
        #endregion


    }
}

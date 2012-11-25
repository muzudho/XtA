using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Windows.Forms;
using System.Xml;
using Xenon.Syntax;

namespace Xenon.Aims.Actorslist
{
    public class ConfigxmlImpl
    {



        #region 生成と破棄
        //────────────────────────────────────────

        public ConfigxmlImpl()
        {
            this.FolderpathProject = "";
            this.FilepathExportLualist = "";
            this.FilepathExportFunctionlist = "";
        }

        //────────────────────────────────────────
        #endregion




        #region アクション
        //────────────────────────────────────────

        public void Read(Log_Reports log_Reports)
        {
            Log_Method log_Method = new Log_MethodImpl();
            log_Method.BeginMethod(Info_Actorslist.Name_Library, this, "button1_Click", log_Reports);

            Exception error_Exception;
            string error_Attribute;
            string error_Value;

            string filepathConfig = Path.Combine(Application.StartupPath, "Config.xml");
            {
                XmlDocument doc = new XmlDocument();

                try
                {
                    doc.Load(filepathConfig);

                    XmlElement root = doc.DocumentElement;

                    foreach (XmlNode child in root.ChildNodes)
                    {
                        if (child is XmlElement)
                        {
                            XmlElement elm = (XmlElement)child;

                            if ("input" == elm.Name)
                            {
                                if ("FolderProject" == elm.GetAttribute("name"))
                                {
                                    string value = elm.GetAttribute("value");
                                    this.FolderpathProject = value;

                                    if (!Directory.Exists(value))
                                    {
                                        error_Attribute = "FolderProject";
                                        error_Value = value;
                                        goto gt_Error_Folder1;
                                    }
                                }
                                else if ("FileExportLualist" == elm.GetAttribute("name"))
                                {
                                    string value = elm.GetAttribute("value");
                                    this.FilepathExportLualist = value;

                                    //if (!Directory.Exists(value))
                                    //{
                                    //    error_Attribute = "FileExportLualist";
                                    //    error_Value = value;
                                    //    goto gt_Error_File1;
                                    //}
                                }
                                else if ("FileExportFunctionlist" == elm.GetAttribute("name"))
                                {
                                    string value = elm.GetAttribute("value");
                                    this.FilepathExportFunctionlist = value;

                                    //if (!Directory.Exists(value))
                                    //{
                                    //    error_Attribute = "FilepathExportFunctionlist";
                                    //    error_Value = value;
                                    //    goto gt_Error_File1;
                                    //}
                                }
                            }
                            else
                            {
                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    error_Exception = ex;
                    goto gt_Error_Config;
                }
            }

            System.Console.WriteLine("filepathExportLualist=[" + filepathExportLualist + "]");


            goto gt_EndMethod;
            #region 異常系
        //────────────────────────────────────────
        gt_Error_Config:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー13002！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append("Config.xmlにエラー？");
                s.Newline();

                s.Append(r.Message_SException(error_Exception));

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        gt_Error_Folder1:
            if (log_Reports.CanCreateReport)
            {
                Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
                r.SetTitle("▲エラー13005！", log_Method);

                Log_TextIndented s = new Log_TextIndentedImpl();
                s.Append("存在するフォルダーを指定してください。");
                s.Append(Environment.NewLine);
                s.Append("　　" + error_Attribute + "=[");
                s.Append(this.FolderpathProject);
                s.Append("]");

                r.Message = s.ToString();
                log_Reports.EndCreateReport();
            }
            goto gt_EndMethod;
        //────────────────────────────────────────
        //gt_Error_File1:
        //    if (log_Reports.CanCreateReport)
        //    {
        //        Log_RecordReports r = log_Reports.BeginCreateReport(EnumReport.Error);
        //        r.SetTitle("▲エラー13006！", log_Method);

        //        Log_TextIndented s = new Log_TextIndentedImpl();
        //        s.Append("存在するファイルを指定してください。");
        //        s.Append(Environment.NewLine);
        //        s.Append("　　" + error_Attribute + "=[");
        //        s.Append(this.FolderpathProject);
        //        s.Append("]");

        //        r.Message = s.ToString();
        //        log_Reports.EndCreateReport();
        //    }
        //    goto gt_EndMethod;
        //────────────────────────────────────────
            #endregion
        gt_EndMethod:
            log_Method.EndMethod(log_Reports);
        }

        //────────────────────────────────────────
        #endregion




        #region プロパティー
        //────────────────────────────────────────

        private string folderpathProject;

        public string FolderpathProject
        {
            get
            {
                return folderpathProject;
            }
            set
            {
                folderpathProject = value;
            }
        }

        private string filepathExportLualist;

        public string FilepathExportLualist
        {
            get
            {
                return filepathExportLualist;
            }
            set
            {
                filepathExportLualist = value;
            }
        }

        private string filepathExportFunctionlist;

        public string FilepathExportFunctionlist
        {
            get
            {
                return filepathExportFunctionlist;
            }
            set
            {
                filepathExportFunctionlist = value;
            }
        }

        //────────────────────────────────────────
        #endregion


    }
}

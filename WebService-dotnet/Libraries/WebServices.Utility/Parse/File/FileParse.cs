using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace WebServices.Utility.Parse.File
{
    public class FileParse
    {
        private readonly string _fileName = String.Empty;

        // Looking for the target value in .ini file, implemented by RE
        public static string FromIni(string fileName, string Section, string Key)
        {
            StringBuilder value = new StringBuilder(255);
            bool hasSection = false;

            // IO Stream
            StreamReader sr = new StreamReader(fileName, Encoding.UTF8);
            while (true)
            {
                string s = sr.ReadLine();

                //空值或空字串判斷
                if (s == null || s == "")
                {
                    continue;
                }

                //以;或是#開頭作註解的判斷
                if (Regex.Match(s, @"^(;|#).*$").Success)
                {
                    continue;
                }

                //讀取[Section]
                if (Regex.Match(s, @"^\[.*\]").Success)
                {
                    //判斷Section名稱是否符合
                    if (Regex.Match(s, Section).Success)
                    {
                        hasSection = true;
                    }
                }

                //如果Section存在，才去判斷Key
                if (hasSection)
                {
                    string[] KeyValue = s.Split('=');

                    //判斷Key名稱是否符合
                    if (Regex.Match(KeyValue[0].Trim(), Key).Success)
                    {
                        value.Append(KeyValue[1].Trim());
                        break;
                    }
                }
            }
            //關閉IO串流
            sr.Close();
            return value.ToString();
        }
    }
}

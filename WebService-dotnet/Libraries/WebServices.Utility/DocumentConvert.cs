using System;
using System.IO;

namespace WebServices.Utility
{
    public class DocumentConvert
    {
        public static string ConvertToJson(string filePath)
        {
            byte[] bytes = File.ReadAllBytes(filePath);
            string file = Convert.ToBase64String(bytes);
            return file;
        }

        public static void ConvertToPDF(string b64pdf, string path)
        {
            byte[] bytes = Convert.FromBase64String(b64pdf);
            File.WriteAllBytes(path, bytes);
        }

    }
}

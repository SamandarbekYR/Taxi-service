using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_service.Helper
{
    public class ContentNameMaker
    {
        public static string GetImage(string FilePath)
        {
            FileInfo fileInfo = new FileInfo(FilePath);

            return "image_" + Guid.NewGuid().ToString() + fileInfo.Extension;
        }
    }
}

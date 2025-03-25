using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Global_Classes
{
    class clsUtils
    {
        public static string GenerateGUID()
        {
            Guid guid = Guid.NewGuid();
            return guid.ToString();
        }
        public static bool CreateFolderIfDoesNotExist(string FolderPath)
        {
            if (!Directory.Exists(FolderPath))
            {
                try
                {
                    Directory.CreateDirectory(FolderPath);
                    return true;
                }
                catch(Exception e)
                {
                    MessageBox.Show("Error Creating Directory: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }
        public static string ReplaceFileNameWithGUID(string FileName)
        {
            string Extension = Path.GetExtension(FileName);
            return GenerateGUID() + Extension;
        }
        public static bool CopyImageToProjectImagesFolder(ref string sourceFile)
        {
            const string destFolder = @"C:\DVLD-People-Images\";
            if (!CreateFolderIfDoesNotExist(destFolder)) return false;
            string destFile = destFolder + ReplaceFileNameWithGUID(sourceFile);
            try
            {
                File.Copy(sourceFile, destFile, true);
            }
            catch(Exception e)
            {
                MessageBox.Show("Error Copying Image: " + e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            sourceFile = destFile;
            return true;
        }
    }
}

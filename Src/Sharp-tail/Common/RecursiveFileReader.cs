using System;
using System.Collections.Generic;
using System.IO;

namespace Common
{
    public class RecursiveFileReader
    {
        private List<string> FileList;
        public int folderDepth = 0;
        


        public List<string> GetFiles(string rootFolder, int depth = 2)
        {
            folderDepth = depth;
            FileList = new List<string>();
            var root = new DirectoryInfo(rootFolder);
            WalkDirectoryTree(root, 0);
            return FileList;
        }

       private void WalkDirectoryTree(DirectoryInfo root, int depth)
        {
            FileInfo[] files = null;
            DirectoryInfo[] subDir = null;

            try
            {
                files = root.GetFiles("*.*");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }


            if (files != null)
            {
                foreach (var fileInfo in files)
                {
                    FileList.Add(fileInfo.FullName);
                }
            }

            subDir = root.GetDirectories();

            if (subDir != null)
            {
                foreach (var directoryInfo in subDir)
                {
                    if (depth < folderDepth)
                    {
                        WalkDirectoryTree(directoryInfo, depth + 1);
                    }
                }
            }
        }
    }
}

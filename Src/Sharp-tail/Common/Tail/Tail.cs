using Common.Messages.Services;
using System.Collections.Generic;
using System.IO;
using Common.Models;

namespace Common.Tail
{
    public class Tail
    {
        private readonly string _fileName;
        private MessageService _messageService = MessageService.Instance;
        private bool _tailingFile;
       
        public Tail(string file)
        {
            _fileName = file;
            _tailingFile = true;
        }

        public void StopTailFile()
        {
            _tailingFile = false;
        }

        public void TailFile()
        {
            using (StreamReader reader =
                new StreamReader(new FileStream(_fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
            {
                //start at the end of the file
                long lastMaxOffset = reader.BaseStream.Length;

                while (_tailingFile)
                {
                    System.Threading.Thread.Sleep(100);

                    //if the file size has not changed, idle
                    if (reader.BaseStream.Length == lastMaxOffset)
                        continue;
                    var tailFileInfo = new TaileFileInfo
                    {
                        Name = _fileName,
                        Size = reader.BaseStream.Length
                    };
                   //seek to the last max offset
                    reader.BaseStream.Seek(lastMaxOffset, SeekOrigin.Begin);

                    //read out of the file until the EOF
                    string line;

                    while ((line = reader.ReadLine()) != null)
                        tailFileInfo.FilesRows.Add(line);

                    //publish new file rows.
                    _messageService.Publish(tailFileInfo);

                    //update the last max offset
                    lastMaxOffset = reader.BaseStream.Position;
                }
            }
        }
    }
}

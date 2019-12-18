using System;
using Common.Messages.Services;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Common.Models;

namespace Common.Tail
{
    public class Tail : IDisposable
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

        public void TailFile(CancellationToken ct)
        {
            using (StreamReader reader =
                new StreamReader(new FileStream(_fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
            {
                //start at the end of the file
                long lastMaxOffset = reader.BaseStream.Length;

                //while (_tailingFile)
                while (!ct.IsCancellationRequested)
                {
                    Thread.Sleep(100);

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
                reader.Close();
                Dispose();
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; 

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _messageService = null;
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }
      
        public void Dispose()
        {
            
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
             GC.SuppressFinalize(this);
        }
        #endregion
    }
}

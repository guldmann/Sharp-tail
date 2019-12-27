using Common.Messages.Services;
using Common.Models;
using System;
using System.IO;
using System.Threading;

namespace Common.Tail
{
    public class Tail : IDisposable
    {
        private readonly string _fileName;
        private MessageService _messageService = MessageService.Instance;
        private bool _tailingFile;
        private string _tabName;

        public Tail(string file, string tabName)
        {
            _fileName = file;
            _tailingFile = true;
            _tabName = tabName;

        }

        public void StopTailFile()
        {
            _tailingFile = false;
        }

        public void TailFile(CancellationToken ct)
        {
            using (StreamReader reader = new StreamReader(new FileStream(_fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
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

                    //Create tailfile info object
                    var tailFileInfo = new TaileFileInfo
                    {
                        Name = _fileName,
                        Size = reader.BaseStream.Length,
                        TabName = _tabName
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
                reader.DiscardBufferedData();
                reader.Dispose();
                Dispose();
            }
        }

        #region IDisposable Support

        private bool _disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _messageService = null;
                }

                _messageService = null;
                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion IDisposable Support
    }
}
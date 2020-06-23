using System;
using System.Collections.Generic;
using System.Windows;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;

namespace DietApplication
{
    interface IDisk
    {
        string ReadTextFile(string path);
    }

    class Disk : IDisk, IDisposable
    {
        string IDisk.ReadTextFile(string path)
        {
            //check file existence
            //check permissions
            //File.Exists(
            //// This function does two things: preserves ANSI special characters and removes the tilde (~) text qualifier
            //string _text = File.ReadAllText(source, Encoding.Default);
            //File.WriteAllText(destination, _text);
            return "";
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~Disk() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
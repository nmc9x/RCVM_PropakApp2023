using System;
using System.Collections.Generic;
using System.IO.MemoryMappedFiles;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML.Common.Controller
{
    public class MemoryMapHelper
    {
        private MemoryMappedFile memoryMappedFile;
        private MemoryMappedViewAccessor accessor;
        private bool isDisposed = false;

        public MemoryMapHelper(string mapName, long capacity)
        {
            memoryMappedFile = MemoryMappedFile.CreateOrOpen(mapName, capacity);
            accessor = memoryMappedFile.CreateViewAccessor(0, capacity);
        }

     
        public void WriteData(byte[] data, long offset)
        {
           
            accessor.WriteArray(offset, data, 0, data.Length);
         
        }

        public byte[] ReadData(long offset, int length)
        {
            byte[] data = new byte[length];
            accessor.ReadArray(offset, data, 0, length);
            return data;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    accessor.Dispose();
                    memoryMappedFile.Dispose();
                }
                isDisposed = true;
            }
        }
    }
}

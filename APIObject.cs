using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Memory.API
{
    public class APIObject : IDisposable
    {
        private int _allocatedObj;
        private bool _isDisposed = false;
        public APIObject(int arg)
        {
            MagicAPI.Allocate(arg);
            _allocatedObj = arg;
        }

        ~APIObject()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (_isDisposed)
                return;

            MagicAPI.Free(_allocatedObj);
            GC.SuppressFinalize(this);
            _isDisposed = true;
        }
    }
}
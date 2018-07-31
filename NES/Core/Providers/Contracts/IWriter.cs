using System;
using System.Collections.Generic;
using System.Text;

namespace NES.Core.Providers.Contracts
{
    public interface IWriter
    {
        void Write(string message);

        void WriteLine(string message);
    }
}

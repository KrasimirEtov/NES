using NES.Core.Commands;
using NES.Core.Commands.Contracts;
using NES.Core.Engine;
using NES.Entities.Assets;
using NES.Entities.Assets.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NES
{
    public class Startup
    {
        static void Main(string[] args)
        {
            Engine.Instance.Start();
        }
    }
}

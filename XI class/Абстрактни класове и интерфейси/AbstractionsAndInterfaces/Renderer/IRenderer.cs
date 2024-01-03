using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renderer
{
    internal interface IRenderer
    {
        void Write(string text);
        void WriteLine(string text);
    }
}

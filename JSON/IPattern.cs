
using System;
using System.Collections.Generic;
using System.Text;

namespace JSON
{
    public interface IPattern
    {
        IMatch Match(string text);
    }
}

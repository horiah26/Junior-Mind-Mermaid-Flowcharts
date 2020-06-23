using System;
using System.Collections.Generic;
using System.Text;

namespace JSON
{
    public interface IMatch
    {
        bool Success();
        string RemainingText();
    }
}

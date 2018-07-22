using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonNS.Helpers
{
    interface IClosableViewModel
    {
        event EventHandler CloseWindowEvent;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleControl
{
    public class CMenuItem
    {
        public string Caption { get; set; }
        public Action CallBack { get; set; }

        public CMenuItem(string itemCaption, Action callback = null)
        {
            Caption = itemCaption;
            CallBack = callback;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ISWeb.Security
{
    public class SignInLock
    {
        public bool IsLock { get; set; }
        public int TimeLock { get; set; }
        public double TimeUnLock { get; set; }
    }
}

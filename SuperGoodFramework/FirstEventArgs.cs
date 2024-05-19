using System;
namespace Framework
{
    public class FirstEventArgs : EventArgs
    {
        public string strData;
        public DateTime time;
        public FirstEventArgs(string strData, DateTime time)
        {
            this.strData = strData;
            this.time = time;
        }
    }
}

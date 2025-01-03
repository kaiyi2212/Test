using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Class
{
    public class DataReceivedEventArgs : EventArgs
    {
        public string Data { get; }

        // Constructor to initialize the event args with data
        public DataReceivedEventArgs(string data)
        {
            Data = data;
        }
    }
}

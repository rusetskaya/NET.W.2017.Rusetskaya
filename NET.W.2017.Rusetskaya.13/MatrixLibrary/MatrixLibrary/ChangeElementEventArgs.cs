using System;

namespace MatrixLibrary
{
    public class ChangeElementEventArgs : EventArgs
    {
        public ChangeElementEventArgs(string message, int i, int j)
        {
            this.Message = message;
        }

        public string Message
        {
            get;
        }

        public int FirstIndex
        {
            get;
        }

        public int SecondIndex
        {
            get;
        }
    }
}
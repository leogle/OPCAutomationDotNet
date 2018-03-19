using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GNL.Automation.Server
{
    public class OPCSvrException : Exception
    {
        //Fields
        private String descr;
        private int errCode;

        public int ErrCode
        {
            get { return errCode; }
            set { errCode = value; }
        }
        //Properties
        public String Descr
        {
            get { return descr; }
            set { descr = value; }
        }
        

        //Constructor
        static OPCSvrException() { }
        public OPCSvrException(String descr)
            : base(descr)
        {
            this.Descr = descr;
        }
        public OPCSvrException(String descr,int code)
            : base(descr)
        {
            this.Descr = descr;
            this.ErrCode = code;
        }
    }

    public class ClientExistException : OPCSvrException
    {
        public ClientExistException(String descr)
            : base(descr)
        {
        }
    }
}

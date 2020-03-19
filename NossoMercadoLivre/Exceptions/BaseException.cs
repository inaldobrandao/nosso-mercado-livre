using System;

namespace NossoMercadoLivre
{
    public class BaseException : Exception
    {
        public int Code { get; set; }
        public string Type { get; set; }

        public BaseException(string message) : base(message)
        {
        }

        public BaseException(string message, int code)
            : base(message)
        {
            this.Code = code;
            this.Type = "System.BaseException";
        }

        public BaseException(string message, int code, string type)
            : base(message)
        {
            this.Code = code;
            this.Type = type;
        }
    }
}

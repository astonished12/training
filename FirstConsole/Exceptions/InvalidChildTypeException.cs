using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlParserRender.Exceptions
{
    [Serializable]
    public class InvalidChildTypeException : Exception
    {
        public InvalidChildTypeException()
        {

        }

        public InvalidChildTypeException(string tag) : base(String.Format("Invalid child tag : {0}", tag))
        {

        }
    }
}

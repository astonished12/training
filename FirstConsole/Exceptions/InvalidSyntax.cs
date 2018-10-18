using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlParserRender.Exceptions
{
    [Serializable]
    public class InvalidSyntax : Exception
    {
        public InvalidSyntax()
        {

        }

        public InvalidSyntax(string messege): base(messege)
        {

        }
    }
}

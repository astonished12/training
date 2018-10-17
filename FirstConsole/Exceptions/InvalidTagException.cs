using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlParserRender.Exceptions
{
    [Serializable]
    public class InvalidTagException: Exception
    {
        public InvalidTagException()
        {

        }

        public InvalidTagException(string tag) : base(String.Format("Invalid tag name: {0}",tag))
        {

        }
    }
}

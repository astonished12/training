using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlParserRender.Exceptions
{
    [Serializable]
    public class DuplicateTagException : Exception
    {
        public DuplicateTagException()
        {

        }


        public DuplicateTagException(string tag) : base(String.Format("Duplicate tag : {0}", tag))
        {

        }
    }
}

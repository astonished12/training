using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlParserRender.Render
{
    public class Element
    {
        public string Content { get; set; }
        public virtual string GenerateHtml(int indentLevel)
        {
            return new String(Constants.Space, (indentLevel + 1) * Constants.IdentSize) + Content + Constants.NewLine;
        }
    }
}

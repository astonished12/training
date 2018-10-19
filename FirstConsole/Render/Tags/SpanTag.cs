using HtmlParserRender.Exceptions;
using HtmlParserRender.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlParserRender.Render.Tags
{
    public class SpanTag : Tag
    {
        public SpanTag():base(TagType.span)
        {

        }

        public override void AddChild(Element element)
        {
            Tag tag = element as Tag;
            if (tag != null)
            {
                throw new InvalidChildTypeException(string.Format(ExceptionMessage.InvalidSyntaxInChild + " at element {0}", tag.TagType.ToString()));
            }
            else
            {
                Children.Add(element);
            }
        }
    }
}

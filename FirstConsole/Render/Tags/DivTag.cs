using HtmlParserRender.Exceptions;
using HtmlParserRender.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtmlParserRender.Render.Tags
{
    public class DivTag : Tag
    {
        public DivTag() : base(TagType.div)
        {

        }

        public override void AddChild(Element element)
        {
            Tag tag = element as Tag;
            if (tag != null)
            {
                switch (tag.TagType)
                {
                    case TagType.div:
                    case TagType.p:
                    case TagType.h1:
                    case TagType.h2:
                    case TagType.h3:
                    case TagType.h4:
                    case TagType.input:
                    case TagType.span:
                        Children.Add(element);
                        break;

                    default:
                        throw new InvalidChildTypeException(string.Format(ExceptionMessage.InvalidSyntaxInChild + " at element {0}", tag.TagType.ToString()));
                }
            }
            else
            {
                Children.Add(element);
            }
        }
    }
}

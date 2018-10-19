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
        public DivTag() : base(TagType.body)
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
                        Children.Add(element);
                        break;

                    case TagType.p:
                        Children.Add(element);
                        break;

                    case TagType.h1:
                        Children.Add(element);
                        break;

                    case TagType.h2:
                        Children.Add(element);
                        break;
                    case TagType.h3:
                        Children.Add(element);
                        break;

                    case TagType.h4:
                        Children.Add(element);
                        break;

                    default:
                        throw new InvalidChildTypeException(string.Format(ExceptionMessage.InvalidSyntaxInChild + " at element {0}", tag.TagType.ToString()));
                }
            }
        }
    }
}

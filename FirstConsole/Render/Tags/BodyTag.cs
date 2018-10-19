using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlParserRender.Exceptions;
using HtmlParserRender.Utils;

namespace HtmlParserRender.Render.Tags
{
    public class BodyTag : Tag
    {
        public BodyTag() : base(TagType.body)
        {

        }

        public override void AddChild(Element element)
        {
            Tag tag = element as Tag;
            if (tag != null)
            {
                string tagType = tag.TagType.ToString();
                switch (tag.TagType)
                {
                    case TagType.div:
                    case TagType.p:
                    case TagType.h1:
                    case TagType.h2:
                    case TagType.h3:
                    case TagType.h4:
                    case TagType.span:
                        Children.Add(element);
                        break;
                    default:
                        throw new InvalidChildTypeException(tagType);
                }
            }
            else
            {
                Children.Add(element);
            }
        }
    }
}

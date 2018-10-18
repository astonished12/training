using HtmlParserRender.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlParserRender.Utils;

namespace HtmlParserRender.Render.Tags
{
    public class HeadTag:Tag
    {
        public HeadTag():base(TagType.head)
        {

        }

        public override void AddChild(Element element)
        {
            Tag tag = element as Tag;
            if (tag != null)
            {
                switch (tag.TagType)
                {
                    case TagType.title:
                        bool isInList = Children.Any(Element => (Element as Tag).TagType == TagType.title);
                        if (isInList) throw new DuplicateTagException(tag.TagType.ToString());
                        Children.Add(element);
                        break;

                    default:
                        throw new InvalidSyntax(ExceptionMessage.InvalidSyntaxHeadElement);
                }
            }

        }
    }
}

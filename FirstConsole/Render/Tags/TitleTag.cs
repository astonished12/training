using HtmlParserRender.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtmlParserRender.Render.Tags
{
    public class TitleTag : Tag
    {
        public TitleTag() : base(TagType.title)
        {

        }

        public override void AddChild(Element element)
        {
            Tag tag = element as Tag;
            if (tag != null)
            {
                /*switch (tag.TagType)
                {
                    case TagType.title:
                        bool isInList = Children.Any(Element => (Element as Tag).TagType == TagType.title);
                        if (isInList) throw new DuplicateTagException(tag.TagType.ToString());
                        Children.Add(element);
                        break;

                    default:
                        throw new InvalidSyntax("Invalid syntax in title content");
                }*/
                throw new InvalidSyntax("Invalid syntax in title content");

            }
            else
            {
                Children.Add(element);
            }

        }
    }
}

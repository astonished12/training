using HtmlParserRender.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtmlParserRender.Render
{
    public class HtmlTag : Tag
    {
        public HtmlTag() : base(TagType.html)
        {

        }

        public override void AddChild(Element element)
        {
            Tag tag = element as Tag;
            if (tag != null)
            {
                switch (tag.TagType)
                {
                    case TagType.body:
                        bool isInList = Children.Any(Element => (Element as Tag).TagType == TagType.body);
                        if (isInList) throw new DuplicateTagException(tag.TagType.ToString());
                        Children.Add(element);
                        break;

                    case TagType.head:
                        isInList = Children.Any(Element => (Element as Tag).TagType == TagType.head);
                        if (isInList) throw new DuplicateTagException(tag.TagType.ToString());
                        Children.Add(element);
                        break;

                    default:
                        throw new InvalidSyntax("Invalid syntax in html content");
                }
            }

        }
    }
}

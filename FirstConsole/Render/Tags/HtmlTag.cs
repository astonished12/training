using HtmlParserRender.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlParserRender.Utils;

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
            string tagType = tag.TagType.ToString();
            if (tag != null)
            {
                switch (tag.TagType)
                {
                    case TagType.body:
                        bool isInList = Children.Any(Element => (Element as Tag).TagType == TagType.body);
                        bool hasHeadInFront = (Children.Last() as Tag).TagType == TagType.head;
                        if (isInList) throw new DuplicateTagException(tagType);
                        if(!hasHeadInFront) throw new InvalidSyntax(ExceptionMessage.InvalidSyntaxBodyAfterHead);
                        Children.Add(element);
                        break;

                    case TagType.head:
                        isInList = Children.Any(Element => (Element as Tag).TagType == TagType.head);
                        if (isInList) throw new DuplicateTagException(tag.TagType.ToString());
                        Children.Add(element);
                        break;

                    default:
                        throw new InvalidChildTypeException(tagType);
                }
            }

        }
    }
}

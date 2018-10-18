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
            string tagType = tag.TagType.ToString();
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

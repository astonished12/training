﻿using System;
using System.Collections.Generic;
using System.Text;
using HtmlParserRender.Exceptions;
using HtmlParserRender.Utils;

namespace HtmlParserRender.Render.Tags
{
    public class BaseTag : Tag
    {
        public BaseTag() : base(TagType.style)
        {
            IsSelfClosing = true;
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

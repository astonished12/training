﻿using HtmlParserRender.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlParserRender.Utils;

namespace HtmlParserRender.Render.Tags
{
    public class H1Tag : Tag
    {
        public H1Tag() : base(TagType.h1)
        {

        }

        public override void AddChild(Element element)
        {
            Tag tag = element as Tag;
            if (tag != null)
            {
                throw new InvalidSyntax(ExceptionMessage.InvalidSyntaxTitleElement);
            }
            else
            {
                Children.Add(element);
            }

        }
    }
}

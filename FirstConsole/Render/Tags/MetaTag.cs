using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlParserRender.Render.Tags
{
    public class MetaTag : Tag
    {
        public MetaTag() : base(TagType.meta)
        {
            IsSelfClosing = true;
        }

        public override void AddChild(Element element)
        {
            return;
        }
    }
}

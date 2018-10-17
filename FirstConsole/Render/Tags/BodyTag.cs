using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlParserRender.Render.Tags
{
    public class BodyTag : Tag
    {
        public BodyTag() : base(TagType.body)
        {
            
        }

        public override void AddChild(Element tag)
        {
            base.AddChild(tag);
        }
    }
}

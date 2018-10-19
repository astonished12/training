using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlParserRender.Render.Tags
{
    public class InputTag : Tag
    {
        public InputTag() : base(TagType.input)
        {
            IsSelfClosing = true;
        }

        public override void AddChild(Element element)
        {
            return;
        }
    }
}

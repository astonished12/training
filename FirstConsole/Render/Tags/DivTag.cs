using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlParserRender.Render.Tags
{
    public class DivTag : Tag
    {
        public DivTag() : base(TagType.body)
        {

        }

        public override void AddChild(Element element)
        {   
            base.AddChild(element);
        }
    }
}

using HtmlParserRender.Render;
using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlParserRender
{
    public class NodeInfo
    {
        public TagType Type { get; set; }
        public bool TagIsClosed { get; set; }
        public Dictionary<string, string> Attributes { get; set; }
        public Element ParentContent { get; set; }

        public NodeInfo(TagType type, bool status, Dictionary<string,string> attributes, Element content)
        {
            Type = type;
            TagIsClosed = status;
            Attributes = attributes;
            ParentContent = content;
        }

    }
}

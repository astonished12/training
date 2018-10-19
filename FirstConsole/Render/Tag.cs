using HtmlParserRender.Render;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HtmlParserRender.Render
{
    public class Tag : Element
    {
        private TagType Type { get; set; }
        private Dictionary<string, string> Attributes { get; set; }
        public List<Element> Children { get; private set; }
        public bool IsSelfClosing { get; protected set; }

        private Tag() { }

        public Tag(TagType type)
        {
            Type = type;
            Children = new List<Element>();
            Attributes = new Dictionary<string, string>();
        }

        private void SaveHtml(string filePath, string htmlCode)
        {
            System.IO.File.WriteAllText(filePath, htmlCode);

        }

        public override string GenerateHtml(int indentLevel)
        {
            StringBuilder htmlBuilder = new StringBuilder();
            htmlBuilder.Append(GetOpenTagString(indentLevel));

            if (Attributes.Count > 0)
            {
                htmlBuilder.Append(Constants.Space);
                foreach (var attribute in Attributes)
                {
                    string attributePair = attribute.Key + Constants.Equal + Constants.Quote + attribute.Value + Constants.Quote;
                    attributePair = attributePair.Replace("\"\"", Constants.Quote);
                    htmlBuilder.Append(attribute.Equals(Attributes.Last()) == true ? attributePair : attributePair + Constants.Space);
                }
            }


            htmlBuilder.Append(Constants.RightDiamondNewLine);


            if (Children.Count > 0)
            {
                foreach (var child in Children)
                {
                    htmlBuilder.Append(child.GenerateHtml(indentLevel + 1));
                }
                htmlBuilder.Append(GetClosedTagString(indentLevel));
            }
            else
            {
                if (!IsSelfClosing) htmlBuilder.Append(GetClosedTagString(indentLevel));
            }

            return htmlBuilder.ToString();
        }

        private string GetOpenTagString(int indentLevel)
        {
            return new String(Constants.Space, indentLevel * Constants.IdentSize) + Constants.LeftDiamond + Type.ToString();
        }

        private string GetClosedTagString(int indentLevel)
        {
            return new String(Constants.Space, indentLevel * Constants.IdentSize) + Constants.ClosedLeftDiamond + Type.ToString() + Constants.RightDiamondNewLine;
        }


        public virtual void AddChild(Element element)
        {
            Children.Add(element);
        }

        public void AddAttribute(string attributeKey, string attributeValue)
        {
            Attributes.Add(attributeKey, attributeValue);
        }

        public void SetContent(Element element)
        {
            Content = element.Content;
        }

        public void Render()
        {
            Console.WriteLine(GenerateHtml(0));
        }

        public TagType TagType { get { return Type; } }

        public void Render(string filePath)
        {
            string htmlCode = GenerateHtml(0);
            SaveHtml(filePath, htmlCode);
        }
    }
}

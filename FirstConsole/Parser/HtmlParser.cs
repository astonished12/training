using HtmlParserRender.Render;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace HtmlParserRender
{
    public class HtmlParser
    {
        private Regex regex = new Regex(Constants.AttributesTagRegex);

        public HtmlParser() { }

        private bool IsClosedTag(string tag)
        {
            return tag[1] == Constants.Slash;
        }

        private Dictionary<string, string> GetAttributesFromTagData(string attributesData)
        {
            string[] tagData = attributesData.Split(Constants.Space, 2);
            Dictionary<string, string> attrs = new Dictionary<string, string>();

            MatchCollection attributesCatchedCollection = regex.Matches(attributesData);
            foreach (Match match in attributesCatchedCollection)
            {
                string[] pairData = match.Value.Split(Constants.Equal);
                attrs.Add(pairData[0], pairData[1]);
            }

            return attrs;
        }

        private bool CheckAttributes(string attributesData)
        {
            MatchCollection attributesCatchedCollection = regex.Matches(attributesData);
            return attributesCatchedCollection.Count > 0;
        }

        private string GetTagTypeFromString(string data)
        {
            string[] tagData = data.Split(Constants.Space, 2);
            if (tagData.Length > 1)
            {
                if (CheckAttributes(tagData[1]) == false) throw new Exception("invalid sytnax");
                return IsClosedTag(tagData[0]) ? tagData[0].Substring(2, tagData[0].Length - 2) : tagData[0].Substring(1, tagData[0].Length - 1);
            }
            else
            {
                return IsClosedTag(data) ? data.Substring(2, data.Length - 3) : data.Substring(1, data.Length - 2);
            }
        }

        private string GetContentFromTagString(string tagString)
        {
            return tagString.Split(Constants.LeftDiamond)[0];
        }

        private bool IsValidTag(string tag)
        {
            object result;
            Enum.TryParse(typeof(TagType), tag, true, out result);
            return result != null;
        }

        private Tag CreateTag(string tagType)
        {
            tagType = Constants.NameSpacesTags + tagType.Substring(0, 1).ToUpper() + tagType.Substring(1).ToLower() + Constants.Tag;
            Type tempType = Type.GetType(tagType);
            Tag result = Activator.CreateInstance(tempType) as Tag;

            return result;
        }

        private NodeInfo FindNextTag(string currentDoc, ref int position)
        {
            StringBuilder tagBuilder = new StringBuilder();
            if (currentDoc[position] != Constants.LeftDiamond && position == 0)
            {
                throw new Exception(Constants.SyntaxException);
            }
            else
            {
                tagBuilder.Append(currentDoc[position]);
                string content = Constants.EmptyString;
                for (int index = position + 1; index < currentDoc.Length; index++)
                {
                    tagBuilder.Append(currentDoc[index]);
                    string builderContent = tagBuilder.ToString();
                    switch (currentDoc[index])
                    {
                        case Constants.LeftDiamond:
                            content = builderContent.Substring(0, builderContent.Length - 1).Trim();
                            tagBuilder.Clear();
                            tagBuilder.Append(currentDoc[index]);
                            break;

                        case Constants.RightDiamond:
                            string tag = GetTagTypeFromString(tagBuilder.ToString());
                            if (IsValidTag(tag))
                            {
                                TagType type = (TagType)Enum.Parse(typeof(TagType), tag);
                                position = index + 1;
                                Element elementContent = new Element() { Content = content };
                                return new NodeInfo(type, IsClosedTag(builderContent), GetAttributesFromTagData(builderContent), elementContent);
                            }
                            break;
                        default:
                            break;
                    }

                }
                position = currentDoc.Length;
            }

            return null;
        }


        public Tag Parse(string document)
        {
            int currentPostion = 0;
            NodeInfo nodeInfo;
            Stack<Tag> stackHtmlParser = new Stack<Tag>();
            Tag root;

            nodeInfo = FindNextTag(document, ref currentPostion);

            if (nodeInfo.TagIsClosed) throw new Exception(Constants.SyntaxException);

            root = CreateTag(nodeInfo.Type.ToString());
            stackHtmlParser.Push(root);

            while (stackHtmlParser.Count > 0 && currentPostion < document.Length)
            {
                nodeInfo = FindNextTag(document, ref currentPostion);
                Tag currentTag = CreateTag(nodeInfo.Type.ToString());
                nodeInfo.Attributes.ToList().ForEach(item => currentTag.AddAttribute(item.Key, item.Value));

                if (nodeInfo.TagIsClosed && (nodeInfo.Type == stackHtmlParser.Peek().TagType))
                {
                    if (nodeInfo.ParentContent.Content.Length > 0)
                        stackHtmlParser.Peek().AddChild(nodeInfo.ParentContent);
                    stackHtmlParser.Pop();
                }

                if (stackHtmlParser.Count > 0 && !nodeInfo.TagIsClosed)
                {
                    if (nodeInfo.ParentContent.Content.Length > 0)
                    {
                        stackHtmlParser.Peek().AddChild(nodeInfo.ParentContent);
                    }

                    stackHtmlParser.Peek().AddChild(currentTag);
                    stackHtmlParser.Push(currentTag);
                }
            }

            if (stackHtmlParser.Count > 0) throw new Exception(Constants.SyntaxException);

            return root;


        }

    }
}

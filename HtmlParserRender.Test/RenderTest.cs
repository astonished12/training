using HtmlParserRender.Exceptions;
using HtmlParserRender.Render;
using HtmlParserRender.Render.Tags;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlParserRender.Test
{
    [TestFixture]
    public class RenderTest
    {

        private readonly HtmlTag html = new HtmlTag();
        private readonly HeadTag head = new HeadTag();
        private readonly TitleTag title = new TitleTag();

        private void DoubleHeadInHtml()
        {
            html.AddChild(head);
            html.AddChild(head);
        }

        [Test]
        public void Tests()
        {
            Assert.Throws<DuplicateTagException>(() => DoubleHeadInHtml());
        }


    }
}

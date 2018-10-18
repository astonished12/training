using HtmlParserRender.Exceptions;
using HtmlParserRender.Render;
using HtmlParserRender.Render.Tags;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlParserRender.Tests
{
    [TestClass]
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

        [TestMethod]
        public void TestMethod1()
        {
            Assert.ThrowsException<DuplicateTagException>(() => DoubleHeadInHtml());
        }
    }
}

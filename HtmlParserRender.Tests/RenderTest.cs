using HtmlParserRender.Exceptions;
using HtmlParserRender.Render;
using HtmlParserRender.Render.Tags;
using HtmlParserRender.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HtmlParserRender.Tests
{
    [TestClass]
    public class RenderTest
    {
        private readonly HtmlTag _html = new HtmlTag();
        private readonly HeadTag _head = new HeadTag();
        private readonly TitleTag _title = new TitleTag();

        private void DoubleHeadInHtml()
        {
            _html.AddChild(_head);
            _html.AddChild(_head);
        }

        private void TitleContentIsElement()
        {
            _title.AddChild(_head);
        }

        [TestMethod]
        public void TestRenderMethods()
        {
            Assert.ThrowsException<DuplicateTagException>(() => DoubleHeadInHtml());
            InvalidSyntax ex = Assert.ThrowsException<InvalidSyntax>(() => TitleContentIsElement());
            Assert.AreEqual(ExceptionMessage.InvalidSyntaxTitleElement,ex.Message);
        }
    }
}

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
        private readonly BodyTag _body = new BodyTag();
        private readonly MetaTag _meta = new MetaTag();
        private readonly StyleTag _style = new StyleTag();
        private readonly H1Tag _h1Tag = new H1Tag();
        private readonly PTag _pTag = new PTag();
        private readonly H2Tag _h2Tag = new H2Tag();
        private readonly DivTag _divTag = new DivTag();
        private readonly SpanTag _spanTag = new SpanTag();

        private void DoubleHeadInHtmlCase()
        {
            _html.AddChild(_head);
            _html.AddChild(_head);
        }
        private void HtmlContainsOnlyHeadAndBody()
        {
            _html.AddChild(_h1Tag);
        }

        private void TitleContentIsElement()
        {
            _title.AddChild(_head);
        }

        [TestMethod]
        public void TestRenderHeadExceptions()
        {
            Assert.ThrowsException<DuplicateTagException>(() => DoubleHeadInHtmlCase());
            InvalidChildTypeException ex = Assert.ThrowsException<InvalidChildTypeException>(() => HtmlContainsOnlyHeadAndBody());

        }
    }
}

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
        private  HtmlTag _html = new HtmlTag();
        private  HeadTag _head = new HeadTag();
        private  TitleTag _title = new TitleTag();     
        private  BodyTag _body = new BodyTag();
        private  MetaTag _meta = new MetaTag();
        private  StyleTag _style = new StyleTag();
        private  H1Tag _h1Tag = new H1Tag();
        private  PTag _pTag = new PTag();
        private  H2Tag _h2Tag = new H2Tag();
        private  DivTag _divTag = new DivTag();
        private  SpanTag _spanTag = new SpanTag();


        private void CreateSUTobjects()
        {
           _html = new HtmlTag();
           _head = new HeadTag();
           _title = new TitleTag();
           _body = new BodyTag();
           _meta = new MetaTag();
          _style = new StyleTag();
          _h1Tag = new H1Tag();
          _pTag = new PTag();
         _h2Tag = new H2Tag();
         _divTag = new DivTag();
         _spanTag = new SpanTag();
    }


        private void DoubleHeadInHtmlCase()
        {
            CreateSUTobjects();
            _html.AddChild(_head);
            _html.AddChild(_head);
        }
        private void DoubleTItleInHeadCase()
        {
            CreateSUTobjects();
            _head.AddChild(_title);
            _head.AddChild(_title);
        }

        private void HtmlContainsOnlyHeadAndBody()
        {
            CreateSUTobjects();
            _html.AddChild(_h1Tag);
        }
        private void HeadContainsOnlyTitleStyleMeta()
        {
            CreateSUTobjects();
            _head.AddChild(_title);
            _head.AddChild(_meta);
            _head.AddChild(_style);

            _head.AddChild(_h1Tag);
        }
        private void TitleContentIsElement()
        {
            _title.AddChild(_head);
        }

        [TestMethod]
        public void TestRenderHtmlExceptions()
        {
            CreateSUTobjects();
            Assert.ThrowsException<DuplicateTagException>(() => DoubleHeadInHtmlCase());
            InvalidChildTypeException ex = Assert.ThrowsException<InvalidChildTypeException>(() => HtmlContainsOnlyHeadAndBody());
        }

        [TestMethod]
        public void TestRenderHeadExceptions()
        {
            Assert.ThrowsException<DuplicateTagException>(() => DoubleTItleInHeadCase());
            InvalidChildTypeException ex = Assert.ThrowsException<InvalidChildTypeException>(() => HeadContainsOnlyTitleStyleMeta()); 
        }
    }
}

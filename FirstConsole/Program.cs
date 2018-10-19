using HtmlParserRender.Exceptions;
using HtmlParserRender.Render;
using HtmlParserRender.Render.Tags;
using System;

namespace HtmlParserRender
{
    class Program
    {
        
        static Tag ParserExample()
        {
            HtmlParser htmlParser = new HtmlParser();
            //Tag tag = htmlParser.Parse("<html><head><title>Thetitle</title></head><body>Sunca<div id=\"11 mata\" id2=\"1x1\" id1=\"11\">Muculetz1<div>Muculetz</div></div>End SUnca</body></html>");
            string text = System.IO.File.ReadAllText(Constants.filePath);
            Tag tag = htmlParser.Parse(text);
            return tag;
        }

        /*static void RenderExample()
        {
            try
            {
                HtmlTag html = new HtmlTag();
                HeadTag head = new HeadTag();
                BodyTag body = new BodyTag();
                TitleTag title = new TitleTag();
                MetaTag meta = new MetaTag();
                StyleTag style = new StyleTag();
                H1Tag h1Tag = new H1Tag();
                PTag pTag1 = new PTag();
                H2Tag h2Tag = new H2Tag();
                PTag pTag2 = new PTag();
                DivTag divTag1 = new DivTag();
                DivTag divTag2 = new DivTag();
                DivTag divTag3 = new DivTag();
                SpanTag spanTag = new SpanTag();
            

                Element titleContent = new Element() { Content = "The title" };
                Element styleContent = new Element() { Content = " p{             color: white;             background-color: 009900;             width: 400px;         }         h1         {             color: white;             background-color: 009900;             width: 400px;         }         h2         {             color: white;             background-color: 009900;             width: 400px;         } " };
                Element h1Content = new Element() { Content = "GeeksforGeeks" };
                Element p1Content = new Element() { Content = "How many times were you frustrated while looking out     for a good collection of programming/algorithm/interview     questions? What did you expect and what did you get?     This portal has been created to provide well written,     well thought and well-explained solutions for selected questions. " };
                Element h2Content = new Element() { Content = "GeeksForGeeks" };
                Element p2Content = new Element() { Content = "GCET is an entrance test for the extensive classroom programme     by GeeksforGeeks to build and enhance Data Structures and Algorithm     concepts, mentored by Sandeep Jain (Founder & CEO, GeeksforGeeks).     He has 7 years of teaching experience and 6 years of industry experience. " };
                Element bodyContent1 = new Element() { Content = "hello from body 1" };
                Element bodyContent2 = new Element() { Content = "hello from body 2" };
                Element bodyContent3 = new Element() { Content = "hello from body 3" };


                html.AddChild(head);
                html.AddChild(body);

                head.AddChild(title);
                head.AddChild(meta);
                head.AddChild(style);


                body.AddAttribute("class", ".class1");

                body.AddChild(bodyContent1);
                body.AddChild(h1Tag);
                body.AddChild(divTag1);
                body.AddChild(divTag3);
                body.AddChild(bodyContent2);
                body.AddChild(pTag1);
                body.AddChild(h2Tag);
                body.AddChild(pTag2);
                body.AddChild(bodyContent3);

                divTag1.AddChild(divTag2);
                divTag1.AddChild(spanTag);


                title.AddChild(titleContent);
                style.AddChild(styleContent);
                h1Tag.AddChild(h1Content);
                pTag1.AddChild(p1Content);
                h2Tag.AddChild(h2Content);
                pTag2.AddChild(p2Content);

                //html.Render();
                html.Render(Constants.filePath);
            }
            catch (InvalidSyntax ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (InvalidTagException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (DuplicateTagException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {

            }
        }
        */

        static void Main(string[] args)
        {
            Tag root = ParserExample();
            root.Render();
        }
    }
}

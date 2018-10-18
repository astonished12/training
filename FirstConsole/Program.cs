using HtmlParserRender.Exceptions;
using HtmlParserRender.Render;
using HtmlParserRender.Render.Tags;
using System;

namespace HtmlParserRender
{
    class Program
    {
        
        static void ParserExample()
        {
            HtmlParser htmlParser = new HtmlParser();
            //Tag tag = htmlParser.Parse("<html><head><title>Thetitle</title></head><body>Sunca<div id=\"11 mata\" id2=\"1x1\" id1=\"11\">Muculetz1<div>Muculetz</div></div>End SUnca</body></html>");
            string text = System.IO.File.ReadAllText(Constants.filePath);
            Tag tag = htmlParser.Parse(text);
            tag.Render();

        }

        static void RenderExample()
        {
            try
            {
                HtmlTag html = new HtmlTag();
                HeadTag head = new HeadTag();
                BodyTag body = new BodyTag();
                TitleTag title = new TitleTag();

                Element titleContent = new Element() { Content = "The title" };

                html.AddChild(head);
                html.AddChild(body);

                head.AddChild(title);
                title.AddChild(titleContent);

                html.Render();
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

        static void Main(string[] args)
        {
            //RenderExample();
            ParserExample();
        }
    }
}

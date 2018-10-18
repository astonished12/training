using HtmlParserRender.Exceptions;
using HtmlParserRender.Render;
using HtmlParserRender.Render.Tags;
using System;

namespace HtmlParserRender
{
    class Program
    {

        static void RenderExample()
        {

            Tag html = new Tag(TagType.html);
            Tag head = new Tag(TagType.head);
            Tag body = new Tag(TagType.body);

            Tag div = new Tag(TagType.div);
            Element divContent = new Element() { Content = "Div content" };
            div.AddChild(divContent);



            Tag div1 = new Tag(TagType.div);

            Tag title = new Tag(TagType.title);
            Element titleContent = new Element() { Content = "The title" };
            title.AddChild(titleContent);


            html.AddChild(head);
            head.AddChild(title);

            html.AddChild(body);

            body.AddChild(div);

            div.AddChild(div1);
            div.AddAttribute("id", "1");
            div.AddAttribute("class", ".class1");
            div.AddChild(divContent);


            div1.AddAttribute("id", "1");
            div1.AddAttribute("class", ".class2");

            //html.Render(); // console output 
            //html.Render(Constants.filePath);

        }

        static void ParserExample()
        {
            HtmlParser htmlParser = new HtmlParser();
            //Tag tag = htmlParser.Parse("<html><head><title>Thetitle</title></head><body>Sunca<div id=\"11 mata\" id2=\"1x1\" id1=\"11\">Muculetz1<div>Muculetz</div></div>End SUnca</body></html>");
            string text = System.IO.File.ReadAllText(Constants.filePath);
            Tag tag = htmlParser.Parse(text);
            tag.Render();

        }

        static void TestException()
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

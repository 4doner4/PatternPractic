using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;

namespace Pattern_project.helpers
{
    abstract class AbstractFactory
    {
        public abstract AbstractProductA CreateProductA();
        public abstract AbstractProductB CreateProductB();
    }
    abstract class AbstractProductA
    {
        public abstract HtmlString ShowSomething(IHtmlHelper html);
    }

    abstract class AbstractProductB
    {
        public abstract HtmlString ShowSomething(IHtmlHelper html);
    }
    // Factory for information lists
        
    class ConcreteFactory1 : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA1();
        }

        public override AbstractProductB CreateProductB()
        {
            return new ProductB1();
        }
    }
    //factory for buttons


    class ConcreteFactory2 : AbstractFactory
    {
        public override AbstractProductA CreateProductA()
        {
            return new ProductA2();
        }

        public override AbstractProductB CreateProductB()
        {
            return new ProductB2();
        }
    }

    class ProductA1 : AbstractProductA
    {
        public override HtmlString ShowSomething(IHtmlHelper html)
        {
            return ListForInformationProger(html);
        }
        public static HtmlString ListForInformationProger(IHtmlHelper html)
        {
            string[] items = new string[] { "Аметов Дамир", "Еволенко Алексей", "Мендешев Темирлан"};
            string result = "<ul class=\"list-group list-group-flush\">"; ;
            foreach (string item in items)
            {
                result = $"{result}<li class=\"list-group-item\">{item}</li>";
            }
            result = $"{result}</ul>";
            return new HtmlString(result);
        }


    }
    class ProductB1 : AbstractProductB
    {
        public override HtmlString ShowSomething(IHtmlHelper html)
        {
            return ListForInformationCipher(html);
        }
        public static HtmlString ListForInformationCipher(IHtmlHelper html)
        {
            string[] items = new string[] { "Атбаш", "Цезарь", "XOR", "ADFGX", "Вижинер" };
            string result = "<ul class=\"list-group list-group-flush\">";
            foreach (string item in items)
            {
                result = $"{result}<li class=\"list-group-item\">{item}</li>";
            }
            result = $"{result}</ul>";
            return new HtmlString(result);
        }


    }


    class ProductA2 : AbstractProductA
    {
        public override HtmlString ShowSomething(IHtmlHelper html)
        {
            return CreateButtons(html);
        }
        public static HtmlString CreateButtons(IHtmlHelper html)
        {
            string[] items = new string[] { "Privacy", "Index", "Errors" };
            string result = ""; 
            result += "<a href = \"" + items[0] + "\" ><button  class=\"btn btn-primary\" type=\"submit\">Privacy</button></a>";
            result += "<a href = \"" + items[1] + "\" ><button  class=\"btn btn-primary\" type=\"submit\">Index</button></a>";
            result += "<a href = \"" + items[2] + "\" ><button  class=\"btn btn-primary\" type=\"submit\">Errors</button></a>";

            return new HtmlString(result);
        }


    }

    class ProductB2 : AbstractProductB
    {
        public override HtmlString ShowSomething(IHtmlHelper html)
        {
            return ShowImages(html);
        }
        public static HtmlString ShowImages(IHtmlHelper html)
        {
            string[] items = new string[] { "58f6a01695be445d0e40b92f33a0c8b5.jpg", "100x64_3 (1).jpg", "maxresdefault.jpg" };
            string result = "";
            foreach (string item in items)
            {
    
                result = $"{result}  <img src = \"/images/{item}\" class = \" newimages \">";
            }
            return new HtmlString(result);
        }


    }
    class Factorys
    {
        private AbstractProductA abstractProductA;
        private AbstractProductB abstractProductB;

        public Factorys(AbstractFactory factory)
        {
            abstractProductB = factory.CreateProductB();
            abstractProductA = factory.CreateProductA();
        }
        public HtmlString showHtmlHelperA(IHtmlHelper html)
        {
            return abstractProductA.ShowSomething(html);
        }
        public HtmlString showHtmlHelperB(IHtmlHelper html)
        {
            return abstractProductB.ShowSomething(html);

        }
    }

}

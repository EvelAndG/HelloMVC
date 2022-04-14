using Microsoft.AspNetCore.Mvc;

namespace HelloMVC.Controllers
{
    public class HelloController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            string html = "<form method='post'>" +
                "<input type ='text' name ='name' />" +
                "<select id='languages' name='languages'>" +
                "<option value='English'>English</option>"+
                "<option value='Spanish'>Spanish</option>" +
                "<option value='German'>German</option>" +
                "<option value='French'>French</option>" +
                "<option value='Japanese'>Japanese</option>" +
                "<input type ='submit' value = 'Greet me!' />" +
                "</form>";

            //(Content to return, specify content type)
            //Browser will not render html unless specified as html
            
            return Content(html, "text/html");          

        }

       public static string CreateMessage(string language, string name)
        {
            string greeting = language;
            if (language.Equals("English"))
            {
                greeting = "Hello, ";
            }
            if (language.Equals("Spanish"))
            {
                greeting = "Hola ";
            }
            if (language.Equals("German"))
            {
                greeting = "Hallo ";
            }
            if (language.Equals("French"))
            {
                greeting = "Salut ";
            }
            if (language.Equals("Japanese"))
            {
                greeting = "Kon'nichiwa ";
            }
            return greeting+" "+name;
        }      

        //Hello
        [Route("/Hello")]
        [HttpPost]
        public IActionResult Display(string greeting = "Hello", string name = "World")
        {
            string formValue = "";

            if (!string.IsNullOrEmpty(Request.Form["languages"]))
            {
                formValue = Request.Form["languages"].ToString();
            }
            return Content(CreateMessage(formValue, name), "text/html");
        }

        //Alter route to controller to be: /Hello/Aloha
        // [Route("/Hello/Aloha")]

        //Handle requests to /Hello/NAME (URL Segment)
        [Route("/Hello/{name}")]
        public IActionResult Index2(string name)
        {
            return Content(string.Format("<h1>Hello, {0}</h1>", name), "text/html");
        }
        public IActionResult Goodbye()
        {
            return Content("Goodbye World");
        }
    }
}

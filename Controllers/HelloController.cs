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
                "<select id='languages'>" +
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

       //public static createMessage() ????

      

        //Hello
        [Route("/Hello")]
        [HttpPost]
        public IActionResult Display(string greeting = "Hello", string name = "World")
        {
            return Content(string.Format("<h1>{0} {1}</h1>",greeting, name), "text/html");


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

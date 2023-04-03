using Microsoft.AspNetCore.Mvc;


// 2.	Microsoft.AspNetCore.Mvc 
namespace MyProject.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public string Index()
        {
            return "Hello, world!";
        }
    }
}

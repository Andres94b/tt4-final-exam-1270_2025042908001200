namespace backend.Controllers{
    using Microsoft.AspNetCore.Mvc;
    
    public class Expense{
        public string ID {get; set;}
        public string Description {get; set;}
        public string Amount {get; set;}
        public string Date {get; set;}
        public string Category {get; set;}
    }

    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase{

        
        [HttpGet]
        public IActionResult ApiIsWorking(){
            return Ok(new{Status="Success", Message="API is working!"});
        }

    }
}
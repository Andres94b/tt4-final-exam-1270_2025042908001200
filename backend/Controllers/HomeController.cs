namespace backend.Controllers{
    using Microsoft.AspNetCore.Mvc;
    using backend.Data;
    
    public class Expense{
        public string Id {get; set;}
        public string Description {get; set;}
        public string Amount {get; set;}
        public string Date {get; set;}
        public string Category {get; set;}
    }

    [ApiController]
    [Route("")]
    public class HomeController : ControllerBase{

        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public IActionResult ApiIsWorking(){
            return Ok(new{Status="Success", Message="API is working!"});
        }

        [HttpPost]
        public async Task<ActionResult<Expense>> PostExpense(Expense expense)
        {
            _context.Expense.Add(expense);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(expense), new { id = expense.Id }, expense);
        }

    }
}
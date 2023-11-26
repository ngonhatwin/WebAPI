using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyWeb.Data;

namespace MyWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly DbContextProduct context_;

        public AccountController(DbContextProduct context)
        {
            context_ = context;
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            var list_Account = context_.Accounts.ToList();
            return Ok(list_Account);
        }

        [HttpGet("{id}")]

        public IActionResult GetByID(string id)
        {
            var account = context_.Accounts.SingleOrDefault(ac => ac.ID == Guid.Parse(id));
            if (account == null)
            {
                return BadRequest();
            }
            return Ok(account);

        }
        [HttpPost]
        public IActionResult addAccount(Models.Account account)
        {
            try
            {
                var new_account = new Data.Account
                {
                    FirstName = account.FirstName,
                    LastName = account.LastName,
                    Email = account.Email,
                    PassWord = account.PassWord,
                };
                context_.Add(new_account);
                context_.SaveChanges();
                return Ok(new_account);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}

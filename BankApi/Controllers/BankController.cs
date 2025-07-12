using BankApi.Business;
using BankApi.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BankApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class BankController : ControllerBase
    {

        private IBankService _bankService;

        public BankController(IBankService bankService) {
            _bankService = bankService;
        }

       [HttpGet]
        public IActionResult GetAll(bool? isActive, int page = 1, int pageSize = 10)
        {
            var pagedData = _bankService.List(isActive, page, pageSize);
            return Ok(pagedData);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var bank = _bankService.Get(b => b.Id == id);
            if (bank == null)
                return NotFound();

            return Ok(bank);
        }

        [HttpPost]
        public IActionResult AddBank(Bank bank)
        {
            _bankService.Add(bank);
            return Ok(new { message = "Banka eklendi" }); 
        }

        [HttpPut]
        public IActionResult EditBank(Bank bank) {
            _bankService.Update(bank);
            return Ok(new { message = "Banka güncellendi" });
        }

        [HttpDelete]
        public IActionResult DeleteBank(int id)
        {
            var deletedBank = _bankService.Get(b=>b.Id == id);
            _bankService.Delete(deletedBank);
            return Ok(new { message = "Banka Silindi" });
        }
    }
}

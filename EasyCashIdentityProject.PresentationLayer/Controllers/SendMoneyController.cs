using EasyCashIdentityProject.BusinessLayer.Abstract;
using EasyCashIdentityProject.DataAccessLayer.Concrete;
using EasyCashIdentityProject.DtoLayer.Dtos.CustomerAccountProcessDtos;
using EasyCashIdentityProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyCashIdentityProject.PresentationLayer.Controllers
{
    public class SendMoneyController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICustomerAccountProcessService _customerAccountProcessService;
        public SendMoneyController(UserManager<AppUser> userManager, ICustomerAccountProcessService customerAccountProcessService)
        {
            _userManager = userManager;
            _customerAccountProcessService = customerAccountProcessService;
        }

        [HttpGet]
        public IActionResult Index(string mycurrency)
        {
            ViewBag.currency = mycurrency;
            return View();
        }


        //alıcı ve gönderen hesapların kimliklerini belirlemek ve bir para gönderme işlemi için gerekli verileri hazırlamak 


        [HttpPost]
        public async Task<IActionResult> Index(SendMoneyForCustomerAccountProcessDto sendMoneyForCustomerAccountProcessDto)
        {
            // 1. Veritabanı bağlamını oluşturun
            var context = new Context();

            // 2. Kullanıcıyı bulun (oturum açmış kullanıcıyı temsil eder)
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            // 3. Alıcı hesabın kimliğini hesaplayın
            var receiverAccountNumberID = context.CustomerAccounts
                .Where(x => x.CustomerAccountNumber == sendMoneyForCustomerAccountProcessDto.ReceiverAccountNumber)
                .Select(y => y.CustomerAccountID)
                .FirstOrDefault();

            // 5. Para gönderme işlemi için bir nesne oluşturun ve verileri doldurun
            var values = new CustomerAccountProcess();
            values.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            values.ProcessType = "Havale";
            values.SenderID = user.Id;
            values.ReceiverID = receiverAccountNumberID;
            values.Amount = sendMoneyForCustomerAccountProcessDto.Amount;

            // 6. İşlemi veritabanına kaydedin
            _customerAccountProcessService.TInsert(values);

            // 7. Kullanıcıyı başka bir ekrana yönlendirin
            return RedirectToAction("Index", "Deneme");
        }

    }
}
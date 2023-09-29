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

        //kullanıcının seçtiği para birimini belirlemek ve para transfer işlemlerini yönlendirmek için kullanılıyor
        //bu para birimini view'da kullanılır. 
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


            // Bu satır, kullanıcının kimliği (user.Id) ile ilişkilendirilmiş müşteri hesaplarını filtreler.
            var senderAccountNumberID = context.CustomerAccounts
                .Where(x => x.AppUserID == user.Id) // Kullanıcının kimliği ile eşleşen müşteri hesaplarını seçer.
                .Where(y => y.CustomerAccountCurrency == "Türk Lirası") // Para birimi "Türk Lirası" olanları filtreler.
                .Select(z => z.CustomerAccountID) // Seçilen müşteri hesaplarının kimliklerini alır.
                .FirstOrDefault(); // İlk eşleşen müşteri hesabının kimliğini alır veya varsayılan değeri kullanır.

            // 5. Para gönderme işlemi için bir nesne oluşturun ve verileri doldurun
            var values = new CustomerAccountProcess();
            values.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            values.ProcessType = "Havale";
            values.SenderID = senderAccountNumberID;
            values.ReceiverID = receiverAccountNumberID;
            values.Amount = sendMoneyForCustomerAccountProcessDto.Amount;
            values.Description = sendMoneyForCustomerAccountProcessDto.Description;

            // 6. İşlemi veritabanına kaydedin
            _customerAccountProcessService.TInsert(values);

            // 7. Kullanıcıyı başka bir ekrana yönlendirin
            return RedirectToAction("Index", "Deneme");
        }

    }
}
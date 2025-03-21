using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TraversalCoreProject.Areas.Member.Models;

namespace TraversalCoreProject.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task <IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel userEditViewModel = new UserEditViewModel();
            userEditViewModel.name = values.Name;
            userEditViewModel.surname = values.Surname;
            userEditViewModel.phonenumber = values.PhoneNumber;
            userEditViewModel.mail = values.Email; ;
            return View(userEditViewModel);
        }
        [HttpPost]
        public async Task<ActionResult> Index(UserEditViewModel p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if(p.Image != null)
            {
                var resource = Directory.GetCurrentDirectory(); //Uygulamanın şu an çalıştığı dizini alır
                var extension = Path.GetExtension(p.Image.FileName); //Yüklenen dosyanın uzantısını alır
                var imagename = Guid.NewGuid() + extension;
                var savelocation = resource + "/wwwroot/userimages/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create); //akış oluşturur. N savelocation:ereye kaydedeceğimiz , FileMode.Create : yeni bir akış oluştur
                await p.Image.CopyToAsync(stream);
                user.ImageUrl = "/userimages/" + imagename;
            }

            user.Name = p.name;
            user.Surname = p.surname;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.password);
            user.PhoneNumber = p.phonenumber;
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("SignIn", "Login");
            }
            return View();
        }
    }
}

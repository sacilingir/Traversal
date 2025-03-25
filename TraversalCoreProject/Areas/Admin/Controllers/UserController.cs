using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly IReservationService _appReservationService;

        public UserController(IAppUserService appUserService, IReservationService appReservationService)
        {
            _appUserService = appUserService;
            _appReservationService = appReservationService;
        }

        public IActionResult Index()
        {
            var values = _appUserService.TGetList();


            return View(values);
        }

        public IActionResult DeleteUser(int id)
        {
            var values =_appUserService.TGetByID(id);
            _appUserService.TDelete(values);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditUser(int id)
        {
            var values = _appUserService.TGetByID(id);
            
            return View(values);
        }

        [HttpPost]
        public IActionResult EditUser(AppUser appuser)
        {
            _appUserService.TUpdate(appuser);
            return RedirectToAction("Index");
        }

        public IActionResult CommentUser(int id)
        {
            _appUserService.TGetList();
            return View();
        }

        public IActionResult ReservationUser(int id)
        {
            var values =_appReservationService.GetListWithReservationByWaitAccepted(id);
            return View(values);
        }
    }
}

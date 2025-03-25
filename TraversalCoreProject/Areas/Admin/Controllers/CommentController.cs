using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentController : Controller
    {
        CommentManager cm = new CommentManager(new EfCommentDal()); 
        //private readonly ICommentService _commentService;

        

        public IActionResult Index()
        {
            var values = cm.GetListCommentWithDestination();
            return View(values);
        }
        [HttpGet]
        public IActionResult DeleteComment(int id)
        {
            var values = cm.TGetByID(id);
            cm.TDelete(values);
            return RedirectToAction("Index");
        }
       
    }
}

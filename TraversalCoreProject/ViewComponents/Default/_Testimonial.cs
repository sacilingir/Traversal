using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.ViewComponents.Default
{
    public class _Testimonial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            TestimonialManager tm = new TestimonialManager(new EfTestimonialDal());
            var values = tm.TGetList();
            return View(values);
        }
    }
}

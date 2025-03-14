using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.ViewComponents.Default
{
    public class _PopularDestinations:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            DestinationManager dm = new DestinationManager(new EfDestinationDal());
            var values = dm.TGetList();
            return View(values);
        }
    }
}

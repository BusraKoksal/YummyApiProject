using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampi.WebUI.ViewComponents
{
    public class _HeadDefaultComponentPartial:ViewComponent
    {
        //                        çağırmak    
        public IViewComponentResult Invoke()
        {  return View(); }
    }
}

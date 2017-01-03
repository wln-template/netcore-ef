using Microsoft.AspNetCore.Mvc;
using Wlniao;
namespace Template.Controllers
{
    /// <summary>
    /// 后台处理
    /// </summary>
    public class homeController : XCoreController
    {
        public IActionResult index()
        {
            return Content("template project.");
        }
    }
}

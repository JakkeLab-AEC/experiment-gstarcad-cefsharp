using System.Web.Http;

namespace WebViewTestingProject.Server.Controllers
{
    [RoutePrefix("api/test")]
    public class TestController : ApiController
    {
        // GET: api/items
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetText()
        {
            return Json(new { message = "test" });
        }
    }
}
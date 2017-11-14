using System.Web.Http;

namespace SecuringWebApi.Controllers
{
    [RoutePrefix("api/doctorpage")]
    [Authorize]
    public class DoctorPageController : ApiController
    {
        [HttpGet]
        [Route("Testing", Name = "TestingDoctorRoute")]
        [Authorize(Roles = "Doctor")]
        public IHttpActionResult Testing()
        {
            return Ok("Hello Doctor");
        }
    }
}

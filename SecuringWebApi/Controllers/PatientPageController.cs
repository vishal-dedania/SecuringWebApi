using System.Web.Http;

namespace SecuringWebApi.Controllers
{
    [RoutePrefix("api/patientpage")]
    [Authorize]
    public class PatientPageController : ApiController
    {
        [HttpGet]
        [Route("Testing", Name = "TestingPatientRoute")]
        [Authorize(Roles = "Patient")]
        public IHttpActionResult Testing()
        {
            return Ok("Hello Patient");
        }
    }
}

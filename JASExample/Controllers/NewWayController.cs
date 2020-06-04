using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JASExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewWayController : ControllerBase
    {
        [HttpPost]
        [TypeFilter(typeof(ResultsResourceFilter), Arguments = new object[] { "api_hobbies_post" })]
        public void PostHobbyAsync() { }

        //[HttpGet]
        //[TypeFilter(typeof(ResultsResourceFilter), Arguments = new object[] { "api_hobbies_get" })]
        //public void GetHobbyAsync() { }

    }
}
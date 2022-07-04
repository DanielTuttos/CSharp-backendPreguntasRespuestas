using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreguntasRespuestas.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : Controller
    {
        // GET: DefaultController
        [HttpGet]
        public string Get()
        {
            return "app corriendo...";
        }

        
    }
}

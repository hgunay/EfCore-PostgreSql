namespace EfCorePostgre.API.Controllers
{
    using System;

    using Microsoft.AspNetCore.Mvc;

    /// <summary>The common controller.</summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommonController : ControllerBase
    {
        /// <summary>Initializes a new instance of the <see cref="CommonController"/> class.</summary>
        public CommonController() { }

        /// <summary>The heartbeat.</summary>
        /// <returns>The <see cref="ActionResult"/>.</returns>
        [HttpGet]
        public ActionResult Heartbeat() =>
            /* Sample
             *
             * Method : Get
             * Url    : http://localhost:5001/api/Common/Heartbeat
             * 
             */
            this.Ok(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss.fff"));
    }
}
using FileUploadAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FileUploadAPI.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private IWebHostEnvironment webHostEnvironment;
        private IHttpContextAccessor HttpContextAccessor;
        public FileController(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor HttpContextAccessor)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.HttpContextAccessor = HttpContextAccessor;

        }
        //[Produces("application/json")]
        [HttpPost]
        [Route("upload")]
        //[Authorize(Roles ="Admin")]
        public IActionResult UploadFile(IFormFile file)
        {
            try
            {
                var path = Path.Combine(webHostEnvironment.WebRootPath, "uploads", file.FileName);
                using(var filestream=new FileStream(path,FileMode.Create))
                {
                    file.CopyTo(filestream);
                }
                var baseURL = HttpContextAccessor.HttpContext.Request.Scheme + "://" + HttpContextAccessor.HttpContext.Request.Host + HttpContextAccessor.HttpContext.Request.PathBase;
                fileData data = new fileData();
                data.fileName = Path.Combine(baseURL, "uploads", file.FileName);
                data.fileSize = file.Length;
                return Ok(data);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}

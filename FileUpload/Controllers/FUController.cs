using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileUpload.Services;
using FileUpload.Models;

namespace FileUpload.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FUController : ControllerBase
    {
        private readonly IFileUploadServices _fileUploadServices;
        public FUController(IFileUploadServices fileUploadServices)
        {
            _fileUploadServices = fileUploadServices;
        }

        [HttpPut]
        public async Task<ActionResult<FileUploadEntity>> Insert(FileUploadEntity FU)
        {
            try
            {
                await _fileUploadServices.Insert(FU);

                return CreatedAtAction("Insert", new { FU.Name }, FU);
            }

            catch (Exception ex)
            { 
                 throw;
            }
        }
    }
}

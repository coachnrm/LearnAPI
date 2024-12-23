using LearnAPI.Data;
using LearnAPI.Helper;
using LearnAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;

namespace LearnAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileDemoController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;
        private readonly LearnDataContext _context;
        public FileDemoController(IWebHostEnvironment environment, LearnDataContext context)
        {
            _environment = environment;
            _context = context;
        }        
        private async Task<string> WriteFile(IFormFile file)
        {
            string filename = "";
            try
            {
                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                filename = DateTime.Now.Ticks.ToString() + extension;

                var filepath = Path.Combine(Directory.GetCurrentDirectory(), "Upload/file");

                if (!Directory.Exists(filepath))
                {
                    Directory.CreateDirectory(filepath);
                }

                var exactpath = Path.Combine(Directory.GetCurrentDirectory(), "Upload/file", filename);
                using (var stream = new FileStream(exactpath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                byte[] fileBytes;
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    fileBytes = memoryStream.ToArray();
                }

                // Save the file locally
                await System.IO.File.WriteAllBytesAsync(exactpath, fileBytes);

                 // Save file details to the database
                var fileDetail = new FileDetail
                {
                    FileName = filename,
                    FilePath = exactpath,
                    FileData = fileBytes,
                    UploadedDate = DateTime.Now
                };

                _context.FileDetails.Add(fileDetail);
                await _context.SaveChangesAsync();

                return filename;

            }
            catch (Exception ex)
            {
            }
            return filename;
        }

        [HttpPost]
        [Route("UploadFile")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            try
            {
                
                var result = await WriteFile(file);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("DownloadFile")]
        public async Task<IActionResult> DownloadFile(string filename)
        {
            var fileDetail = await _context.FileDetails.FirstOrDefaultAsync(f => f.FileName == filename);

            if (fileDetail == null)
            {
                return NotFound("File not found.");
            }

            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(fileDetail.FilePath, out var contentType))
            {
                contentType = "application/octet-stream";
            }

            var bytes = await System.IO.File.ReadAllBytesAsync(fileDetail.FilePath);
            return File(bytes, contentType, Path.GetFileName(fileDetail.FilePath));
        }

        [NonAction]
        private string GetFilepath(string filename)
        {
            return this._environment.WebRootPath+"/Upload/file/" + filename;
        }
    }
}
using ApiLTMTest.Application.Service.Interfaces;
using ApiLTMTest.Application.ViewModel;
using ApiLTMTest.Host.Controllers.Base;
using ApiLTMTest.Host.Providers;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ApiLTMTest.Host.Controllers
{
    [AllowAnonymous, RoutePrefix("File")]
    public class FileController : BaseController
    {
        private IFileService FileService { get; }


        public FileController(IFileService fileService)
        {
            FileService = fileService;
        }

        [HttpGet]
        [AllowAnonymous, Route(nameof(GetAllUploads))]
        public IHttpActionResult GetAllUploads()
        {
            try
            {
                var result = FileService.GetAll();

                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Authorize, Route(nameof(UploadFile))]
        public async Task<IHttpActionResult> UploadFile()
        {
            // file path
            var fileuploadPath = HttpContext.Current.Server.MapPath("~/File/Generate");
            
            var multiFormDataStreamProvider = new MultiFileUploadProvider(fileuploadPath);

            // Read the MIME multipart asynchronously 
            await Request.Content.ReadAsMultipartAsync(multiFormDataStreamProvider);

            string uploadingFileName = multiFormDataStreamProvider
                .FileData.Select(x => x.LocalFileName).FirstOrDefault();

            var file = new FileUploadVM
            {
                FileName = Path.GetFileName(uploadingFileName),
                FileSize = new FileInfo(uploadingFileName).Length,
                FileLastAcess = new FileInfo(uploadingFileName).LastAccessTime,
                DateCreation = DateTime.Now,
                OwnerFile = "Admin",
            };

            var result = FileService.UploadFile(file);
            return Ok(result);
        }

        [HttpGet]
        [AllowAnonymous, Route(nameof(Generate) + "/{fileName}")]
        public IHttpActionResult Generate(string fileName)
        {

            var stream = new MemoryStream();
            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(stream.ToArray())
            };
            result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = fileName
            };

            result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            var response = ResponseMessage(result);
            return Ok(response);
        }
    }
}

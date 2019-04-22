using ApiLTMTest.Application.ViewModel;
using MultipartDataMediaFormatter.Infrastructure;
using System.Collections.Generic;
using System.IO;
using System.Security.Principal;
using System.Web;


namespace ApiLTMTest.Application.Service.Interfaces
{
    public interface IFileService
    {
        RequestReturnVM<FileUploadVM> Create(FileUploadVM file);
        RequestReturnVM<List<FileUploadVM>> GetAll();

        RequestReturnVM<bool> UploadFile(FileUploadVM file);

        Stream GetFile(string fileName);
    }
}

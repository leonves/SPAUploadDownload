using ApiLTMTest.Domain.Entities;
using MultipartDataMediaFormatter.Infrastructure;
using System;
using System.Web;

namespace ApiLTMTest.Application.ViewModel
{
    public class FileUploadVM
    {
        public FileUploadVM()
        {

        }
        public FileUploadVM(FileUpload file)
        {
            FileName = file.FileName;
            FileSize = file.FileSize;
            OwnerFile = file.OwnerFile;
            DateCreation = file.CreationDate;
        }
        
        public string FileName { get; set; }
        public DateTime FileLastAcess { get; set; }
        public long FileSize { get; set; }
        
        public string OwnerFile { get; set; }

        public DateTime DateCreation { get; set; }

    }
}

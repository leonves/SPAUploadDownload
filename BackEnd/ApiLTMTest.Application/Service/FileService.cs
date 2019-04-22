using ApiLTMTest.Application.Service.Interfaces;
using ApiLTMTest.Application.ViewModel;
using ApiLTMTest.Application.ViewModel.User;
using ApiLTMTest.Domain.Entities;
using ApiLTMTest.Domain.Repositories.Interfaces;
using MultipartDataMediaFormatter.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
namespace ApiLTMTest.Application.Service
{
    public class FileService : IFileService
    {
        public IRepository<FileUpload> FileRepository { get; }

        public FileService(IRepository<FileUpload> fileRepository)
        {
            FileRepository = fileRepository;
        }

        public RequestReturnVM<FileUploadVM> Create(FileUploadVM file)
        {
            try
            {
                FileUpload _file = new FileUpload();
                FileUpload _fileStoraged = new FileUpload();

                _file.FileName = file.FileName;
                _file.FileSize = file.FileSize;
                _file.OwnerFile = file.OwnerFile;
                _file.FileLastAcess = file.FileLastAcess;
                _file.CreationDate = DateTime.Now;
                _file.Active = true;

                if (!string.IsNullOrEmpty(_file.FileName))
                    _fileStoraged = FileRepository.Find(wh => wh.FileName == file.FileName );



                if (_fileStoraged != null)
                    FileRepository.Update(_fileStoraged);
                else
                    FileRepository.Insert(_file);

                return new RequestReturnVM<FileUploadVM>
                {
                    Data = new FileUploadVM(_file),
                    Success = true
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public RequestReturnVM<List<FileUploadVM>> GetAll()
            {
                try
                {
                    var _files = FileRepository.FindAll(wh => wh.Active).ToList().Select(sel => new FileUploadVM(sel)).ToList();
              

                    _files = _files.OrderByDescending(or => or.DateCreation).ToList();

                    return new RequestReturnVM<List<FileUploadVM>>
                    {
                        MessageBody = "Sucesso ao obter os arquivos!",
                        MessageTitle = "Sucesso",
                        Data = _files,
                        Success = true
                    };
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

        public RequestReturnVM<bool> UploadFile(FileUploadVM uploadFile)
        {
            try
            {
                Create(uploadFile);
                return new RequestReturnVM<bool>
                {
                    MessageBody = "Sucesso ao carregar arquivo!",
                    MessageTitle = "Sucesso",
                    Data = true,
                    Success = true
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Stream GetFile(string filename)
        {
            string filePath = $"{ HttpContext.Current.Server.MapPath("~/UploadedFiles")}/{filename}";

            if (!File.Exists(filePath))
            {
                return null;
            }

            return new FileStream(filePath, FileMode.Open);
        }

    }
}

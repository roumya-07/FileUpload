using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileUpload.Models;
using FileUpload.Repository;

namespace FileUpload.Services
{
    public class FileUploadServices: IFileUploadServices
    {
        private readonly IFileUploadRepository _fileUploadRepository;
        public FileUploadServices(IFileUploadRepository fileUploadRepository)
        {
            _fileUploadRepository = fileUploadRepository;
        }
        public async Task<int> Insert(FileUploadEntity FU)
        {
            return await _fileUploadRepository.Insert(FU);
        }
    }
}

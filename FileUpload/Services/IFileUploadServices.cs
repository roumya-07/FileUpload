using FileUpload.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileUpload.Services
{
    public interface IFileUploadServices
    {
        public Task<int> Insert(FileUploadEntity FU);
    }
}

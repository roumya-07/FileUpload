using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileUpload.Models;

namespace FileUpload.Repository
{
    public interface IFileUploadRepository
    {
        public Task<int> Insert(FileUploadEntity FU);
    }
}

using Dapper;
using FileUpload.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FileUpload.Repository
{
    public class FileUploadRepository : BaseRepository, IFileUploadRepository
    {
        public FileUploadRepository(IConfiguration configuration) : base(configuration)
        {

        }
        public async Task<int> Insert(FileUploadEntity FU)
        {
            try
            {
                var cn = CreateConnection();
                if (cn.State == ConnectionState.Closed) cn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@Name", FU.Name);
                param.Add("@Photo", FU.Photo);
                param.Add("@Action", "Insert");
                int x = await cn.ExecuteAsync("SP_FileUpload", param, commandType: CommandType.StoredProcedure);
                cn.Close();
                return x;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

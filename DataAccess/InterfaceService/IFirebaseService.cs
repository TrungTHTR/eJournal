using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.InterfaceService
{
    public interface IFirebaseService
    {
        Task<string> UploadFile(Stream fileStream, string fileName, string? folder = null);
        Task DownloadFile(string url);
    }
}

using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace NossoMercadoLivre.Services.Interfaces
{
    public interface IUploadFileService
    {
        IList<string> UploadImages(IList<IFormFile> urlImages);
    }
}

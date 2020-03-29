using Microsoft.AspNetCore.Http;
using NossoMercadoLivre.Services.Interfaces;
using System.Collections.Generic;

namespace NossoMercadoLivre.Services
{
    public class UploadFileService : IUploadFileService
    {
        public IList<string> UploadImages(IList<IFormFile> urlImages)
        {
            IList<string> urls = new List<string>();
            foreach (var file in urlImages)
            {
                urls.Add("https://nossomercadolivre.blob.net/photos-products/" + file.FileName);
            }

            return urls;
        }
    }
}

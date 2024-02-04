using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    public class FileStorageService : IStorageService
    {
        private static readonly string PATH_PREFIX = "cloud/";

        public async Task CreateFileAsync(string path, string fileName, Stream? contentStream = null)
        {
            if (path.StartsWith("/")) path = path[1..];

            path += path.EndsWith("/") ? "" : "/";

            string truePath = PATH_PREFIX + path;

            if (!Directory.Exists(truePath))
            {
                Directory.CreateDirectory(truePath);
            }

            using FileStream fileStream = File.Create(truePath + fileName);

            if (contentStream != null) await contentStream.CopyToAsync(fileStream);
        }
    }
}

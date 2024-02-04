using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Storage
{
    public interface IStorageService
    {
        public Task CreateFileAsync(string path, string fileName, Stream? contentStream = null);
    }
}

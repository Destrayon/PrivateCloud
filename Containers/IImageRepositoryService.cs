using Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Containers
{
    public interface IImageRepositoryService : IService
    {
        public Task CreateImageAsync(string imageId, Stream content, string version);
        public void PullImage(string imageId);
    }
}

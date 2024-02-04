using Base.ProcessRunner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Containers
{
    public class DockerContainerService : IContainerService
    {
        private readonly IProcessRunner _processRunner;
        private readonly IImageRepositoryService _imageRepository;

        public DockerContainerService(IProcessRunner processRunner)
        {
            _processRunner = processRunner;
        }

        public bool CheckDependencies()
        {
            string? output = _processRunner.RunProcess("docker", "--version");

            return output != null && output.Contains("Docker version");
        }

        public bool RunContainter(string imageId)
        {
            return false;
        }
    }
}

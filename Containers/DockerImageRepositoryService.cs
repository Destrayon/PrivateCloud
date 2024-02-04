using Base.ProcessRunner;
using Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Containers
{
    public class DockerImageRepositoryService : IImageRepositoryService
    {
        private readonly IStorageService _storageService;
        private readonly IProcessRunner _processRunner;

        public DockerImageRepositoryService(IStorageService storageService, IProcessRunner processRunner)
        {
            _storageService = storageService;
            _processRunner = processRunner;
        }
        public void PullImage(string imageId)
        {
            throw new NotImplementedException();
        }

        public async Task CreateImageAsync(string imageId, Stream content, string version)
        {
            // Save the Dockerfile with a version-specific name
            string dockerfileName = $"{imageId}-{version}.Dockerfile";
            await _storageService.CreateFileAsync($"dockerfiles/{imageId}", dockerfileName, content);

            // Update the build command to reference the version-specific Dockerfile name
            await _processRunner.RunProcessAsync("docker", $"build -t {imageId}:{version} -f cloud/dockerfiles/{imageId}/{dockerfileName} cloud/dockerfiles/{imageId}");
        }

        public bool CheckDependencies()
        {
            string? output = _processRunner.RunProcess("docker", "--version");

            return output != null && output.Contains("Docker version");
        }
    }
}

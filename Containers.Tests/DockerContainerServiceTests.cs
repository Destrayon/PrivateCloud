using Base.ProcessRunner;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Containers.Tests
{
    public class DockerContainerServiceTests
    {
        private readonly Mock<IProcessRunner> _mockProcessRunner;
        private readonly DockerContainerService _dockerContainerService;

        public DockerContainerServiceTests()
        {
            _mockProcessRunner = new Mock<IProcessRunner>();
            _dockerContainerService = new DockerContainerService(_mockProcessRunner.Object);
        }

        [Fact]
        public void CheckDependencies_ReturnsTrue_WhenDockerIsInstalled()
        {
            // Arrange
            string fakeOutput = "Docker version 20.10.7, build f0df350";
            _mockProcessRunner.Setup(m => m.RunProcess("docker", "--version")).Returns(fakeOutput);

            // Act
            bool result = _dockerContainerService.CheckDependencies();

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CheckDependencies_ReturnsFalse_WhenDockerIsNotInstalled()
        {
            // Arrange
            _mockProcessRunner.Setup(m => m.RunProcess("docker", "--version")).Returns<IProcessRunner, string?>(null);

            // Act
            bool result = _dockerContainerService.CheckDependencies();

            // Assert
            Assert.False(result);
        }
    }
}

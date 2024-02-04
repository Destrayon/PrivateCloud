using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;

namespace PrivateCloud
{
    public class ImageRepositoryData
    {
        public required string ImageId { get; set; }
        public string? Version { get; set; }
    }
}

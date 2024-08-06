using System.ComponentModel.DataAnnotations;

namespace AudioUploadApp.Models
{
    public class AudioFile
    {
        [Required]
        public IFormFile File { get; set; }
    }
}

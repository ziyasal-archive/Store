using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace RedactorImageUploadSample.Models
{
    public class TestModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        [AllowHtml]
        public string Content { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Tags { get; set; }
    }
}
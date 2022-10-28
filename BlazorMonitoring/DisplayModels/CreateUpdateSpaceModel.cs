using System.ComponentModel.DataAnnotations;

namespace BlazorMonitoring.DisplayModels
{
    public class CreateUpdateSpaceModel
    {
        [Required(ErrorMessage = "Name is required.")]
        public string? Name { get; set; }

        //[Required(ErrorMessage = "Latitude is required.")]
        public string? Latitude { get; set; }

        //[Required(ErrorMessage = "Longitude is required.")]
        public string? Longitude { get; set; }

        //[Required(ErrorMessage = "Image Url is required.")]
        public string? ImageUrl { get; set; }
    }
}

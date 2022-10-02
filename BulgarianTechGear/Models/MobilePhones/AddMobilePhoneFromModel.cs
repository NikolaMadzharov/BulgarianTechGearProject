using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BulgarianTechGear.Data.Models;

namespace BulgarianTechGear.Models.MobilePhone
{
    using MobilePhones;

    public class AddMobilePhoneFromModel
    {
        
        [Display(Name = "Model")]
        public string Model { get; set; }

        
        public decimal Price { get; set; }

        
        public int Year { get; set; }

        public int PixelsFrontCamera { get; set; }

        
        public int PixelsBackCamera { get; set; }

        
        public int Memory { get; set; }

        
        public double DisplaySizeInch { get; set; }

       
        public double BatteryCapacity { get; set; }

        
        public string DisplayType { get; set; }

        
        public int Ram { get; set; }

        
        public string Resolution { get; set; }

        
        public string Processor { get; set; }

        
        public string Description { get; set; }

        [Display(Name = "Image Url")]
        public string Url { get; set; }

        [Display(Name = "Brands")]
        public int BrandId { get; set; }

    }
}

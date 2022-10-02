using System.ComponentModel.DataAnnotations.Schema;

namespace BulgarianTechGear.Data.Models
{
    public class MobilePhone
    {
      
        public int Id { get; set; }

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
        
        public string Url { get; set; }

        public MobilePhoneBrand Brand { get; set; }

        [ForeignKey("Brand")]
        public int BrandId { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GUI.Models
{
    public class ImgModel
    {
        
    }

    public class ImgDetailModel
    {
        public int Id { get; set; }
        [Display(Name = "Uploaded Img")]
        public string FileName { get; set; }
        public byte[] FileContent { get; set; }

    }

    public class ImgProcessModel
    {
        public int Id { get; set; }
        [Display(Name = "Uploaded Img")]
        public string FileName { get; set; }
        public string ImgClassification { get; set; }
        public byte[] FileContent { get; set; }
        
    }

    public class AssetIndexModel2
    {
        public IEnumerable<ImgProcessModel> Assets2 { get; set; }
    }
    public class AssetIndexModel
    {
        public IEnumerable<ImgDetailModel> Assets { get; set; }
    }

}

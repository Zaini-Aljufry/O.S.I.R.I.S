using GUI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GUI.Models
{
    public interface IImgAssets
    {
        ImageDetails GetById(int id);
        string GetName(int id);
        void Add(ImageDetails newAssets);
        IEnumerable<ImageDetails> GetAll();
    }

    public class ImgAssetsService : IImgAssets
    {
        private ApplicationDbContext _context;

        public ImgAssetsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(ImageDetails newAssets)
        {
            _context.Add(newAssets);
            _context.SaveChanges();
        }

        public IEnumerable<ImageDetails> GetAll()
        {
            return _context.ImageDetails;
        }

        public ImageDetails GetById(int id)
        {
            return GetAll()
                .FirstOrDefault(asset => asset.Id == id);
        }

        public string GetName(int id)
        {
            return _context.ImageDetails
                .FirstOrDefault(n => n.Id == id)
                .FileName;
        }
    }

}

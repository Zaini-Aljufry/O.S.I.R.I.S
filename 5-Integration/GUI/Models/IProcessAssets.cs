using GUI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GUI.Models
{
    public interface IProcessAssets
    {
        ProcessImgDetails GetById(int id);
        string GetName(int id);
        string GetClassification(int id);
        void Add(ProcessImgDetails newAssets);
        IEnumerable<ProcessImgDetails> GetAll();
    }

    public class ProcessAssetservice : IProcessAssets
    {
        private ApplicationDbContext _context;

        public ProcessAssetservice(ApplicationDbContext context)
        {
            _context = context;
        }


        public void Add(ProcessImgDetails newAssets)
        {
            _context.Add(newAssets);
            _context.SaveChanges();
        }

        public IEnumerable<ProcessImgDetails> GetAll()
        {
            return _context.ProcessImgDetails;
        }

        public ProcessImgDetails GetById(int id)
        {
            return GetAll().
                FirstOrDefault(asset => asset.Id == id);
        }

        public string GetClassification(int id)
        {
            return GetAll()
                .FirstOrDefault(asset => asset.Id == id)
                .ImgClassification;
        }

        public string GetName(int id)
        {
            return GetAll()
                .FirstOrDefault(assets => assets.Id == id)
                .FileName;
        }
    }
}

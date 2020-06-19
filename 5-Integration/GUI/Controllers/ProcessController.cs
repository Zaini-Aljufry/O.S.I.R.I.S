using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using GUI.Data;
using GUI.Models;
using IronPython.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace GUI.Controllers
{
    public class ProcessController : Controller
    {
        private GUI.Controllers.RAWIMGController _rAWIMG;
        private ApplicationDbContext _context;
        readonly IProcessAssets _assets;
        
        public ProcessController(ApplicationDbContext context, IProcessAssets assets,RAWIMGController rAWIMG)
        {
            _context = context;
            _assets = assets;
            _rAWIMG = rAWIMG;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region View Database table
        public IActionResult ImgDetails()
        {
            var assetsModels = _assets.GetAll();

            var listingResult = assetsModels
                .Select(result => new ImgProcessModel
                {
                    Id = result.Id,
                    FileName = _assets.GetName(result.Id),
                    ImgClassification = _assets.GetClassification(result.Id)
                })
                .OrderBy(List => List.Id);

            var model = new AssetIndexModel2()
            {
                Assets2 = listingResult
            };

            return View(model);
        }

        private List<ImgProcessModel> GetImgList()
        {
            List<ImgProcessModel> DetList = new List<ImgProcessModel>();

            DbConnection();
            con.Open();
            DetList = SqlMapper.Query<ImgProcessModel>(con, "GetProcessImg", commandType: CommandType.StoredProcedure).ToList();
            con.Close();
            return DetList;
        }

        private string getname(string name)
        {
            var nm = _context.ImageDetails
                     .FirstOrDefault(n => n.FileName == name);
            return nm?.FileName;
        }
        #endregion
        #region View Img
        public FileResult ViewImg(int imageId)

        {
            List<ImgProcessModel> DetList = GetImgList();

            var ImgById = (from FC in DetList
                           where FC.Id.Equals(imageId)
                           select new
                           {
                               FC.FileName,
                               FC.FileContent
                           })
                           .ToList().FirstOrDefault();
            var StreamResult = new FileStreamResult(new MemoryStream(ImgById.FileContent), "image/jpeg;base64");
            return StreamResult;
        }
        #endregion
        #region Database connection  

        private SqlConnection con;
        private void DbConnection()
        {
            con = new SqlConnection("Server=LAPTOP-FOLTOFSN;Database=OSIRIS;User Id=OSIRIS;Password=ABC123!@#;MultipleActiveResultSets=true");
        }
        #endregion
        #region Download & Delete
        [HttpGet]
        public FileResult DownLoadImg(int id)
        {


            List<ImgProcessModel> ObjFiles = GetImgList();

            var FileById = (from FC in ObjFiles
                            where FC.Id.Equals(id)
                            select new { FC.FileName, FC.FileContent }).ToList().FirstOrDefault();

            return File(FileById.FileContent, "image/jpeg;base64", FileById.FileName);
        }

        public ActionResult DeleteImg(int id)
        {
            List<ImgProcessModel> ObjFiles = GetImgList();

            var FileById = (from FC in ObjFiles
                            where FC.Id.Equals(id)
                            select new { FC.FileName, FC.FileContent,FC.ImgClassification })
                            .ToList().FirstOrDefault();
            ImgProcessModel Fd = new ImgProcessModel();
            Fd.FileName = FileById.FileName;
            Fd.FileContent = FileById.FileContent;
            Fd.ImgClassification = FileById.ImgClassification;

            DeleteImgDetails(Fd);

            return RedirectToAction("ImgDetails");
        }

        private void DeleteImgDetails(ImgProcessModel objDet)
        {
            DynamicParameters Parm = new DynamicParameters();
            Parm.Add("@FileName", objDet.FileName);
            Parm.Add("@FileContent", objDet.FileContent);
            Parm.Add("@ImgClassification", objDet.ImgClassification);
            DbConnection();
            con.Open();
            con.Execute("RemoveProcessDetails", Parm, commandType: System.Data.CommandType.StoredProcedure);
            con.Close();
        }
        #endregion
        #region Predict Model
        private void SaveImgDetails(ImgProcessModel objDet)
        {

            DynamicParameters Parm = new DynamicParameters();
            Parm.Add("@FileName", objDet.FileName);
            Parm.Add("@FileContent", objDet.FileContent);
            Parm.Add("@ImgClassification", objDet.ImgClassification);
            DbConnection();
            con.Open();
            con.Execute("AddImgDetails", Parm, commandType: System.Data.CommandType.StoredProcedure);
            con.Close();


        }

        public ActionResult StartPredict()
        {
            
            _rAWIMG.imgtoFold();
            var psi = new ProcessStartInfo();
           psi.FileName = @"C:\Users\dream\AppData\Local\Programs\Python\Python36-32\python.exe";
           
         
           var script = @"D:\ObjectDetectionTest\models\research\object_detection\metal_defects_detection.py";
           
           
           psi.Arguments = $"\"{script}\"";
           
          
           psi.UseShellExecute = false;
           psi.CreateNoWindow = true;
           psi.RedirectStandardOutput = true;
           psi.RedirectStandardError = true;
           
          
           var errors = "";
           var results = "";
           
           using (var process = Process.Start(psi))
           {
               errors = process.StandardError.ReadToEnd();
               results = process.StandardOutput.ReadToEnd();
           }
           
            return RedirectToAction("ImgDetails");
        }
        public String[] Pharse(string output)
        {
            string phrase = output;
            string[] words = phrase.Split('\n');
            foreach (var word in words)
            {
                phrase = String.Concat(words);
            }
            string[] words1 = phrase.Split('\r');
            return words1;
        }
        #endregion
    }

}
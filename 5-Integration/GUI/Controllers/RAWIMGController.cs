using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using Dapper;
using GUI.Data;
using GUI.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace GUI.Controllers
{
    public class RAWIMGController : Controller
    {
        readonly IImgAssets _assets;
        private ApplicationDbContext _context;

        public RAWIMGController(ApplicationDbContext context, IImgAssets assets)
        {
            _context = context;
            _assets = assets;
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
                .Select(result => new ImgDetailModel
                {
                    Id = result.Id,
                    FileName = _assets.GetName(result.Id),
                })
                .OrderBy(List => List.Id);

            var model = new AssetIndexModel()
            {
                Assets = listingResult
            };

            return View(model);
        }

        public List<ImgDetailModel> GetImgList()
        {
            List<ImgDetailModel> DetList = new List<ImgDetailModel>();

            DbConnection();
            con.Open();
            DetList = SqlMapper.Query<ImgDetailModel>(con, "GetImgDetails", commandType: CommandType.StoredProcedure).ToList();
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

        #region convert images & display
        public FileResult ViewImg(int imageId)

        {
            List<ImgDetailModel> DetList = GetImgList();

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


            List<ImgDetailModel> ObjFiles = GetImgList();

            var FileById = (from FC in ObjFiles
                            where FC.Id.Equals(id)
                            select new { FC.FileName, FC.FileContent}).ToList().FirstOrDefault();

            return File(FileById.FileContent, "image/jpeg;base64", FileById.FileName);
        }

        public ActionResult DeleteImg( int id)
        {
            List<ImgDetailModel> ObjFiles = GetImgList();

            var FileById = (from FC in ObjFiles
                            where FC.Id.Equals(id)
                            select new { FC.FileName, FC.FileContent })
                            .ToList().FirstOrDefault();
            ImgDetailModel Fd = new ImgDetailModel();
            Fd.FileName = FileById.FileName;
            Fd.FileContent = FileById.FileContent;

            DeleteImgDetails(Fd);

            return RedirectToAction("ImgDetails");
        }

        private void DeleteImgDetails(ImgDetailModel objDet)
        { 
            DynamicParameters Parm = new DynamicParameters();
            Parm.Add("@FileName", objDet.FileName);
            Parm.Add("@FileContent", objDet.FileContent);
            DbConnection();
            con.Open();
            con.Execute("RemoveImgDetails", Parm, commandType: System.Data.CommandType.StoredProcedure);
            con.Close();
        }
        #endregion
        public void imgtoFold()
        {
            string folderName = @"C:\Users\dream\Desktop\IMG\";
            string path;

            var DetList = GetImgList();

            foreach (var asset in DetList)
            {

                path = String.Concat(folderName, asset.Id);
                path = String.Concat(path, ".jpg");
                System.IO.File.WriteAllBytes(path, asset.FileContent);

            }
        }
    }
}
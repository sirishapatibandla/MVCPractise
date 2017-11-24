using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CascadingDropdownlistApplication.Controllers
{
    public class DataController : Controller
    {
        // GET: Data
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            if (Request != null)
            {
                HttpPostedFileBase file = Request.Files["fileToUpload"];
                if(file!=null && file.ContentLength != 0 && !string.IsNullOrEmpty(file.FileName))
                {
                    string fileName = file.FileName;
                    string path = Server.MapPath("~/App_Data/" + file.FileName);
                    file.SaveAs(path);
                    string fileContentType = file.ContentType;
                 byte[] byteArray   =new byte[file.ContentLength];
                    file.InputStream.Read(byteArray, 0, file.ContentLength);
                    //OleDbConnection oledbConn = new System.Data.OleDb.OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + path + "; Extended Properties =\"Excel 12.0;HDR=Yes;IMEX=2\"");
                    //DataTable dt = new DataTable();
                    //try
                    //{

                    //    oledbConn.Open();
                    //    using (OleDbCommand cmd = new OleDbCommand("SELECT * FROM [Sheet1$]", oledbConn))
                    //    {
                    //        OleDbDataAdapter oleda = new OleDbDataAdapter();
                    //        oleda.SelectCommand = cmd;
                    //        DataSet ds = new DataSet();
                    //        oleda.Fill(ds);

                    //        dt = ds.Tables[0];
                    //    }
                    //}
                    //catch(Exception ex)
                    //{
                    //}
                    //finally
                    //{

                    //    oledbConn.Close();
                    //}
                }
            }
            return View();
        }
    }
}
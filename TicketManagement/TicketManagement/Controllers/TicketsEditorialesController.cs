using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketManagement.DataAccess;
using System.Data;
using System.Data.SqlClient;
using TicketManagement.Models.ViewModels;
using System.Configuration;
using System.IO;
using System.IO.Compression;
using DevExpress.XtraReports.Web;
using TicketManagement.Reports;
using DevExpress.DataAccess.Sql;
using DevExpress.DataAccess.ConnectionParameters;
using DevExpress.XtraReports.Parameters;

namespace TicketManagement.Controllers
{
    public class TicketsEditorialesController : Controller
    {
        public static string conBD = ConfigurationManager.ConnectionStrings["Global"].ConnectionString;
        public static string sql = "Tickets_Editoriales";
        public static int ID = 0;
        public static string IMG = "";
        // GET: TicketsEditoriales
        public ActionResult Index()
        {

            return View();
        }

        public JsonResult GetDataTickets()
        {

            SqlData spSql = new SqlData();
            DataTable TicketsEditoriales = spSql.spGetData("[dbo].[Tickets_Editoriales]", new string[] { "@Accion:READ_Tickets" });
            List<TicketsEditorialesViewModel> listTicketsEditoriales = TicketsEditoriales.AsEnumerable().Select(x => new TicketsEditorialesViewModel
            {
                id = Convert.IsDBNull(x["id"]) ? 0 : (int)x["id"]                ,
                Maestro_Orden_PrioridadId = Convert.IsDBNull(x["Maestro_Orden_PrioridadId"]) ? "" : (string)x["Maestro_Orden_PrioridadId"]                ,
                Updated_At = Convert.IsDBNull(x["Updated_At"]) ? "" : (string)x["Updated_At"]                ,
                UserId = Convert.IsDBNull(x["UserId"]) ? "" : (string)x["UserId"]                ,
                Nombre_Area = Convert.IsDBNull(x["Nombre_Area"]) ? "" : (string)x["Nombre_Area"]                ,
                Maestro_EditorialesId = Convert.IsDBNull(x["Maestro_EditorialesId"]) ? "" : (string)x["Maestro_EditorialesId"]                ,
                IsClosed = Convert.ToBoolean(x["IsClosed"])                ,
                IsClosed_Successfully = Convert.ToBoolean(x["IsClosed_Successfully"])                ,
                isticket_cancelled = Convert.ToBoolean(x["isticket_cancelled"])                ,
                Rol_Usuario = Convert.IsDBNull(x["Rol_Usuario"]) ? "" : (string)x["Rol_Usuario"]                ,
                TiempoEstimadoRespuesta = Convert.IsDBNull(x["TiempoEstimadoRespuesta"]) ? 0 : (double)x["TiempoEstimadoRespuesta"]                ,
                TiempoRealRespuesta = Convert.IsDBNull(x["TiempoRealRespuesta"]) ? 0 : (double)x["TiempoRealRespuesta"]                ,
                IsReadyForWork = Convert.ToBoolean(x["IsReadyForWork"])                ,
                IsClosed_Timestamp = Convert.IsDBNull(x["IsClosed_Timestamp"]) ? "" : (string)x["IsClosed_Timestamp"],
                Descripcion = Convert.IsDBNull(x["Descripcion"]) ? "" : (string)x["Descripcion"],
                NumImagenesDescp = Convert.IsDBNull(x["NumImagenesDescp"]) ? 0 : (int)x["NumImagenesDescp"],
                Dictamen = Convert.IsDBNull(x["Dictamen"]) ? "" : (string)x["Dictamen"],
                NumImagenesDictamen = Convert.IsDBNull(x["NumImagenesDictamen"]) ? 0 : (int)x["NumImagenesDictamen"],
                IsClosed_UserId = Convert.IsDBNull(x["IsClosed_UserId"]) ? "" : (string)x["IsClosed_UserId"],
                IsClosed_Successfully_UserId = Convert.IsDBNull(x["IsClosed_Successfully_UserId"]) ? "" : (string)x["IsClosed_Successfully_UserId"],
                IsClosed_Successfully_Timestamp = Convert.IsDBNull(x["IsClosed_Successfully_Timestamp"]) ? "" : (string)x["IsClosed_Successfully_Timestamp"],

        }).ToList();

            return Json(listTicketsEditoriales, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetDataTicketId (int id =0)
        {
            SqlData spSql = new SqlData();
            DataTable TicketsEditoriales = spSql.spGetData("[dbo].[Tickets_Editoriales]", new string[] { "@Accion:Read_TicketsId", "@TicketId:" + id });
            List<TicketsEditorialesViewModel> listTicketsEditoriales = TicketsEditoriales.AsEnumerable().Select(x => new TicketsEditorialesViewModel
            {
                id = Convert.IsDBNull(x["id"]) ? 0 : (int)x["id"],
                Maestro_Orden_PrioridadId = Convert.IsDBNull(x["Maestro_Orden_PrioridadId"]) ? "" : (string)x["Maestro_Orden_PrioridadId"],
                Updated_At = Convert.IsDBNull(x["Updated_At"]) ? "" : (string)x["Updated_At"],
                UserId = Convert.IsDBNull(x["UserId"]) ? "" : (string)x["UserId"],
               Nombre_Area = Convert.IsDBNull(x["Nombre_Area"]) ? "" : (string)x["Nombre_Area"],
                Maestro_EditorialesId = Convert.IsDBNull(x["Maestro_EditorialesId"]) ? "" : (string)x["Maestro_EditorialesId"],
                IsClosed = Convert.ToBoolean(x["IsClosed"]),
                IsClosed_Successfully = Convert.ToBoolean(x["IsClosed_Successfully"]),
                isticket_cancelled = Convert.ToBoolean(x["isticket_cancelled"]),
                Rol_Usuario = Convert.IsDBNull(x["Rol_Usuario"]) ? "" : (string)x["Rol_Usuario"],
                TiempoEstimadoRespuesta = Convert.IsDBNull(x["TiempoEstimadoRespuesta"]) ? 0 : (double)x["TiempoEstimadoRespuesta"],
                TiempoRealRespuesta = Convert.IsDBNull(x["TiempoRealRespuesta"]) ? 0 : (double)x["TiempoRealRespuesta"],
                IsReadyForWork = Convert.ToBoolean(x["IsReadyForWork"]),
                IsClosed_Timestamp = Convert.IsDBNull(x["IsClosed_Timestamp"]) ? "" : (string)x["IsClosed_Timestamp"],
                Descripcion = Convert.IsDBNull(x["Descripcion"]) ? "" : (string)x["Descripcion"],
                NumImagenesDescp = Convert.IsDBNull(x["NumImagenesDescp"]) ? 0 : (int)x["NumImagenesDescp"],
                Dictamen = Convert.IsDBNull(x["Dictamen"]) ? "" : (string)x["Dictamen"],
                NumImagenesDictamen = Convert.IsDBNull(x["NumImagenesDictamen"]) ? 0 : (int)x["NumImagenesDictamen"],
                IsClosed_UserId = Convert.IsDBNull(x["IsClosed_UserId"]) ? "" : (string)x["IsClosed_UserId"]
            }).ToList();

            return Json(listTicketsEditoriales, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetLevels()
        {
            SqlData spSql = new SqlData();
            DataTable MaestroNiveles = spSql.spGetData("[dbo].[Tickets_Editoriales]", new string[] { "@Accion:GetLevels" });
            List<TicketsEditorialesViewModel> listMaestroNiveles = MaestroNiveles.AsEnumerable().Select(x => new TicketsEditorialesViewModel
            {
               // PrioridadTicket = Convert.IsDBNull(x["Prioridad"]) ? "" : (string)x["Prioridad"]
               IdPrioridad = Convert.IsDBNull(x["Id"]) ? 0 : (int)x["Id"] 

            }).ToList();

            return Json(listMaestroNiveles, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GETAreas()
        {
            SqlData spSql = new SqlData();
            DataTable MaestroAreas = spSql.spGetData("[dbo].[Tickets_Editoriales]", new string[] { "@Accion:GETAreas"});
            List<TicketsEditorialesViewModel> listMaestroAreas = MaestroAreas.AsEnumerable().Select(x => new TicketsEditorialesViewModel
            {
                Nombre_Area = Convert.IsDBNull(x["Nombre"]) ? "" : (string)x["Nombre"]

            }).ToList();

            return Json(listMaestroAreas, JsonRequestBehavior.AllowGet);

        }

        //public JsonResult GETEditoriales()
        //{
        //    SqlData spSql = new SqlData();
        //    DataTable MaestroEditoriales = spSql.spGetData("[dbo].[Tickets_Editoriales]", new string[] { "@Accion:GETEditoriales" });
        //    List<TicketsEditorialesViewModel> listMaestroEditoriales = MaestroEditoriales.AsEnumerable().Select(x => new TicketsEditorialesViewModel
        //    {
        //        idEditoriales = Convert.IsDBNull(x["Id"]) ? 0 : (int)x["Id"]
        //        ,EntidadTicket = Convert.IsDBNull(x["Nombre"]) ? "" : (string)x["Nombre"]

        //    }).ToList();

        //    return Json(listMaestroEditoriales, JsonRequestBehavior.AllowGet);

        //}

        public ActionResult UPDATEPrincipal (int ordenId, int idPrioridad)
        {
            SqlData spSql = new SqlData();
            spSql.spGetData("[dbo].[Tickets_Editoriales]", new string[] { "@Accion:Update_Priority", "@TicketId:" + ordenId, "@prioridadId:" + idPrioridad });

            return RedirectToAction("index");

        }

        public ActionResult UpdateIsClosed(int ordenId, bool isClosed )
        {

            SqlData spSql = new SqlData();
            spSql.spGetData("[dbo].[Tickets_Editoriales]", new string[] { "@Accion:Update_IsClosed", "@TicketId:" + ordenId, "@IsClosed:" + isClosed });

            return RedirectToAction("index");
        }
        public ActionResult UpdateIsClosedSuccessfully(int ordenId, bool isClosedSuccess)
        {

            SqlData spSql = new SqlData();
            spSql.spGetData("[dbo].[Tickets_Editoriales]", new string[] { "@Accion:Update_IsClosed_Successfully", "@TicketId:" + ordenId, "@IsClosed_Successfully:" + isClosedSuccess });

            return RedirectToAction("index");
        }

        public ActionResult UpdateIsTicketCancelled(int ordenId, bool isTicketClosed)
        {

            SqlData spSql = new SqlData();
            spSql.spGetData("[dbo].[Tickets_Editoriales]", new string[] { "@Accion:Update_IsTicket_Cancelled", "@TicketId:" + ordenId, "@IsTicket_Cancelled:" + isTicketClosed });

            return RedirectToAction("index");
        }

        public JsonResult GetDataTicketInc(int OrdenId = 0)
        {
            DataTable ds = new DataTable();
            using (SqlConnection con = new SqlConnection(conBD))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("Tickets_Editoriales", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Accion", "READ_TICKET_INC");
                    cmd.Parameters.AddWithValue("@OrdenId", OrdenId);
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter();
                    cmd.CommandTimeout = 0;
                    da.SelectCommand = cmd;
                    ds = new DataTable();
                    da.Fill(ds);
                    con.Close();
                }
                catch (Exception)
                {
                    con.Close();
                    throw;
                }
            }
            List<TicketIncidenciasViewModel> dataInc = new List<TicketIncidenciasViewModel>();

            dataInc = (from DataRow a in ds.Rows
                       select new TicketIncidenciasViewModel()
                       {
                           //NumTicket = Convert.ToString(a["NumTicket"]),
                           IdIncidencia = Convert.IsDBNull(a["IdSeguimiento"]) ? 0 : (int)a["IdSeguimiento"],
                           Incidencia = Convert.IsDBNull(a["Incidencia"]) ? "" : (string)a["Incidencia"],
                           Area = Convert.IsDBNull(a["Area"]) ? "" : (string)a["Area"],
                           ResponsableArea = Convert.IsDBNull(a["ResponsableArea"]) ? "" : (string)a["ResponsableArea"],
                           Observaciones = Convert.IsDBNull(a["Observaciones"]) ? "" : (string)a["Observaciones"],
                           NumImagenes = Convert.IsDBNull(a["NumImagenes"]) ? 0 : (int)a["NumImagenes"],
                           //Arhivo = Convert.ToString(a["Arhivo"]),
                       }).ToList();

            return Json(dataInc, JsonRequestBehavior.AllowGet);
        }
        //IMAGENES POR INCIDENCIA
        public JsonResult GetImages(int Id=0, string opcion = "")
        {
            DataTable ds = new DataTable();
            using (SqlConnection con = new SqlConnection(conBD))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("Tickets_Editoriales", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (opcion == "PorOrdenDesc")
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Accion", "GetImagesDescripcionByOrdenId");
                        cmd.Parameters.AddWithValue("@OrdenId", Id);
                    }
                    if (opcion == "PorOrdenDictamen")
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Accion", "GetImagesDictamenByOrdenId");
                        cmd.Parameters.AddWithValue("@OrdenId", Id);
                    }
                    if (opcion == "")
                    {
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Accion", "GET_IMAGES");
                        cmd.Parameters.AddWithValue("@IncidenciasSeguimientoId", Id);
                    }
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter();
                    cmd.CommandTimeout = 0;
                    da.SelectCommand = cmd;
                    ds = new DataTable();
                    da.Fill(ds);
                    con.Close();
                }
                catch (Exception)
                {
                    con.Close();
                    throw;
                }
            }
            List<TicketIncidenciasImgViewModel> data = new List<TicketIncidenciasImgViewModel>();

            data = (from DataRow a in ds.Rows
                       select new TicketIncidenciasImgViewModel()
                       {
                           Imagen = Convert.ToString(a["ImagePath"])
                       }).ToList();

            return Json(data, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetSeguimientoDetalle(int id = 0)
        {
            DataTable ds = new DataTable();
            using (SqlConnection con = new SqlConnection(conBD))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("Tickets_Editoriales", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Accion", "Detalles_Inc");
                    cmd.Parameters.AddWithValue("@ID_IncidenciaSeguimientoDI", id);
                    //cmd.Parameters.AddWithValue("@OrdenId", Id);
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter();
                    cmd.CommandTimeout = 0;
                    da.SelectCommand = cmd;
                    ds = new DataTable();
                    da.Fill(ds);
                    con.Close();
                }
                catch (Exception)
                {
                    con.Close();
                    throw;
                }
            }
            List<TicketIncidenciasViewModel> dataInc = new List<TicketIncidenciasViewModel>();

            dataInc = (from DataRow a in ds.Rows
                       select new TicketIncidenciasViewModel()
                       {
                           //NumTicket = Convert.ToString(a["NumTicket"]),
                           IdIncidencia = Convert.ToInt32(a["IdIncidencia"]),
                           Incidencia = Convert.ToString(a["Incidencia"]),
                           Area = Convert.ToString(a["Area"]),
                           ResponsableArea = Convert.ToString(a["ResponsableArea"]),
                           Observaciones = Convert.ToString(a["Observaciones"]),
                           NumImagenes = Convert.ToInt32(a["NumImagenes"]),
                           //Arhivo = Convert.ToString(a["Arhivo"]),
                       }).ToList();

            return Json(dataInc, JsonRequestBehavior.AllowGet);
        }

        public string SaveImagesBySeguimiento(string datos = "")
        {
            var datosRecibidos = datos.Split('/');
            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase fileSoli = Request.Files[0];
                var originalDirectory = new DirectoryInfo(string.Format("{0}Content\\Images\\", Server.MapPath(@"\"))).ToString();
                var originalDirectory2 = new DirectoryInfo(string.Format("{0}", Server.MapPath(@"\"))).ToString();
                var countImgByProduct = GetCountImagesBySeguimientoId(Int32.Parse(datosRecibidos[0]));
                var subscript = countImgByProduct + 1;
                bool Exists = System.IO.Directory.Exists(originalDirectory);
                int accountant = 0;
                var path = "";
                var pathToSQLServer = "";

                if (!Exists)
                {
                    System.IO.Directory.CreateDirectory(originalDirectory);
                }

                //foreach (HttpPostedFileBase file in images.Files)
                //{
                if (fileSoli != null && fileSoli.ContentLength > 0)
                {
                    int subscript_C = subscript + accountant;
                    string currentfileName = System.IO.Path.GetFileName(fileSoli.FileName); //Current File Name

                    string preExtension = currentfileName.Substring(currentfileName.Length - 4); //File Extension
                    char getPoint = preExtension[0];
                    string extension = preExtension;
                    if (getPoint != '.')
                    {
                        string preExtension2 = currentfileName.Substring(currentfileName.Length - 5); //File Extension
                        extension = preExtension2;
                    }

                    var dia = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
                    var fecha = dia.Replace("/", "_");
                    var fecha2 = fecha.Replace(":", "_");
                    var fecha3 = fecha2.Replace(" ", "_");
                    string newfilename = "INC" + "_" + subscript_C; //New FileName

                    string p1 = originalDirectory2 + "/Content/Images/" + newfilename + ".png";
                    string p2 = originalDirectory2 + "/Content/Images/" + newfilename + ".jpg";
                    string p3 = originalDirectory2 + "/Content/Images/" + newfilename + ".jpeg";
                    string p4 = originalDirectory2 + "/Content/Images/" + newfilename + ".gif";

                    bool Exists2 = System.IO.File.Exists(p1);
                    bool Exists3 = System.IO.File.Exists(p2);
                    bool Exists4 = System.IO.File.Exists(p3);
                    bool Exists5 = System.IO.File.Exists(p4);

                    var cont3 = 0;
                    while (Exists2 || Exists3 || Exists4 || Exists5)
                    {
                        if (Exists2 || Exists3 || Exists4 || Exists5)
                        {
                            var cont2 = countImgByProduct + cont3;
                            newfilename = datosRecibidos[1] + "_" + cont2;
                            Exists2 = System.IO.File.Exists(originalDirectory + newfilename + ".png");
                            Exists3 = System.IO.File.Exists(originalDirectory + newfilename + ".jpg");
                            Exists4 = System.IO.File.Exists(originalDirectory + newfilename + ".jpeg");
                            Exists5 = System.IO.File.Exists(originalDirectory + newfilename + ".gif");

                            cont3++;
                        }
                    }
                    accountant++;

                    path = originalDirectory + newfilename + extension;
                    pathToSQLServer = "/Content/Images/" + newfilename + extension;
                }

                fileSoli.SaveAs(path);

                using (SqlConnection con = new SqlConnection(conBD))
                {
                    SqlCommand comando = new SqlCommand(sql, con);
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@Accion", "SaveImgesBySeguimientoId");
                    comando.Parameters.AddWithValue("@IncidenciasSeguimientoId", Int32.Parse(datosRecibidos[0]));
                    comando.Parameters.AddWithValue("@ImagePath", pathToSQLServer);

                    con.Open();

                    SqlDataReader reader = comando.ExecuteReader();

                }

                //var idImage = GetIdByImagePath(pathToSQLServer);

                //using (SqlConnection con = new SqlConnection(conBD))
                //{
                //    SqlCommand comando = new SqlCommand(sql, con);
                //    comando.CommandType = CommandType.StoredProcedure;
                //    comando.Parameters.AddWithValue("@Accion", "SaveImageToProductBA");
                //    comando.Parameters.AddWithValue("@Product_Id", datosRecibidos[0]);
                //    comando.Parameters.AddWithValue("@Image_Id", idImage);

                //    con.Open();

                //    SqlDataReader reader = comando.ExecuteReader();
                //}
                //}
                return "done";
            }
            else
            {
                return "fail";
            }

            //return Json("result", JsonRequestBehavior.AllowGet);
        }
        public int GetCountImagesBySeguimientoId(int Id)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(conBD))
            {
                SqlCommand comando = new SqlCommand(sql, con);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Accion", "GetCountImagesBySeguimientoId");
                comando.Parameters.AddWithValue("@IncidenciasSeguimientoId", Id);

                con.Open();

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result = reader.IsDBNull(0) == true ? 0 : reader.GetInt32(0);
                    }
                }
            }
            return result;
        }
        public int GetCountImagesByOrdenDescrip(int Id)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(conBD))
            {
                SqlCommand comando = new SqlCommand(sql, con);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Accion", "GetCountImagesByOrdenDescrip");
                comando.Parameters.AddWithValue("@OrdenId", Id);

                con.Open();

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result = reader.IsDBNull(0) == true ? 0 : reader.GetInt32(0);
                    }
                }
            }
            return result;
        }
        public int GetCountImagesByOrdenDictamen(int Id)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(conBD))
            {
                SqlCommand comando = new SqlCommand(sql, con);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Accion", "GetCountImagesByOrdenDictamen");
                comando.Parameters.AddWithValue("@OrdenId", Id);

                con.Open();

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result = reader.IsDBNull(0) == true ? 0 : reader.GetInt32(0);
                    }
                }
            }
            return result;
        }

        public int GetIdByImagePath(string path)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(conBD))
            {
                SqlCommand comando = new SqlCommand(sql, con);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Accion", "GetIdIncidenciaByImagePath");
                comando.Parameters.AddWithValue("@ImagePath", path);

                con.Open();

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result = reader.IsDBNull(0) == true ? 0 : reader.GetInt32(0);
                    }
                }
            }
            return result;
        }

        public JsonResult PrepareDownloadFile(int Id = 0, string Img = "")
        {
            if (Id != 0)
            {
                ID = Id;
                return Json("1", JsonRequestBehavior.AllowGet);
            }
            else if (Img != "")
            {
                ID = Id;
                IMG = Img;
                return Json("2", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("InvalidData", JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult DownloadFile(int Id = 0)
        {
            List<TicketIncidenciasImgData> listImages;
            //using (db)
            //{
                if (IMG == "")
                {
                    SqlData spSql = new SqlData();
                    DataTable ImagesBYiD = spSql.spGetData("[dbo].[Tickets_Editoriales]", new string[] { "@Accion:GET_IMAGES", "@IncidenciasSeguimientoId:" + Id });
                    listImages = ImagesBYiD.AsEnumerable().Select(x => new TicketIncidenciasImgData
                    {
                        ImagePathsDounload = Convert.IsDBNull(x["ImagePath"]) ? "" : (string)x["ImagePath"]

                    }).ToList();

                }
                else
                {
                        SqlData spSql = new SqlData();
                        DataTable ImagesBYiD = spSql.spGetData("[dbo].[Tickets_Editoriales]", new string[] { "@Accion:GET_IMAGESBYPATH", "@ImagePath:" + IMG });
                        listImages = ImagesBYiD.AsEnumerable().Select(x => new TicketIncidenciasImgData
                        {
                            ImagePathsDounload = Convert.IsDBNull(x["ImagePath"]) ? "" : (string)x["ImagePath"]

                        }).ToList();
            }
            //}
            var Images = listImages[0];
            var docto = "Imagenes";

            if (IMG == "")
            {
                using (var memoryStream = new MemoryStream())
                {
                    using (var ziparchive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                    {
                        for (int i = 0; i < listImages.Count; i++)
                        {
                            var originalDirectory = new DirectoryInfo(string.Format(@"{0}Content\SeguimentoImgs\", Server.MapPath(@"\"))).ToString();
                            DateTime thisDay = DateTime.Today;
                            string dbpath = listImages[i].ImagePathsDounload.ToString();
                            int position = dbpath.IndexOf(".");
                            string ext = dbpath.Substring(position);
                            string date = String.Format("{0:s}", DateTime.Today);
                            var FileName = "imagen" + "_" + date + i + ext;
                            //var folder = ConfigurationManager.AppSettings["folder"];
                            var folder = Server.MapPath("/");
                            var path = listImages[i].ImagePathsDounload.Split('/');
                            var archiPath = path[1] + "/" + path[2] + "/" + path[3];
                            //var FullPath = folder.Replace('\\', '/') + archiPath;
                            var FullPath = folder + path;
                            ziparchive.CreateEntry(FileName);
                            //ziparchive.CreateEntryFromFile(FullPath, FileName);
                        }
                    }
                    return File(memoryStream.ToArray(), "application/zip", "Documentacion_" + docto + ".zip");
                }
            }
            else
            {
                byte[] fileBytes = System.IO.File.ReadAllBytes(@"c:\folder\myfile.ext");
                string fileName = "myfile.ext";
                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
                //return Content("");
            }
        }

        public JsonResult DeleteImage(string Path)
        {
            var result = true;
            var originalDirectory = new DirectoryInfo(string.Format("{0}", Server.MapPath(@"\"))).ToString();

            var IdSeguimientoDigital = GetIdByImagePath(Path);

            var pathpr = originalDirectory + Path;

            bool nameExists = System.IO.File.Exists(pathpr);
            //bool nameExists2 = System.IO.File.Exists("D:\\GitHub\\ProductosAutorizacionesCadenas\\Productos_AC\\Productos_AC\\/Content/Images/07007011.0001_4.jpg");



            if (nameExists)
            {
                System.IO.File.Delete(originalDirectory + Path);
                DeleteImageSeguimientoByImageId(IdSeguimientoDigital);
                //DeleteProductImage(IdImage);
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public void DeleteImageSeguimientoByImageId(int Id)
        {
            using (SqlConnection con = new SqlConnection(conBD))
            {
                SqlCommand comando = new SqlCommand(sql, con);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Accion", "DeleteImageIncidenciaById");
                comando.Parameters.AddWithValue("@ID_IncidenciaSeguimientoDI", Id);

                con.Open();

                SqlDataReader reader = comando.ExecuteReader();
            }
        }

        public string EditCommentByIdSeguimiento (int IdIncidencia = 0, string Comentario = "")
        {
            DataTable ds = new DataTable();
            using (SqlConnection con = new SqlConnection(conBD))
            {
                con.Open();
                try
                {

                    SqlCommand cmd = new SqlCommand("Tickets_Editoriales", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Accion", "EditCommentByIdSeguimiento");
                    cmd.Parameters.AddWithValue("@IdSeguimiento", IdIncidencia);
                    cmd.Parameters.AddWithValue("@Observaciones", Comentario);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return "true";
                }
                catch (Exception)
                {
                    con.Close();
                    throw;
                }
            }

        }

        public void DeleteSeguimiento(int IdSeguimiento = 0)
        {
            SqlData spSql = new SqlData();
            spSql.spGetData("[dbo].[Tickets_Editoriales]", new string[] { "@Accion:DeleteSeguimiento", "@IdSeguimiento:" + IdSeguimiento });
        }

        //REPORTE 
        [HttpGet]
        public ActionResult OpenReport(int IdOrden)
        {
            XtraReport2 report = new XtraReport2();

            report.Parameters["OrdenId"].Value = IdOrden;
            
            //xrPictureBox1
            CachedReportSourceWeb cachedReportSource = new CachedReportSourceWeb(report);

            return View("OpenReport", cachedReportSource);
        }
       
        //IMAGENES POR ORDEN
        public JsonResult UpdateDictamenDescripction (string opc, int OrdenId, string Datos)
        {
            var Id = "0";
            int i = 0;
            DataTable ds = new DataTable();
            using (SqlConnection con = new SqlConnection(conBD))
            {
                con.Open();
                SqlCommand comando = new SqlCommand("[dbo].[Tickets_Editoriales]", con);
                try
                {
                    if (opc == "PorOrdenDictamen")
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddWithValue("@Accion", "UpdateInsertDictamen");
                        comando.Parameters.AddWithValue("@dictamen", Datos);
                        comando.Parameters.AddWithValue("@OrdenId", OrdenId);
                        comando.Parameters.Add("@Identy", SqlDbType.Int).Direction = ParameterDirection.Output;
                        i = comando.ExecuteNonQuery();
                        if (i == 1)
                        {
                            Id = comando.Parameters["@Identy"].Value.ToString();
                            //return Json(Id, JsonRequestBehavior.AllowGet);
                        }
                        if (i== -1)
                        {
                            Id = comando.Parameters["@Identy"].Value.ToString();
                            //return Json(Id, JsonRequestBehavior.AllowGet);
                        }

                        //spSql.spGetData("[dbo].[Tickets_Editoriales]", new string[] { "@Accion:UpdateInsertDictamen", "@dictamen:" + Datos, "@OrdenId:" + OrdenId });
                    }
                    if (opc == "PorOrdenDesc")
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddWithValue("@Accion", "UpdateInsertDescripcion");
                        comando.Parameters.AddWithValue("@descripcion", Datos);
                        comando.Parameters.AddWithValue("@OrdenId", OrdenId);
                        comando.Parameters.Add("@Identy", SqlDbType.Int).Direction = ParameterDirection.Output;
                        SqlDataReader reader = comando.ExecuteReader();
                        if (reader.RecordsAffected == 1)
                        {
                            Id = comando.Parameters["@Identy"].Value.ToString();
                            //return Json(Id, JsonRequestBehavior.AllowGet);
                        }
                        if (reader.RecordsAffected == -1)
                        {
                            Id = comando.Parameters["@Identy"].Value.ToString();
                            //return Json(Id, JsonRequestBehavior.AllowGet);
                        }
                        //spSql.spGetData("[dbo].[Tickets_Editoriales]", new string[] { "@Accion:UpdateInsertDescripcion", "@descripcion:" + Datos, "@OrdenId:" + OrdenId });
                    }
                    return Json(Id, JsonRequestBehavior.AllowGet);
                }
                catch (Exception)
                {
                    con.Close();
                    throw;
                }
            }
        }

        public string SaveImagesByDescripcion_Dictamen(string datos = "")
        {
            var datosRecibidos = datos.Split('/');
            var datosRecibidos2 = datosRecibidos[1].Split('^');
            var opcion = datosRecibidos2[2];
            var countImgByProduct = 0;
            var Name = "";
            if (Request.Files.Count > 0)
            {
                HttpPostedFileBase fileSoli = Request.Files[0];
                var originalDirectory = new DirectoryInfo(string.Format("{0}Content\\Images\\", Server.MapPath(@"\"))).ToString();
                var originalDirectory2 = new DirectoryInfo(string.Format("{0}", Server.MapPath(@"\"))).ToString();
                if (opcion == "PorOrdenDesc")
                {
                    countImgByProduct = GetCountImagesByOrdenDescrip(Int32.Parse(datosRecibidos[0]));
                    Name = "Desc";
                }
                if (opcion == "PorOrdenDictamen")
                {
                    countImgByProduct = GetCountImagesByOrdenDictamen(Int32.Parse(datosRecibidos[0]));
                    Name = "Dictamen";
                }
                var subscript = countImgByProduct + 1;
                bool Exists = System.IO.Directory.Exists(originalDirectory);
                int accountant = 0;
                var path = "";
                var pathToSQLServer = "";

                if (!Exists)
                {
                    System.IO.Directory.CreateDirectory(originalDirectory);
                }

                //foreach (HttpPostedFileBase file in images.Files)
                //{
                if (fileSoli != null && fileSoli.ContentLength > 0)
                {
                    int subscript_C = subscript + accountant;
                    string currentfileName = System.IO.Path.GetFileName(fileSoli.FileName); //Current File Name

                    string preExtension = currentfileName.Substring(currentfileName.Length - 4); //File Extension
                    char getPoint = preExtension[0];
                    string extension = preExtension;
                    if (getPoint != '.')
                    {
                        string preExtension2 = currentfileName.Substring(currentfileName.Length - 5); //File Extension
                        extension = preExtension2;
                    }

                    var dia = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");
                    var fecha = dia.Replace("/", "_");
                    var fecha2 = fecha.Replace(":", "_");
                    var fecha3 = fecha2.Replace(" ", "_");
                    string newfilename = Name + "_" + subscript_C; //New FileName

                    string p1 = originalDirectory2 + "/Content/Images/" + newfilename + ".png";
                    string p2 = originalDirectory2 + "/Content/Images/" + newfilename + ".jpg";
                    string p3 = originalDirectory2 + "/Content/Images/" + newfilename + ".jpeg";
                    string p4 = originalDirectory2 + "/Content/Images/" + newfilename + ".gif";

                    bool Exists2 = System.IO.File.Exists(p1);
                    bool Exists3 = System.IO.File.Exists(p2);
                    bool Exists4 = System.IO.File.Exists(p3);
                    bool Exists5 = System.IO.File.Exists(p4);

                    var cont3 = 0;
                    while (Exists2 || Exists3 || Exists4 || Exists5)
                    {
                        if (Exists2 || Exists3 || Exists4 || Exists5)
                        {
                            var cont2 = countImgByProduct + cont3;
                            newfilename = Name + "_" + datosRecibidos[0] + "_" + cont2;
                            Exists2 = System.IO.File.Exists(originalDirectory + newfilename + ".png");
                            Exists3 = System.IO.File.Exists(originalDirectory + newfilename + ".jpg");
                            Exists4 = System.IO.File.Exists(originalDirectory + newfilename + ".jpeg");
                            Exists5 = System.IO.File.Exists(originalDirectory + newfilename + ".gif");

                            cont3++;
                        }
                    }
                    accountant++;

                    path = originalDirectory + newfilename + extension;
                    pathToSQLServer = "/Content/Images/" + newfilename + extension;
                }

                fileSoli.SaveAs(path);

                using (SqlConnection con = new SqlConnection(conBD))
                {
                    SqlCommand comando = new SqlCommand(sql, con);
                    comando.CommandType = CommandType.StoredProcedure;
                    if (opcion == "PorOrdenDesc")
                    {
                        comando.Parameters.AddWithValue("@Accion", "SaveImgesByOrdenIdDescrip");
                        comando.Parameters.AddWithValue("@OrdenId", Int32.Parse(datosRecibidos[0]));
                        comando.Parameters.AddWithValue("@ImagePath", pathToSQLServer);
                        con.Open();
                        SqlDataReader reader = comando.ExecuteReader();
                    }
                    if (opcion == "PorOrdenDictamen")
                    {
                        comando.Parameters.AddWithValue("@Accion", "SaveImgesByOrdenIdDictamen");
                        comando.Parameters.AddWithValue("@OrdenId", Int32.Parse(datosRecibidos[0]));
                        comando.Parameters.AddWithValue("@ImagePath", pathToSQLServer);
                        con.Open();
                        SqlDataReader reader = comando.ExecuteReader();
                    }

                }

                //var idImage = GetIdByImagePath(pathToSQLServer);

                //using (SqlConnection con = new SqlConnection(conBD))
                //{
                //    SqlCommand comando = new SqlCommand(sql, con);
                //    comando.CommandType = CommandType.StoredProcedure;
                //    comando.Parameters.AddWithValue("@Accion", "SaveImageToProductBA");
                //    comando.Parameters.AddWithValue("@Product_Id", datosRecibidos[0]);
                //    comando.Parameters.AddWithValue("@Image_Id", idImage);

                //    con.Open();

                //    SqlDataReader reader = comando.ExecuteReader();
                //}
                //}
                return "done";
            }
            else
            {
                return "fail";
            }

            //return Json("result", JsonRequestBehavior.AllowGet);
        }

        public JsonResult PrepareDownloadFileDescripcion_Dictamen(int Id = 0, string Img = "")
        {
            if (Id != 0)
            {
                ID = Id;
                return Json("1", JsonRequestBehavior.AllowGet);
            }
            else if (Img != "")
            {
                ID = Id;
                IMG = Img;
                return Json("2", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("InvalidData", JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult DownloadFileDescripcion_Dictamen(int Id = 0, string opcion = "")
        {
            List<TicketIncidenciasImgData> listImages = new List<TicketIncidenciasImgData>();
            //using (db)
            //{
            if (IMG == "" )
            {
                SqlData spSql = new SqlData();
                if ( opcion == "PorOrdenDesc")
                {
                    DataTable ImagesBYiD = spSql.spGetData("[dbo].[Tickets_Editoriales]", new string[] { "@Accion:GetImagesDescripcionByOrdenId", "@OrdenId:" + Id });
                    listImages = ImagesBYiD.AsEnumerable().Select(x => new TicketIncidenciasImgData
                    {
                        ImagePathsDounload = Convert.IsDBNull(x["ImagePath"]) ? "" : (string)x["ImagePath"]

                    }).ToList();
                }
                if (opcion == "PorOrdenDictamen")
                {
                    DataTable ImagesBYiD = spSql.spGetData("[dbo].[Tickets_Editoriales]", new string[] { "@Accion:GetImagesDictamenByOrdenId", "@OrdenId:" + Id });
                    listImages = ImagesBYiD.AsEnumerable().Select(x => new TicketIncidenciasImgData
                    {
                        ImagePathsDounload = Convert.IsDBNull(x["ImagePath"]) ? "" : (string)x["ImagePath"]

                    }).ToList();
                }
            }
            else
            {
                SqlData spSql = new SqlData();
                if (opcion == "PorOrdenDesc")
                {
                    DataTable ImagesBYiD = spSql.spGetData("[dbo].[Tickets_Editoriales]", new string[] { "@Accion:GetImagesByPathDesc", "@ImagePath:" + IMG });
                    listImages = ImagesBYiD.AsEnumerable().Select(x => new TicketIncidenciasImgData
                    {
                        ImagePathsDounload = Convert.IsDBNull(x["ImagePath"]) ? "" : (string)x["ImagePath"]

                    }).ToList();
                }
                if (opcion == "PorOrdenDictamen")
                {
                    DataTable ImagesBYiD = spSql.spGetData("[dbo].[Tickets_Editoriales]", new string[] { "@Accion:GetImagesByPathDictamen", "@ImagePath:" + IMG });
                    listImages = ImagesBYiD.AsEnumerable().Select(x => new TicketIncidenciasImgData
                    {
                        ImagePathsDounload = Convert.IsDBNull(x["ImagePath"]) ? "" : (string)x["ImagePath"]

                    }).ToList();
                }
            }
            //}
            var Images = listImages[0];
            var docto = "Imagenes";

            if (IMG == "")
            {
                using (var memoryStream = new MemoryStream())
                {
                    using (var ziparchive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                    {
                        for (int i = 0; i < listImages.Count; i++)
                        {
                            var originalDirectory = new DirectoryInfo(string.Format(@"{0}Content\SeguimentoImgs\", Server.MapPath(@"\"))).ToString();
                            DateTime thisDay = DateTime.Today;
                            string dbpath = listImages[i].ImagePathsDounload.ToString();
                            int position = dbpath.IndexOf(".");
                            string ext = dbpath.Substring(position);
                            string date = String.Format("{0:s}", DateTime.Today);
                            var FileName = "imagen" + "_" + date + i + ext;
                            //var folder = ConfigurationManager.AppSettings["folder"];
                            var folder = Server.MapPath("/");
                            var path = listImages[i].ImagePathsDounload.Split('/');
                            var archiPath = path[1] + "/" + path[2] + "/" + path[3];
                            //var FullPath = folder.Replace('\\', '/') + archiPath;
                            var FullPath = folder + path;
                            ziparchive.CreateEntry(FileName);
                            //ziparchive.CreateEntryFromFile(FullPath, FileName);
                        }
                    }
                    return File(memoryStream.ToArray(), "application/zip", "Documentacion_" + docto + ".zip");
                }
            }
            else
            {
                byte[] fileBytes = System.IO.File.ReadAllBytes(@"c:\folder\myfile.ext");
                string fileName = "myfile.ext";
                return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
                //return Content("");
            }
        }

        public int GetIdByImagePathDesc(string path)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(conBD))
            {
                SqlCommand comando = new SqlCommand(sql, con);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Accion", "GetIdByImagePathDesc");
                comando.Parameters.AddWithValue("@ImagePath", path);

                con.Open();

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result = reader.IsDBNull(0) == true ? 0 : reader.GetInt32(0);
                    }
                }
            }
            return result;
        }
        public int GetIdByImagePathDictamen(string path)
        {
            int result = 0;
            using (SqlConnection con = new SqlConnection(conBD))
            {
                SqlCommand comando = new SqlCommand(sql, con);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@Accion", "GetIdByImagePathDictamen");
                comando.Parameters.AddWithValue("@ImagePath", path);

                con.Open();

                SqlDataReader reader = comando.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        result = reader.IsDBNull(0) == true ? 0 : reader.GetInt32(0);
                    }
                }
            }
            return result;
        }
        public void DeleteImageByIdDescripcion_Dictamen(int Id, string opcion)
        {
            using (SqlConnection con = new SqlConnection(conBD))
            {
                SqlCommand comando = new SqlCommand(sql, con);
                comando.CommandType = CommandType.StoredProcedure;
                if (opcion == "PorOrdenDesc")
                {
                    comando.Parameters.AddWithValue("@Accion", "DeleteImageDescripcionById");
                    comando.Parameters.AddWithValue("@Maestro_Orden_DescripcionId", Id);
                    con.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                }
                if (opcion == "PorOrdenDictamen")
                {
                    comando.Parameters.AddWithValue("@Accion", "DeleteImageDictamenById");
                    comando.Parameters.AddWithValue("@Maestro_Orden_DictamenId", Id);
                    con.Open();
                    SqlDataReader reader = comando.ExecuteReader();
                }
            }
        }
        public JsonResult DeleteImageDescripcion_Dictamen(string Path, string opcion)
        {
            var result = true;
            var Id = 0;
            var originalDirectory = new DirectoryInfo(string.Format("{0}", Server.MapPath(@"\"))).ToString();

            if (opcion == "PorOrdenDesc")
            {
                Id = GetIdByImagePathDesc(Path);
                var pathpr = originalDirectory + Path;

                bool nameExists = System.IO.File.Exists(pathpr);

                if (nameExists)
                {
                    System.IO.File.Delete(originalDirectory + Path);
                    DeleteImageByIdDescripcion_Dictamen(Id, opcion);
                }
            }
            if (opcion == "PorOrdenDictamen")
            {
                Id = GetIdByImagePathDictamen(Path);
                var pathpr = originalDirectory + Path;

                bool nameExists = System.IO.File.Exists(pathpr);

                if (nameExists)
                {
                    System.IO.File.Delete(originalDirectory + Path);
                    DeleteImageByIdDescripcion_Dictamen(Id, opcion);
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

    }
}
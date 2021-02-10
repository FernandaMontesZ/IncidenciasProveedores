using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketManagement.DataAccess;
using System.Data;
using System.Data.SqlClient;
using TicketManagement.Models.ViewModels;

namespace TicketManagement.Controllers
{
    public class TicketsEditorialesController : Controller
    {
        // GET: TicketsEditoriales
        public ActionResult Index()
        {

            return View();
        }

        //Leer Lista



        public JsonResult GetDataTickets()
        {

            SqlData spSql = new SqlData();
            DataTable TicketsEditoriales = spSql.spGetData("[dbo].[Tickets_Editoriales]", new string[] { "@Accion:READ_Ticket"});
            List<TicketsEditorialesViewModel> listTicketsEditoriales = TicketsEditoriales.AsEnumerable().Select(x => new TicketsEditorialesViewModel
            {
                OrdenId = Convert.IsDBNull(x["OrdenId"]) ? 0 : (int)x["OrdenId"]
                ,
                FolioTicket = Convert.IsDBNull(x["FolioTicket"]) ? "" : (string)x["FolioTicket"]
                ,
                PrioridadTicket = Convert.IsDBNull(x["PrioridadTicket"]) ? "" : (string)x["PrioridadTicket"]
                ,
                FechaCreacion = Convert.IsDBNull(x["FechaCreacion"]) ? "" : (string)x["FechaCreacion"]
                ,
                CreadoPor = Convert.IsDBNull(x["CreadoPor"]) ? "" : (string)x["CreadoPor"]
                ,
                Area = Convert.IsDBNull(x["Area"]) ? "" : (string)x["Area"]
                ,
                EntidadTicket = Convert.IsDBNull(x["EntidadTicket"]) ? "" : (string)x["EntidadTicket"]
                ,
                CerrarTicketNegativo = Convert.ToBoolean(x["CerrarTicketNegativo"])
                ,
                CerrarTicketPositivo = Convert.ToBoolean(x["CerrarTicketPositivo"])
                ,
                IsTicketCancelled = Convert.ToBoolean(x["IsTicketCancelled"])
                ,
                TipoUsuario = Convert.IsDBNull(x["TipoUsuario"]) ? "" : (string)x["TipoUsuario"]
                //,TiempoRespuestaHoras = Convert.IsDBNull(x["TiempoRespuestaHoras"]) ? "" : (string)x["TiempoRespuestaHoras"]
                //,Observaciones = Convert.IsDBNull(x["Observaciones"]) ? "" : (string)x["Observaciones"]
            }).ToList();

            return Json(listTicketsEditoriales, JsonRequestBehavior.AllowGet);
        }


        //Leer 

        public JsonResult GetLevels()
        {
            SqlData spSql = new SqlData();
            DataTable MaestroNiveles = spSql.spGetData("[dbo].[Tickets_Editoriales]", new string[] { "@Accion:GetLevels" });
            List<TicketsEditorialesViewModel> listMaestroNiveles = MaestroNiveles.AsEnumerable().Select(x => new TicketsEditorialesViewModel
            {
                PrioridadTicket = Convert.IsDBNull(x["Prioridad"]) ? "" : (string)x["Prioridad"]

            }).ToList();

            return Json(listMaestroNiveles, JsonRequestBehavior.AllowGet);

        }


        //Leer 

        public JsonResult GETAreas()
        {
            SqlData spSql = new SqlData();
            DataTable MaestroAreas = spSql.spGetData("[dbo].[Tickets_Editoriales]", new string[] { "@Accion:GETAreas" });
            List<TicketsEditorialesViewModel> listMaestroAreas = MaestroAreas.AsEnumerable().Select(x => new TicketsEditorialesViewModel
            {
                Area = Convert.IsDBNull(x["Nombre"]) ? "" : (string)x["Nombre"]

            }).ToList();

            return Json(listMaestroAreas, JsonRequestBehavior.AllowGet);

        }


        public JsonResult GETIncidencias()
        {
            SqlData spSql = new SqlData();
            DataTable MaestroIncidencias = spSql.spGetData("[dbo].[Tickets_Editoriales]", new string[] { "@Accion:GETIncidencias" });


            List<TicketsEditorialesViewModel> listMaestroIncidencias = MaestroIncidencias.AsEnumerable().Select(x => new TicketsEditorialesViewModel
            {
                Area = Convert.IsDBNull(x["Nombre"]) ? "" : (string)x["Nombre"]

            }).ToList();

            return Json(listMaestroIncidencias, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GETRespo()
        {
            SqlData spSql = new SqlData();
            DataTable MaestroResponsable = spSql.spGetData("[dbo].[Tickets_Editoriales]", new string[] { "@Accion:GETRespo" });


            List<TicketsEditorialesViewModel> listMaestroResponsable = MaestroResponsable.AsEnumerable().Select(x => new TicketsEditorialesViewModel
            {



               elID = Convert.IsDBNull(x["Maestro_AreasId"]) ? 0 : (int)x["Maestro_AreasId"],
               
                 Responsable = Convert.IsDBNull(x["Nombres"]) ? "" : (string)x["Nombres"]

            }).ToList();

            return Json(listMaestroResponsable, JsonRequestBehavior.AllowGet);

        }

        public JsonResult GetResponsables()
        {
            SqlData spSql = new SqlData();
            DataTable MaestroR = spSql.spGetData("[dbo].[Tickets_Editoriales]", new string[] { "@Accion:GetResponsables" });


            List<TicketsEditorialesViewModel> listMaestroR = MaestroR.AsEnumerable().Select(x => new TicketsEditorialesViewModel
            {


                Name = Convert.IsDBNull(x["Nombre"]) ? "" : (string)x["Nombre"],


                Names = Convert.IsDBNull(x["Nombres"]) ? "" : (string)x["Nombres"]

            }).ToList();

            return Json(listMaestroR, JsonRequestBehavior.AllowGet);

        }












        /// 
        /// /[dbo].[Maestro_Incidencias_Orden]
        /// 

        public JsonResult Agregar()
        {

            SqlData spSql = new SqlData();

            // 

            DataTable MaestroAreas = spSql.spGetData("[dbo].[Maestro_Incidencias_Orden]", new string[] { "@Accion:ADD_TICKET"});
            List<TicketsEditorialesViewModel> listMaestroAreas = MaestroAreas.AsEnumerable().Select(x => new TicketsEditorialesViewModel
            {
                Area = Convert.IsDBNull(x["Nombre"]) ? "" : (string)x["Nombre"]

            }).ToList();

            return Json(listMaestroAreas, JsonRequestBehavior.AllowGet);



        }

        // ///////////////////////////Borrar

        public JsonResult Borrar()
        {

            SqlData spSql = new SqlData();

            // 

            DataTable MaestroAreas = spSql.spGetData("[dbo].[Maestro_Incidencias_Orden]", new string[] { "@Accion:DELETE_TICKET" });




            List<TicketsEditorialesViewModel> listMaestroAreas = MaestroAreas.AsEnumerable().Select(x => new TicketsEditorialesViewModel
            {
                    Area = Convert.IsDBNull(x["Nombre"]) ? "" : (string)x["Nombre"]

            }).ToList();

            return Json(listMaestroAreas, JsonRequestBehavior.AllowGet);



        }



        // ///////////////////////////Editar

        public JsonResult Editar()
        {

            SqlData spSql = new SqlData();

            // 

            DataTable MaestroAreas = spSql.spGetData("[dbo].[Tickets_Editoriales]", new string[] { "@Accion:EDIT_TICKET" });
            List<TicketsEditorialesViewModel> listMaestroAreas = MaestroAreas.AsEnumerable().Select(x => new TicketsEditorialesViewModel
            {
                Area = Convert.IsDBNull(x["Nombre"]) ? "" : (string)x["Nombre"]

            }).ToList();

            return Json(listMaestroAreas, JsonRequestBehavior.AllowGet);



        }


        public JsonResult Actualizar()
        {

            SqlData spSql = new SqlData();

            // 

            DataTable MaestroAreas = spSql.spGetData("[dbo].[Tickets_Editoriales]", new string[] { "@Accion:UPDATE_TICKET" });
            List<TicketsEditorialesViewModel> listMaestroAreas = MaestroAreas.AsEnumerable().Select(x => new TicketsEditorialesViewModel
            {
                Area = Convert.IsDBNull(x["Nombre"]) ? "" : (string)x["Nombre"]

            }).ToList();

            return Json(listMaestroAreas, JsonRequestBehavior.AllowGet);



        }

















    }




















}
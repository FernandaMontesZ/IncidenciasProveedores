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

        //Leer 



        public JsonResult GetDataTickets()
        {

            SqlData spSql = new SqlData();
            DataTable TicketsEditoriales = spSql.spGetData("[dbo].[Tickets_Editoriales]", new string[] { "@Accion:READ_Ticket"});
            List<TicketsEditorialesViewModel> listTicketsEditoriales = TicketsEditoriales.AsEnumerable().Select(x => new TicketsEditorialesViewModel
            {
                OrdenId = Convert.IsDBNull(x["OrdenId"]) ? 0 : (int)x["OrdenId"]
                ,FolioTicket = Convert.IsDBNull(x["FolioTicket"]) ? "" : (string)x["FolioTicket"]
                ,DescripcionIncidencia = Convert.IsDBNull(x["DescripcionIncidencia"]) ? "" : (string)x["DescripcionIncidencia"]
                ,PrioridadTicket = Convert.IsDBNull(x["PrioridadIncidencia"]) ? "" : (string)x["PrioridadIncidencia"]
                ,FechaCreacion = Convert.IsDBNull(x["FechaCreacion"]) ? "" : (string)x["FechaCreacion"]
                ,NombreResponsable = Convert.IsDBNull(x["NombreResponsable"]) ? "" : (string)x["NombreResponsable"]
                ,Area = Convert.IsDBNull(x["Area"]) ? "" : (string)x["Area"]
                ,Editorial = Convert.IsDBNull(x["Editorial"]) ? "" : (string)x["Editorial"]
                ,CerrarTicketNegativo = Convert.ToBoolean(x["CerrarTicketNegativo"])
                ,CerrarTicketPositivo = Convert.ToBoolean(x["CerrarTicketPositivo"])
                ,TiempoRespuestaHoras = Convert.IsDBNull(x["TiempoRespuestaHoras"]) ? "" : (string)x["TiempoRespuestaHoras"]
                ,Observaciones = Convert.IsDBNull(x["Observaciones"]) ? "" : (string)x["Observaciones"]

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
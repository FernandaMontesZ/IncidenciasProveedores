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


        public JsonResult GetDataTickets()
        {

            SqlData spSql = new SqlData();
            DataTable TicketsEditoriales = spSql.spGetData("[dbo].[Tickets_Editoriales]", new string[] { "@Accion:READ_Ticket"});
            List<TicketsEditorialesViewModel> listTicketsEditoriales = TicketsEditoriales.AsEnumerable().Select(x => new TicketsEditorialesViewModel
            {
                OrdenId = Convert.IsDBNull(x["OrdenId"]) ? 0 : (int)x["OrdenId"]
                ,NombreTicket = Convert.IsDBNull(x["NombreTicket"]) ? "" : (string)x["NombreTicket"]
                ,DescripcionIncidencia = Convert.IsDBNull(x["DescripcionIncidencia"]) ? "" : (string)x["DescripcionIncidencia"]
                ,NivelIncidencia = Convert.IsDBNull(x["NivelIncidencia"]) ? "" : (string)x["NivelIncidencia"]
                ,FechaCreacion = Convert.IsDBNull(x["FechaCreacion"]) ? "" : (string)x["FechaCreacion"]
                ,NombreResponsable = Convert.IsDBNull(x["NombreResponsable"]) ? "" : (string)x["NombreResponsable"]
                ,Email = Convert.IsDBNull(x["Email"]) ? "" : (string)x["Email"]
                ,Area = Convert.IsDBNull(x["Area"]) ? "" : (string)x["Area"]
                ,Editorial = Convert.IsDBNull(x["Editorial"]) ? "" : (string)x["Editorial"]
                ,CerrarTicketNegativo = Convert.ToBoolean(x["CerrarTicketNegativo"])
                ,CerrarTicketPositivo = Convert.ToBoolean(x["CerrarTicketPositivo"])
                ,Observaciones = Convert.IsDBNull(x["Observaciones"]) ? "" : (string)x["Observaciones"]

            }).ToList();


            return Json(listTicketsEditoriales, JsonRequestBehavior.AllowGet);
        }
    }
}
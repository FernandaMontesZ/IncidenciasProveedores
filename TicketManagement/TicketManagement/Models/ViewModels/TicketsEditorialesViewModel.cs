using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketManagement.Models.ViewModels
{
    public class TicketsEditorialesViewModel
    {
        public int OrdenId { get; set; }
        public int idEditoriales { get; set; }
        public int IdPrioridad { get; set; }
        public string FolioTicket { get; set; }
        public int IdTickets { get; set; }
        public string DescripcionIncidencia { get; set; }
        public string PrioridadTicket { get; set; }
        public string FechaCreacion { get; set; }
        public string CreadoPor { get; set; }
        public string Area { get; set; }
        public string EntidadTicket { get; set; }
        public bool CerrarTicketNegativo { get; set; }
        public bool CerrarTicketPositivo { get; set; }
        public bool IsTicketCancelled { get; set; }
        public string Observaciones { get; set; }
        public string TiempoRespuestaHoras { get; set; }
    }

    public class TicketIncidenciasViewModel
    {
        //public string NumTicket { get; set; }
       // public int IncidenciaId { get; set; }
        public string Incidencia { get; set; }
        public string Area { get; set; }
        public string ResponsableArea { get; set; }
        //public string FechaComentario { get; set; }
        public string Observaciones { get; set; }
        //public string Arhivo { get; set; }

    }

}
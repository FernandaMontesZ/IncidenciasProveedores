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
        public string NombreResponsable { get; set; }
        public string Area { get; set; }
        public string Editorial { get; set; }
        public bool CerrarTicketNegativo { get; set; }
        public bool CerrarTicketPositivo { get; set; }
        public string Observaciones { get; set; }
        public string TiempoRespuestaHoras { get; set; }
    }
}
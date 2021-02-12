using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketManagement.Models.ViewModels
{
    public class TicketsEditorialesViewModel
    {
        public int id { get; set; }
        public int idEditoriales { get; set; }
        public int IdPrioridad { get; set; }
        public string FolioTicket { get; set; }
        public int IdTickets { get; set; }
        public string DescripcionIncidencia { get; set; }
        public string Maestro_Orden_PrioridadId { get; set; }
        public string Updated_At { get; set; }
        public string UserId { get; set; }
        public string Nombre_Area { get; set; }
        public string Maestro_EditorialesId { get; set; }
        public bool IsClosed { get; set; }
        public bool IsClosed_Successfully { get; set; }
        public bool isticket_cancelled { get; set; }
        public string Observaciones { get; set; }
        public double TiempoEstimadoRespuesta { get; set; }
        public double TiempoRealRespuesta { get; set; }
        public string Rol_Usuario { get; set; }
        public bool IsReadyForWork { get; set; }
        public string IsClosed_Timestamp { get; set; }
    }

    

}
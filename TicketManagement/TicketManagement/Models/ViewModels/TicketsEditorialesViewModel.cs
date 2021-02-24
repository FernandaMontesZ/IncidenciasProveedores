﻿using System;
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
        public string Descripcion { get; set; }
        public int NumImagenesDescp { get; set; }
        public string Dictamen { get; set; }
        public int NumImagenesDictamen { get; set; }
        public string IsClosed_UserId { get; set; }
        public string IsClosed_Successfully_UserId { get; set; }
        public string IsClosed_Successfully_Timestamp { get; set; }
        public string TipoUserName { get; set; }
        public string TipoUserId { get; set; }
        public string IncidenciaNombre { get; set; }
        public int IdIncidencia { get; set; }
        public string Area { get; set; }
        public int IdArea { get; set; }
        public string NombreResponsable { get; set; }
        public string ResponsableNombre { get; set; }
        public string IdResponsable { get; set; }
    }

    

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketManagement.Models.ViewModels
{
    public class TicketIncidenciasViewModel
    {
        //public string NumTicket { get; set; }
        public int IdIncidencia { get; set; }
        public string Incidencia { get; set; }
        public string Area { get; set; }
        public string ResponsableArea { get; set; }
        public int NumImagenes { get; set; }
        public string Observaciones { get; set; }

    }
    public class TicketIncidenciasImgViewModel
    {
        public string Imagen { get; set; }
    }
    public class TicketIncidenciasImgData
    {
        public string ImagePathsDounload { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------


namespace TicketManagement.Models
{

using System;
    using System.Collections.Generic;
    
public partial class Maestro_Orden
{

    public int id { get; set; }

    public string Nombre { get; set; }

    public Nullable<int> Maestro_EditorialesId { get; set; }

    public string UserId { get; set; }

    public Nullable<System.DateTime> Updated_At { get; set; }

    public Nullable<bool> IsReadyForWork { get; set; }

    public Nullable<bool> IsClosed { get; set; }

    public Nullable<bool> IsClosed_Successfully { get; set; }

}

}

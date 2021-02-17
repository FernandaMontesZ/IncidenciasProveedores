using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace TicketManagement.Reports.Global
{

    public partial class Maestro_Incidencias_OrdenDictamenClosed
    {
        public Maestro_Incidencias_OrdenDictamenClosed(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}

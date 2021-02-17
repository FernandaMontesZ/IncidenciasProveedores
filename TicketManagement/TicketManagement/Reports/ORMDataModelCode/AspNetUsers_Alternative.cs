using System;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.Data.Filtering;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
namespace TicketManagement.Reports.Global
{

    public partial class AspNetUsers_Alternative
    {
        public AspNetUsers_Alternative(Session session) : base(session) { }
        public override void AfterConstruction() { base.AfterConstruction(); }
    }

}

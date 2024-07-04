using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MetierSharedMemoty.Model
{
    using System;
    using System.Collections.Generic;

    public partial class Td_Erreur
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> DateErreur { get; set; }
        public string DescriptionErreur { get; set; }
        public string TitreErreur { get; set; }
    }
}

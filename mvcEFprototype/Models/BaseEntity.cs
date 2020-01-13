using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcEFprototype.Models
{
    /******Track/Audit created and modified fields in EF code first*******/
    public class BaseEntity
    {
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AMWService.Models
{
    public class CreateSO
    {
        [Key]
        public int ServiceOrder { get; set; }
        public int CustommerID { get; set; }
        public int StatusID { get; set; }
        public int Priority { get; set; }

        public int TypeID { get; set; }
        public int RootCauseID { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Problem { get; set; }
        public DateTime ProblemDate { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Description { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        public string ImageName { get; set; }

        
        public int CreateBy { get; set; }
        public DateTime CreateTime { get; set; }
    }
}

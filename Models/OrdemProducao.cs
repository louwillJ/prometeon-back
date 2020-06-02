using System;
using System.ComponentModel.DataAnnotations;

namespace prometeon_back.Models {
    public class OrdemProducao {
        [Key]
        public long ORD_ID { get; set; }
        /*
                [Display(Name = "Data de Criação")]
                [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
                public DateTime? ORD_DATE_CREATION { get; set; } */

        public DateTime? ORD_DATE_CREATION { get; set; }
        public long ORD_QUANTITY { get; set; }
        public long STA_ID { get; set; }
        public long ORG_ID { get; set; }
        public DateTime? ORD_DATE_PLANNED { get; set; }
        public long BOM_ID { get; set; }
        public bool ORD_ACTIVE { get; set; }

    }
}
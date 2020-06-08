using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prometeon_back.Models {
    public class TurnoException {
        [Key]
        public long EXC_ID { get; set; }

        public bool EXC_REST { get; set; }
        public bool EXC_NOT_STANDARD { get; set; }
        public DateTime EXC_BEGIN { get; set; }
        public DateTime EXC_END { get; set; }
        public string EXC_REASON { get; set; }
        public long TUR_ID { get; set; }

        [ForeignKey ("TUR_ID")]
        public Turno Turno { get; set; }
    }
}
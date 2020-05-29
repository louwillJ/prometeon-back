using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace prometeon_new.Models {
    public class Turno {
        [Key]
        public long TUR_ID { get; set; }
        public string TUR_NAME { get; set; }
        public string TUR_BEGIN { get; set; }
        public string TUR_END { get; set; }
        public string TUR_INTERVAL_BEGIN { get; set; }
        public string TUR_INTERVAL_END { get; set; }
        public string TUR_VALIDATE_BEGIN { get; set; }
        public string TUR_VALIDATE_END { get; set; }
        public int TUR_ACTIVE { get; set; }
        // public ICollection<TurnoException> TurnoException { get; set; }
    }


}
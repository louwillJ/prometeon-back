using System.ComponentModel.DataAnnotations;

namespace prometeon_new.Models
{
    public class TurnoException
    {
        [Key]
        public long EXC_ID {get; set;}
        public int EXC_REST {get; set;}
        public int EXC_NOT_STANDARD {get; set;}
        public string EXC_BEGIN {get; set;}
        public string EXC_END {get; set;}
        public string EXC_REASON {get; set;}
        public long TUR_ID {get; set;}
    }
}
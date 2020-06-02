using System.ComponentModel.DataAnnotations;

namespace prometeon_back.Models {
    public class OrdemStatus {
        [Key]
        public long STA_ID { get; set; }
        public string STA_NOME { get; set; }
        public string STA_DESCRICAO { get; set; }

    }
}
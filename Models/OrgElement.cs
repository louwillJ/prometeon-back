using System.ComponentModel.DataAnnotations;

namespace prometeon_back.Models {
    public class OrgElement {
        [Key]
        public long ELE_ID { get; set; }
        public string ELE_NAME { get; set; }
        public bool ELE_ACTIVE { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace prometeon_back.Models {
    public class UserAccessLevel {
        [Key]
        public long LEV_ID { get; set; }
        public string LEV_NAME { get; set; }
        public bool LEV_ACTIVE { get; set; }
    }
}
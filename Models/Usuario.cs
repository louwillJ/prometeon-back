using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prometeon_back.Models {
    public class Usuario {
        [Key]
        public long USR_ID { get; set; }
        public string USR_EMAIL { get; set; }
        public string USR_NAME { get; set; }
        public string USR_SENHA { get; set; }
        public bool USR_ACTIVE { get; set; }
        public long USR_ACCESS_LEVEL { get; set; }

        [ForeignKey ("LEV_ID")]
        public UserAccessLevel UserAccessLevel { get; set; }
    }
}
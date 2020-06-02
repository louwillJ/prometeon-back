using System.ComponentModel.DataAnnotations;

namespace prometeon_back.Models {
    public class Usuario {

        // [Key]
        // public int id { get; set; }

        // [Required (ErrorMessage = "Este campo é obrigatório")]
        // [MaxLength (50)]
        // public string nome { get; set; }

        // [Required (ErrorMessage = "Este campo é obrigatório")]
        // [MaxLength (20)]
        // public string user { get; set; }

        // [Required (ErrorMessage = "Este campo é obrigatório")]
        // [MaxLength (8, ErrorMessage = "A senha deve conter entre 4 e 8 caracteres")]
        // [MinLength (4, ErrorMessage = "A senha deve conter entre 4 e 8 caracteres")]
        // public string senha { get; set; }

        // [Required (ErrorMessage = "Este campo é obrigatório")]
        // [MaxLength (50)]
        // public string acesso { get; set; }


        //db_spi073
        [Key]
        public long USR_ID { get; set; }
        public string USR_EMAIL { get; set; }
        public string USR_NAME { get; set; }
        public string USR_SENHA { get; set; }
        public bool USR_ACTIVE { get; set; }
        public long USR_ACCESS_LEVEL { get; set; }
    }
}
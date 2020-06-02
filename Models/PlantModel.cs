using System.ComponentModel.DataAnnotations;

namespace prometeon_back.Models {
    public class PlantModel {
        [Key]
        public long ORG_ID { get; set; }
        public long ELE_ID { get; set; }
        public long ORG_ID_ITEM_UP { get; set; }
        public int ORG_ACTIVE { get; set; }
        public string ORG_NAME { get; set; }
        public string ORG_DESCRIPTION { get; set; }
    }
}
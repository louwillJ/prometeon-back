using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace prometeon_back.Models {
    public class PlantModel {
        [Key]
        public long ORG_ID { get; set; }
        public string ORG_NAME { get; set; }
        public long ORG_ID_ITEM_UP { get; set; }
        public bool ORG_ACTIVE { get; set; }
        public string ORG_DESCRIPTION { get; set; }
        public long ELE_ID { get; set; }

        [ForeignKey ("ORG_ID_ITEM_UP")]
        public PlantModel ItemUp { get; set; }
    }
    public class ItemUp {
        [Key]
        public long ORG_ID { get; set; }
        public string ORG_NAME { get; set; }
        public long ORG_ID_ITEM_UP { get; set; }
        public bool ORG_ACTIVE { get; set; }
        public string ORG_DESCRIPTION { get; set; }
        public long ELE_ID { get; set; }
    }
}
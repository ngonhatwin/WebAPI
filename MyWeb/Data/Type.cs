using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWeb.Data
{
    //loại trái cây, quần áo, ...
    [Table("Type")]
    public class Type
    {
        private int type_id_;
        private string type_Name_;
        //public virtual ICollection<Product> list_products_ { get; set; }
        public Type()
        {
            type_id_ = 0;
            type_Name_ = string.Empty;
        }

        [Key]
        public int TypeID
        {
            set { type_id_ = value; }
            get { return type_id_; }
        }

        [Required]
        [MaxLength(100)]
        public string TypeName
        {
            set { type_Name_ = value; }
            get { return type_Name_; }
        }
    }

}

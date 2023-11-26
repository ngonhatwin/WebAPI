using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//Dinh nghia Entities
namespace MyWeb.Data
{
    //annotations
    [Table("Product")]
    public class Product
    {
        private Guid id_;
        private string name_;
        private string describe_;
        //giá gốc vừa nhập
        private double price_;
        //cũng vậy
        private byte discount_;
        private int? type_ID_;
        private ICollection<OrderDetails> list_details_;
        public Product()
        {
            id_ = Guid.NewGuid();
            name_ = string.Empty;
            describe_ = string.Empty;
            price_ = 0;
            discount_ = 0;
            type_ID_ = null;
            list_details_ = new List<OrderDetails>();
        }

        [Key]
        public Guid ID
        {
            set { id_ = value; }
            get { return id_; }
        }

        [Required]
        [MaxLength(100)]
        public string Name
        {
            set { name_ = value; }
            get { return name_; }
        }
        public string Describe
        {
            set { describe_ = value; }
            get { return describe_; }
        }

        [Range(0, double.MaxValue)]
        public double Price
        {
            set { price_ = value; }
            get { return price_; }
        }

        public byte Discount
        {
            set { discount_ = value; }
            get { return discount_; }
        }

        //TypeID là khóa ngoại, có thể null
        public int? TypeID
        {
            set { type_ID_ = value; }
            get { return type_ID_; }
        }

        //gọi kiểu Type và lấy các kiểu hàng khác
        [ForeignKey("TypeID")]
        public Type Type
        {
             set; get; 
        }

        public ICollection<OrderDetails> ListOrderDetail
        {
            set { list_details_ = value; }
            get { return list_details_; }
        }
    }

}

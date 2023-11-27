namespace MyWeb.Models
{
    public class Product
    {
        private string name_;
        private double price_;
        private string describe_;
        private byte discount_;
        public Product ()
        {
            name_ = string.Empty;
            price_ = 0;
            describe_ = string.Empty;
            discount_ = 0;
        }
        public string Name
        {
            set { name_ = value; }
            get { return name_; }
        }
        public double Price
        {
            set { price_ = value; }
            get { return price_; }
        }  
        public string Describe
        {
            set { describe_ = value; }
            get { return describe_; }
        }

        public byte Discount
        {
            set { discount_ = value; }
            get { return discount_; }
        }
    }
}

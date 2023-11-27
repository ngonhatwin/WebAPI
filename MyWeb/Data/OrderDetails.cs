namespace MyWeb.Data
{
    //chi tiết đơn hàng 
    //một chi tiết đơn hàng chỉ có 1 sản phẩm
    //mà một đơn hàng lại có nhiều chi tiết đơn hàng(=> là có nhiều sản phẩm)
    public class OrderDetails
    {
        private Guid id_Details_;
        private Guid id_Product_;
        private int quantity_Pur_;
        //giá bán đã tính thuế
        private double price_;
        private Order myorder_;
        private Product myproduct_;
        
        public OrderDetails ()
        {
            id_Details_ = Guid.NewGuid ();
            id_Product_ = Guid.NewGuid ();
            quantity_Pur_ = 0;
            price_ = 0;
            myorder_ = new Order ();
            myproduct_ = new Product ();
           
        }
        public Guid IDDetails
        {
            set { id_Details_ = value; }
            get { return id_Details_; }
        }

        public Guid IDProduct
        {
            set { id_Product_ = value; }
            get { return id_Product_; }
        }

        public int QuantityPur
        {
            set { quantity_Pur_ = value;}
            get { return quantity_Pur_; }
        }

        public double Price
        {
            set { price_ = value;}
            get { return price_; }
        }

        //relationship
        public Order MyOrder
        {
            set { myorder_ = value; }
            get { return myorder_; }
        }

        public Product MyProduct
        {
            set { myproduct_ = value; }
            get { return myproduct_; }
        }  
    }
}

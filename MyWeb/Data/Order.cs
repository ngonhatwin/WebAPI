 namespace MyWeb.Data
{

    // Entities Đơn Hàng
    public class Order
    {
        public enum Status
        {
            New = 0,
            Payment = 1,
            Complete = 2,
            Cancel = -1,
        }
        
        private Guid id_;
        private DateTime order_Date_;
        private DateTime? delivery_Date_;
        private Status status_;
        private string name_;
        private string address_;
        private string telephone_;
        private ICollection<OrderDetails> list_Orders_;
        public Order()
        {
            id_ = Guid.NewGuid();
            order_Date_ = DateTime.Now;
            delivery_Date_ = DateTime.Now;
            status_ = Status.New;
            name_ = string.Empty;
            address_ = string.Empty;
            telephone_ = string.Empty;
            list_Orders_ = new List<OrderDetails>();
        }

        public Guid ID
        {
            set { id_ = value; }
            get { return id_; }
        }

        public DateTime OrderDate
        {
            set { order_Date_ = value; }
            get { return order_Date_; }
        }

        public DateTime? DeliveryDate
        {
            set { delivery_Date_ = value;}
            get { return delivery_Date_; }
        }
        public Status StatusOrder
        {
            set { status_ = value; }
            get { return status_; }
        }
        public string Name
        {
            set { name_ = value; }
            get { return name_; }
        }
        public string Address
        {
            set { address_ = value; }
            get { return address_; }
        }

        public string Telephone
        {
            set { telephone_ = value; }
            get { return telephone_; }
        }

        //
        public ICollection<OrderDetails> order_Detail
        {
            set { list_Orders_ = value; }
            get { return list_Orders_; }
        }
    }
}

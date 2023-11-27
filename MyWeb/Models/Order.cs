namespace MyWeb.Models
{
    public class Order
    {
        private Guid id_;
        private Guid id_Customer_;
        private Guid id_Emloyee_;
        private DateTime order_Date_;
        private DateTime delivery_Date_;
        private DateTime shipment_Date_;
        private string date_of_delivery_;

        public Order()
        {
            id_Customer_ = Guid.NewGuid();
            id_Emloyee_ = Guid.NewGuid();
            order_Date_ = DateTime.Now;
            delivery_Date_ = DateTime.Now;
            shipment_Date_ = DateTime.Now;
            date_of_delivery_ = string.Empty;
        }


    }
}

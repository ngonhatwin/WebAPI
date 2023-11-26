namespace MyWeb.Models
{
    public class Account
    {
        
        private string firstname_;
        private string lastname_;
        private string email_;
        private string password_;

        public Account()
        {
            firstname_ = string.Empty;
            lastname_ = string.Empty;
            email_ = string.Empty;
            password_ = string.Empty;
           
        }
        
        public string FirstName
        {
            set { firstname_ = value; }
            get { return firstname_; }
        } 

        public string LastName
        {
            set { lastname_ = value; }
            get { return lastname_; }
        }

        public string Email
        {
            set { email_ = value; }
            get { return email_; }
        }

        public string PassWord
        {
            set { password_ = value; }
            get { return password_; }
        }
    }
}

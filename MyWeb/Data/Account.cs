using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWeb.Data
{

    [Table("Account")]
    public class Account
    {
       
        private Guid id_;
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
            id_ = Guid.NewGuid();
        }

        [Key]
        public Guid ID
        {
            set { id_ = value; }
            get { return id_; }
        }
        [Required]
        [MaxLength(20)]
        public string FirstName
        {
            set { firstname_ = value; }
            get { return firstname_; }
        }

        [Required]
        [MaxLength(20)]
        public string LastName
        {
            set { lastname_ = value; }
            get { return lastname_; }
        }

        [Required]
        [MaxLength(20)]
        public string Email
        {
            set { email_ = value; }
            get { return email_; }
        }

        [Required]
        [MaxLength(20)]
        public string PassWord
        {
            set { password_ = value; }
            get { return password_; }
        }
    }

}


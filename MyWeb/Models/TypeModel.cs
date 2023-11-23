using System.ComponentModel.DataAnnotations;

namespace MyWeb.Models
{
    
    public class TypeModel
    {
        
        private string name_;

        
        public TypeModel() 
        {
            name_ = string.Empty;
        }

        [Required]
        [MaxLength(100)]
        public string Name 
        { 
            set { name_ = value; }
            get { return name_; }
        }

    }
}

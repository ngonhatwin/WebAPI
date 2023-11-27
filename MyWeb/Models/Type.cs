using System.ComponentModel.DataAnnotations;

namespace MyWeb.Models
{
    
    public class Type
    {
        
        private string name_;

        
        public Type() 
        {
            name_ = string.Empty;
        }

       
        public string Name 
        { 
            set { name_ = value; }
            get { return name_; }
        }

    }
}

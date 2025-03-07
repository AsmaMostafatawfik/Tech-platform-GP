using System.ComponentModel.DataAnnotations;

namespace E_commerce_platform.ViewModels
{
    public class VerifyEmailViewModel
    {
        
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress]
        public string Email { get; set; }
    }

  
    }


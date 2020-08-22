using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DocumentQuicker.Api.Models
{
    public sealed class ShortBankInfoDto
    {
        [Required]
        [Description("Bank description. Includes name and city, etc.")]
        [StringLength(maximumLength: 200, MinimumLength = 6)]
        public string Description { get; set; }
        
        [Required]
        [Description("Bank correspondent account")]
        [StringLength(maximumLength: 200, MinimumLength = 6)]
        public string CorrAccount { get; set; }
        
        [Required]
        [Description("Russian Central Bank identifiaction number")]
        [StringLength(maximumLength: 200, MinimumLength = 6)]
        public string Bic { get; set; }
    }
}
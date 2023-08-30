using System.ComponentModel.DataAnnotations;

namespace eCommerceSite.Models
{
    /// <summary>
    /// Member created by registration used to
    /// login
    /// </summary>
    public class Member
    {
        /// <summary>
        /// The ID of the member
        /// </summary>
        [Key]
        public int MemberId { get; set; }

        /// <summary>
        /// Member's provided email
        /// </summary>
        public string Email { get; set; } = null!;

        /// <summary>
        /// Member's created password
        /// </summary>
        public string Password { get; set; } = null!;

        /// <summary>
        /// Member's given phone number
        /// </summary>
        public string? Phone { get; set; }

        /// <summary>
        /// Member's selected username
        /// </summary>
        public string? Username { get; set; }
    }

    /// <summary>
    /// ViewModel used to create a new member
    /// </summary>
    public class RegisterViewModel
    {
        /// <summary>
        /// User's email
        /// </summary>
        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        /// <summary>
        /// Email confirmation
        /// </summary>
        [Required]
        [Compare(nameof (Email))]
        [Display(Name = "Confirm Email")]
        public string ConfirmEmail { get; set; }

        /// <summary>
        /// User's selected password
        /// </summary>
        [Required]
        [StringLength(75, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        /// <summary>
        /// Password confirmation
        /// </summary>
        [Required]
        [Compare(nameof (Password))]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }

    /// <summary>
    /// ViewModel for loggin in
    /// </summary>
    public class LoginViewModel
    {
        /// <summary>
        /// Inputted email
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        /// <summary>
        /// Inputted password
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}

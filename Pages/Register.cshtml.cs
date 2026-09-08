
using BCrypt.Net;
using E_commerce.Data;
using E_commerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace E_commerce.Pages.Shared
{
    public class RegisterModel : PageModel
    {
        private readonly EcommerceDbContext _context;

        public RegisterModel(EcommerceDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; } = new();

        public class InputModel
        {
            [Required(ErrorMessage = "Username is required.")]
            [StringLength(50, ErrorMessage = "Username cannot exceed 50 characters.")]
            public string Username { get; set; } = "";

            [Required(ErrorMessage = "Email is required.")]
            [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
            public string Email { get; set; } = "";

            [Required(ErrorMessage = "Password is required.")]
            [DataType(DataType.Password)]
            [MinLength(6, ErrorMessage = "The password must be at least 6 characters long.")]
            public string Password { get; set; } = "";
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Clean up the input
            string username = Input.Username.Trim();
            string email = Input.Email.Trim().ToLowerInvariant();

            // Check if username already exists
            if (_context.Users.Any(u => u.Username == username))
            {
                ModelState.AddModelError(
                    "Input.Username",
                    "Username already exists."
                );

                return Page();
            }

            // Check if email already exists
            if (_context.Users.Any(u => u.Email.ToLower() == email))
            {
                ModelState.AddModelError(
                    "Input.Email",
                    "Email already exists."
                );

                return Page();
            }

            // Hash the password
            string hashedPassword =
                BCrypt.Net.BCrypt.HashPassword(Input.Password);

            // Create the user
            var user = new User
            {
                Username = username,
                Email = email,

              
                PasswordHash = hashedPassword
            };

            // Save the user
            _context.Users.Add(user);
            _context.SaveChanges();

            // Show message on Login page
            TempData["SuccessMessage"] =
                "Account created successfully. You can now log in.";

            return RedirectToPage("/Login");
        }
    }
}


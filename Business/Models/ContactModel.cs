
using System.ComponentModel.DataAnnotations;

namespace Business.Models;

public class ContactModel
{
    public string Id { get; set; } = null!;

    [Required(ErrorMessage = "Firstname is required.")] 
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "Lastname is required.")]
    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = "Email is required.")]
    [EmailAddress(ErrorMessage = "Invalid email format.")] 
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Phone number is required.")]
    [Phone(ErrorMessage = "Invalid phone number format.")]
    public string Phone { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string City { get; set; } = null!;
    public string FullName => $"{FirstName} {LastName}";



}

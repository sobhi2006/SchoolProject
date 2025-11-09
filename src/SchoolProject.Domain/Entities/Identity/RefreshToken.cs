using System.ComponentModel.DataAnnotations;

namespace SchoolProject.Domain.Entities.Identity;

public class UserRefreshToken
{
    public Guid Id { get; set; }
    public string AccessToken { get; set; } = null!;
    public string RefreshToken { get; set; } = null!;
    public DateTime ExpiryDate{ get; set; }
    public DateTime CreateAt { get; set; }
    public User? User { get; set; }
    public string UserId { get; set; } = null!;
}
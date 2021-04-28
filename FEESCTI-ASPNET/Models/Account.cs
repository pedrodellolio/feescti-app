using System.ComponentModel.DataAnnotations;

namespace FEESCTI_ASPNET.Models
{
  public class Account
  {
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Esse usuário não existe")]
    public string Username { get; set; }
    [Required(ErrorMessage = "A senha ou o nome de usuário estão incorretos")]
    public string Password { get; set; }

    
  }
}

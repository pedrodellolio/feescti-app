using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace FEESCTI_ASPNET.Models
{
  public class Inscricao
  {
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    [StringLength(40, MinimumLength = 1)]
    public string Nome { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    [StringLength(11, MinimumLength = 11)]
    public string CPF { get; set; }

    [Required(ErrorMessage = "Campo obrigatório")]
    [DisplayName("Data de Nascimento")]
    public DateTime DataNascimento { get; set; }
    public string Status { get; set; }
    public string MotivoStatusNegado { get; set; }

    public Inscricao()
    {
      Status = "Pendente";
    }

  }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mf_dev_backend_2023.Models
{
    [Table("Cadastro")]
    public class Cadastro
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nome do Cliente")]
        [Required(ErrorMessage = "Obrigatório informar o nome do cliente.")]
        public string NomeCliente { get; set; }

        [Display(Name = "Email do Cliente")]
        [Required(ErrorMessage = "Obrigatório informar o email do cliente.")]
        public string EmailCliente { get; set; }

        [Display(Name = "Plano Adquirido")]
        [Required(ErrorMessage = "Obrigatório informar o plano adquirido pelo cliente.")]
        public string PlanoAdquirido { get; set; }
    }
}

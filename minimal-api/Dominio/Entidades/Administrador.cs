using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinimalApi.Dominio.Entidades;

class Administrador
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public string Id { get; set; } = default!;

    [Required]
    [StringLength(255)]
    public string Email { get; set; } = default!;

    [StringLength(50)]
    public string Senha { get; set; } = default!;

    [StringLength(10)]
    public string Perfil { get; set; } = default!;
}
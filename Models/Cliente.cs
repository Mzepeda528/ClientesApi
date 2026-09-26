using System.ComponentModel.DataAnnotations;

namespace ClientesApi.Models
{
    public class Cliente
    {
        [Key]
        public int Id_cliente { get; set; }

        [Required]
        [MaxLength(20)]
        public string CUI { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string NIT { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Nombres { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Apellidos { get; set; } = string.Empty;

        [MaxLength(200)]
        public string Direccion { get; set; } = string.Empty;

        [MaxLength(20)]
        public string Telefono { get; set; } = string.Empty;

        public DateTime Fecha_Nacimiento { get; set; }
    }
}

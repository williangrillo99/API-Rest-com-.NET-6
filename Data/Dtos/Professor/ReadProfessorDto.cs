using System.ComponentModel.DataAnnotations;

namespace ProjetoCEC_Agenda.Data.Dtos.Professor
{
    public class ReadProfessorDto
    {

        [Key] //Definindo o Id como chave primaria
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatorio")] //Definindo como obrigatorio
        public string Nome { get; set; } 


        [Required(ErrorMessage = "O campo email é obrigatorio")]
        [StringLength(30, ErrorMessage = "O campo Email não pode passar de 30 caracter")]
        public string Email { get; set; }

        public DateTime HoraDaConsulta{get;set;}
           
    }
}
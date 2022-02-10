using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProjetoCEC_Agenda.Data;
using ProjetoCEC_Agenda.Data.Dtos;
using ProjetoCEC_Agenda.Data.Dtos.Professor;
using ProjetoCEC_Agenda.Models;
namespace ProjetoCEC_Agenda.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfessorController : ControllerBase // => localhost/professor 
    {           
        private  AppDbContext _context; //_context seria o nome para iniciarla
        private IMapper _mapper;
        public ProfessorController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        
        [HttpPost]
        public IActionResult AdicionarProfessor([FromBody]CreateProfessorDto professorDto)
        {
            Professor professor = _mapper.Map<Professor>(professorDto);
           

            _context.Professores.Add(professor); //Para adicionar as informações
            _context.SaveChanges(); //Para salvar as informações
            return CreatedAtAction(nameof(RetornarProfessorporId), new {Id = professor.Id}, professor); //Mostrar a localização ---No postman da pra ver na header
        }


       [HttpGet]
        public IEnumerable<Professor> RetornarProfessor()
        {
            return _context.Professores; 
            //Não retornar um notFound e sim um Ok pois a rota esta certa, porem, não tem conteudo
    
        }

        
        
        [HttpGet("{id}")] //Recebendo um parametro  pela rota
        public IActionResult RetornarProfessorporId(int id)
        {
            Professor professor = _context.Professores.FirstOrDefault(professor => professor.Id == id);
            if(professor != null)
            {
                ReadProfessorDto professorDto = _mapper.Map<ReadProfessorDto>(professor);
                return Ok(professorDto);
            }
            return NotFound();  //Não retorna caso o professor não foi encontrado
        }
        
        
        [HttpPut("{id}")]
        public IActionResult AtualizarProfessor(int id, [FromBody] UpdateProfessorDto professorDto)
        {
            Professor professor = _context.Professores.FirstOrDefault(professor => professor.Id == id);
            if(professor == null)
            {
                return NotFound(); //Não retorna caso o professor não foi encontrado
            }
            _mapper.Map(professorDto, professor);
            _context.SaveChanges();
            return NoContent(); //Não tem retorno
        
        }   


        [HttpDelete("{id}")]
        public IActionResult DeletarProfessor(int id)
        {
            Professor professor = _context.Professores.FirstOrDefault(professor => professor.Id == id);
            if(professor == null)
            {
                return NotFound();
            }
            _context.Remove(professor);
            _context.SaveChanges();
            return NoContent(); //Não tem retorno
        }
    }
}
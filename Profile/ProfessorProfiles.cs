using AutoMapper;
using ProjetoCEC_Agenda.Data.Dtos;
using ProjetoCEC_Agenda.Data.Dtos.Professor;
using ProjetoCEC_Agenda.Models;

namespace ProjetoCEC_Agenda.Profiles
{
  public class ProfessorProfile : Profile
  {
    public ProfessorProfile()
    {
      CreateMap<CreateProfessorDto, Professor>();    
      CreateMap<Professor, ReadProfessorDto>();
      CreateMap<UpdateProfessorDto, Professor>();

    }
  }
}
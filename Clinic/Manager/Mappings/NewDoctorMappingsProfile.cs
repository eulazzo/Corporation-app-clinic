
using AutoMapper;
using ClCoreShared.ModelViews.Especialidade;
using ClCoreShared.ModelViews.Medico;
using Core.Domain;

namespace Manager.Mappings;

public class NewDoctorMappingsProfile : Profile
{
    public NewDoctorMappingsProfile()
    {
        CreateMap<NovoMedico, Medico>();
        CreateMap<Medico, MedicoView>();
        CreateMap<Especialidade, ReferenciaEspecialidade>().ReverseMap();
        CreateMap<Especialidade, EspecialidadeView>().ReverseMap();
        CreateMap<Especialidade, NovaEspecialidade>().ReverseMap();
        CreateMap<AlteraMedico, Medico>().ReverseMap();
    }
}

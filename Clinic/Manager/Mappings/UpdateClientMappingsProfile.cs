
using AutoMapper;
using ClCoreShared.ModelViews;
using ClCoreShared.ModelViews.Cliente;
using Core.Domain;

namespace Manager.Mappings;

public class UpdateClientMappingsProfile : Profile
{
    public UpdateClientMappingsProfile()
    {
        CreateMap<AlteraCliente, Client>()
            .ForMember(d => d.UltimaAtualizacao, o => o.MapFrom(x => DateTime.Now))
            .ForMember(d => d.DataNascimento, o => o.MapFrom(x =>x.DataNascimento.Date));
    }
}

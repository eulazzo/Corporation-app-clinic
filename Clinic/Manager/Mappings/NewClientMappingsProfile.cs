
using AutoMapper;
using ClCoreShared.ModelViews;
using ClCoreShared.ModelViews.Cliente;
using ClCoreShared.ModelViews.Endereco;
using ClCoreShared.ModelViews.Telefone;
using Core.Domain;

namespace Manager.Mappings;

public class NewClientMappingsProfile : Profile
{
    public NewClientMappingsProfile()
    {
        CreateMap<NovoCliente, Client>()
            .ForMember(d => d.Criacao, o => o.MapFrom(x => DateTime.Now))
            .ForMember(d => d.DataNascimento, o => o.MapFrom(x =>x.DataNascimento.Date));

        CreateMap<NovoEndereco, Endereco>(); 
        CreateMap<NovoTelefone, Telefone>();
        CreateMap<Client, ClienteView>();
        CreateMap<Endereco, EnderecoView>();
        CreateMap<Telefone, TelefoneView>();

    }
}

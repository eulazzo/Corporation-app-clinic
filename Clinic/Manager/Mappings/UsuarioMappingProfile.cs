using AutoMapper;
using ClCoreShared.ModelViews.Usuario;
using Core.Domain;

namespace Manager.Mappings;
public class UsuarioMappingProfile : Profile
{
    public UsuarioMappingProfile()
    {
        CreateMap<Usuario, UsuarioView>().ReverseMap();
        CreateMap<Usuario, NovoUsuario>().ReverseMap();
        CreateMap<Usuario, UsuarioLogado>().ReverseMap();
        CreateMap<Funcao, FuncaoView>().ReverseMap();
        CreateMap<Funcao, ReferenciaFuncao>().ReverseMap();
    }
}

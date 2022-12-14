using AutoMapper;
using bookstore.Domain.Contracts.Request;
using bookstore.Domain.Contracts.Response;
using bookstore.Domain.Entities;

namespace bookstore.api.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            #region EntityToRequest
            CreateMap<AvaliacaoRequest, Avaliacao>().ReverseMap();
            CreateMap<EnderecoRequest, Endereco>().ReverseMap();
            CreateMap<FornecedorRequest, Fornecedor>().ReverseMap();
            CreateMap<LivroRequest, Livro>().ReverseMap();
            CreateMap<PedidoRequest, Pedido>().ReverseMap();
            CreateMap<UsuarioRequest, Usuario>().ReverseMap();
            #endregion

            #region EntityToResponse
            CreateMap<AvaliacaoResponse, Avaliacao>().ReverseMap();
            CreateMap<EnderecoResponse, Endereco>().ReverseMap();
            CreateMap<FornecedorResponse, Fornecedor>().ReverseMap();
            CreateMap<LivroResponse, Livro>().ReverseMap();
            CreateMap<PedidoResponse, Pedido>().ReverseMap();
            CreateMap<UsuarioResponse, Usuario>().ReverseMap();
            #endregion
        }

    }
}

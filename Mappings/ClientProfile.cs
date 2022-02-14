using AutoMapper;
using ElasticSearchService.Entities;
using ElasticSearchService.Models;
using ElasticSearchService.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearchService.Mappings {
    public class ClientProfile : Profile {

        public ClientProfile() {
            CreateMap<ClientResultModel, Client>()
                .ForMember(dest => dest.Id, o => o.MapFrom(src => src.Id.Raw))
                .ForMember(dest => dest.DateJoined, o => o.MapFrom(src => src.DateJoined.Raw))
                .ForMember(dest => dest.DateOfBirth, o => o.MapFrom(src => src.DateOfBirth.Raw))
                .ForMember(dest => dest.FirstName, o => o.MapFrom(src => src.FirstName.Raw))
                .ForMember(dest => dest.LastName, o => o.MapFrom(src => src.LastName.Raw))
                .ForMember(dest => dest.Name, o => o.MapFrom(src => src.Name.Raw))
                .ForMember(dest => dest.ServiceType, o => o.MapFrom(src => src.ServiceType.Raw));

            CreateMap<ClientAppSearchResult, ClientSearchResponse>()
                .ForMember(dest => dest.Meta, o => o.MapFrom(src => src.Meta))
                .ForMember(dest => dest.Results, o => o.MapFrom(src => src.Results));
        }
    }
}

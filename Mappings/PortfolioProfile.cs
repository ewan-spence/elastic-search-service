using AutoMapper;
using ElasticSearchService.Entities;
using ElasticSearchService.Models;
using ElasticSearchService.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElasticSearchService.Mappings {
    public class PortfolioProfile : Profile {

        public PortfolioProfile() {

            CreateMap<PortfolioResultModel, Portfolio>()
                .ForMember(dest => dest.Id, o => o.MapFrom(src => src.Id.Raw))
                .ForMember(dest => dest.AdvisorName, o => o.MapFrom(src => src.AdvisorName.Raw))
                .ForMember(dest => dest.ClientName, o => o.MapFrom(src => src.ClientName.Raw))
                .ForMember(dest => dest.DateCreated, o => o.MapFrom(src => src.DateCreated.Raw))
                .ForMember(dest => dest.Holdings, o => o.MapFrom(src => src.Holdings.Raw));

            CreateMap<PortfolioAppSearchResult, PortfolioSearchResponse>()
                .ForMember(dest => dest.Meta, o => o.MapFrom(src => src.Meta))
                .ForMember(dest => dest.Results, o => o.MapFrom(src => src.Results));
        }
    }
}

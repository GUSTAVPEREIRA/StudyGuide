﻿using AutoMapper;
using StudyGuide.DTO.User;
using StudyGuide.Model.Users;

namespace StudyGuide.MappingDTO.UserMapping
{
    // Please continue using this default.
    // D = Destination
    // O = Origin

    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<User, UserDTO>()
                .ForMember(d => d.Id, opt => opt.MapFrom(o => o.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(o => o.Name))
                .ForMember(d => d.Username, opt => opt.MapFrom(o => o.Username))
                .ForMember(d => d.Password, opt => opt.MapFrom(o => o.Password));

            CreateMap<UserDTO, User>()
                .ForMember(d => d.Id, opt => opt.MapFrom(o => o.Id))
                .ForMember(d => d.Name, opt => opt.MapFrom(o => o.Name))
                .ForMember(d => d.Username, opt => opt.MapFrom(o => o.Username))
                .AfterMap((o, d) =>
                {
                    d.SetPassword(o.Password);
                });
        }
    }
}
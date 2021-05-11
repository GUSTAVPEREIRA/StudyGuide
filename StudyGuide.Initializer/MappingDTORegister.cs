using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using StudyGuide.MappingDTO.UserMapping;

namespace StudyGuide.Initializer
{
    public static class MappingDTORegister
    {
        public static void AddMappingDTO(this IServiceCollection service)
        {
            var mappingConfig = new MapperConfiguration(mapper =>
            {
                mapper.AddProfile<UserMapping>();
            });

            //Don't remove this line below, because it's used for register the autoMapper
            service.AddSingleton(mappingConfig.CreateMapper());
        }
    }
}

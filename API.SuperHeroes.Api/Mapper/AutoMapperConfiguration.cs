using AutoMapper;

namespace API.SuperHeroes.Api.Mapper
{
    public static class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(ps =>
            {
                ps.AddProfile(new ModelToViewModel());
                ps.AddProfile(new ViewModelToModel());
            });
        }
    }
}

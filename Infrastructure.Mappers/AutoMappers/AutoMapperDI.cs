using Application.Mappers;

namespace Infrastructure.Mappers.AutoMappers
{
    public class AutoMapperDI : IMapper
    {
        private readonly IMapper _mapper;
        public AutoMapperDI(IMapper mapper) 
        {
            _mapper = mapper;
        }
        public TDestination Map<TDestination>(object source)
        {
            return _mapper.Map<TDestination>(source);
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return _mapper.Map<TSource, TDestination>(source);
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return _mapper.Map(source, destination);
        }
    }
}

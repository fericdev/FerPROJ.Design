using AutoMapper;
using System.Collections.Generic;

namespace FerPROJ.Design.Class
{
    public class CMapping<TSource, TDestination> : Profile 
    {
        public CMapping() {
            CreateMap<TSource, TDestination>().ReverseMap();
        }
        public static MapperConfiguration GetMapperConfiguration() {
            return new MapperConfiguration(c => c.AddProfile(new CMapping<TSource, TDestination>()));
        }
        public TDestination GetMappingResult(TSource myDTO) {
            //
            var conf = GetMapperConfiguration();
            var mapper = conf.CreateMapper();
            return mapper.Map<TSource, TDestination>(myDTO);
        }
    }
    public class CMappingList<TSource, TDestination>
    {
        public List<TDestination> GetMappingResultList(ICollection<TSource> source) {
            //
            List<TDestination> resultList = new List<TDestination>();
            foreach (var item in source) {
                var itemToMapp = new CMapping<TSource, TDestination>().GetMappingResult(item);
                resultList.Add(itemToMapp);
            }
            return resultList;
        }
        public List<TDestination> GetMappingResultList(IEnumerable<TSource> source) {
            //
            List<TDestination> resultList = new List<TDestination>();
            foreach (var item in source) {
                var itemToMapp = new CMapping<TSource, TDestination>().GetMappingResult(item);
                resultList.Add(itemToMapp);
            }
            return resultList;
        }
        public List<TDestination> GetMappingResultList(List<TSource> source) {
            //
            List<TDestination> resultList = new List<TDestination>();
            foreach (var item in source) {
                var itemToMapp = new CMapping<TSource, TDestination>().GetMappingResult(item);
                resultList.Add(itemToMapp);
            }
            return resultList;
        }
    }
}

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;

namespace FerPROJ.Design.Class {
    public static class CMappingExtension {

        public static TDestination ToDestination<TDestination>(this object source) {
            if (source == null) {
                return default;
            }

            // Use reflection to create the mapping instance dynamically
            var sourceType = source.GetType();
            var mappingType = typeof(CMapping<,>).MakeGenericType(sourceType, typeof(TDestination));
            var mappingInstance = Activator.CreateInstance(mappingType);

            // Call the 'GetMappingResult' method on the mapping instance
            var getMappingResultMethod = mappingType.GetMethod("GetMappingResult");
            return (TDestination)getMappingResultMethod.Invoke(mappingInstance, new object[] { source });
        }

        public static List<TDestination> ToDestination<TDestination>(this IEnumerable<object> source) {
            if (source == null || !source.Any()) {
                return default;
            }
            var resultList = new List<TDestination>();
            foreach (var item in source) {
                var map = item.ToDestination<TDestination>();
                resultList.Add(map);
            }
            return resultList;
        }

        public static List<TDestination> ToDestination<TDestination>(this ICollection<object> source) {
            if (source == null || source.Count == 0) {
                return default;
            }
            var resultList = new List<TDestination>();
            foreach (var item in source) {
                var map = item.ToDestination<TDestination>();
                resultList.Add(map);
            }
            return resultList;
        }

    }

    public class CMapping<TSource, TDestination> : Profile {
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
    public class CMappingList<TSource, TDestination> {
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

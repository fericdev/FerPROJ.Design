using AutoMapper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;

namespace FerPROJ.Design.Class {
    public static class CMappingExtension {

        public static TDestination ToDestination<TDestination>(this object source, TDestination prevDestination = default) {
            if (source == null) {
                return prevDestination; // Return the existing instance if source is null
            }

            var sourceType = source.GetType();
            var mappingType = typeof(CMapping<,>).MakeGenericType(sourceType, typeof(TDestination));
            var mappingInstance = Activator.CreateInstance(mappingType);

            var getMappingResultMethod = mappingType.GetMethod("GetMappingResult", new[] { sourceType, typeof(TDestination) });
            return (TDestination)getMappingResultMethod.Invoke(mappingInstance, new object[] { source, prevDestination });
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
        // Overload to map onto an existing destination object
        public TDestination GetMappingResult(TSource source, TDestination prevDestination = default) {
            var config = GetMapperConfiguration();
            var mapper = config.CreateMapper();

            // Check if existingDestination is the default value (null for reference types, default value for value types)
            bool isDefault = EqualityComparer<TDestination>.Default.Equals(prevDestination, default);

            return isDefault
                ? mapper.Map<TSource, TDestination>(source)
                : mapper.Map(source, prevDestination); // Use existing destination to map only properties that exist in source
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

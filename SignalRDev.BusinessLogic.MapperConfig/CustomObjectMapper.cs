using AutoMapper;
using SignalRDev.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDev.BusinessLogic.MapperConfig
{
    public class CustomObjectMapper : ICustomObjectMapper
    {
        public IEnumerable<TDestination> MapToEnumerable<TSource, TDestination>(IEnumerable<TSource> pSource)
            where TSource : class
            where TDestination : class
        {
            IEnumerable<TDestination> mappedEnumerable = null;

            try
            {
                mappedEnumerable = Mapper.Map<IEnumerable<TSource>, IEnumerable<TDestination>>(pSource);
            }
            catch (Exception)
            {
                throw;
            }

            return mappedEnumerable;
        }

        public TDestination MapToObject<TSource, TDestination>(TSource pSource)
            where TSource : class
            where TDestination : class
        {
            TDestination mappedObj;

            try
            {
                mappedObj = Mapper.Map<TSource, TDestination>(pSource);
            }
            catch (Exception)
            {
                throw;
            }

            return mappedObj;
        }
    }
}

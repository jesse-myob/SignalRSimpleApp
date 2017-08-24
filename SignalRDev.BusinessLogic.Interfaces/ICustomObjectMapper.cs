using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDev.BusinessLogic.Interfaces
{
    public interface ICustomObjectMapper
    {
        IEnumerable<TDestination> MapToEnumerable<TSource, TDestination>(IEnumerable<TSource> pSource)
            where TSource : class
            where TDestination : class;

        TDestination MapToObject<TSource, TDestination>(TSource pSource)
            where TSource : class
            where TDestination : class;
    }
}

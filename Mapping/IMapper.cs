using System;
using System.Collections.Generic;
using System.Text;

namespace Mapping
{
    public interface IMapper<in TSource, out TResult>
    {
        TResult Map(TSource source);
    }
}

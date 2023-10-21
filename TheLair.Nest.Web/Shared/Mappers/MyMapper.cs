using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLair.Nest.Web.Shared.Mappers;

public interface MyMapperTo<in TSource, out TDest>
{
    static abstract TDest To(TSource source);
}

public interface MyMapperFrom<out TSource, in TDest>
{
    static abstract TSource From(TDest source);
}
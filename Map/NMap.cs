using System.Diagnostics;
using NMap.ImplBase.Map;
using NMap.Service.Base;

namespace NMap.Service.Map
{
	public class NMap : NMapBase<IMapping>, INMap
	{
		public void Register<TSource, TResult>(IMapping<TSource, TResult> mappingClass, string customOption = "")
		{
			Register(mappingClass, typeof (TSource), typeof (TResult), customOption);
		}

		public TResult Map<TSource, TResult>(TSource source, string customOption = "")
		{
			var mapping = Get(typeof (TSource), typeof (TResult), customOption);
			Debug.Assert(mapping is IMapping<TSource, TResult>, "mapping is IMapping<TSource, TResult>");
			return ((IMapping<TSource, TResult>) mapping).Map(source);
		}
	}
}
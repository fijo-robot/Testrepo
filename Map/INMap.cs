using JetBrains.Annotations;
using NMap.ImplBase.Map;
using NMap.Service.Base;

namespace NMap.Service.Map
{
	public interface INMap : INMapBase<IMapping>
	{
		void Register<TSource, TResult>([NotNull] IMapping<TSource, TResult> mappingClass, string customOption = "");
		TResult Map<TSource, TResult>(TSource source, string customOption = "");
	}
}
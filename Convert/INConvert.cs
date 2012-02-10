using JetBrains.Annotations;
using NMap.ImplBase.Convert;
using NMap.Service.Base;

namespace NMap.Service.Convert
{
	public interface INConvert : INMapBase<IConverting>
	{
		void Register<TSource, TResult>([NotNull] IConverting<TSource, TResult> convertingClass, string customOption = "");
		TResult Convert<TSource, TResult>(TSource source, string customOption = "");
	}
}
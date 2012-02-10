using System.Diagnostics;
using NMap.ImplBase.Convert;
using NMap.Service.Base;

namespace NMap.Service.Convert
{
	public class NConvert : NMapBase<IConverting>, INConvert
	{
		public void Register<TSource, TResult>(IConverting<TSource, TResult> convertingClass, string customOption = "")
		{
			Register(convertingClass, typeof (TSource), typeof (TResult), customOption);
		}

		public TResult Convert<TSource, TResult>(TSource source, string customOption = "")
		{
			var converting = Get(typeof (TSource), typeof (TResult), customOption);
			Debug.Assert(converting is IConverting<TSource, TResult>, "converting is IConverting<TSource, TResult>");
			return ((IConverting<TSource, TResult>) converting).Convert(source);
		}
	}
}
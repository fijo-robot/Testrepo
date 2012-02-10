using System;
using JetBrains.Annotations;

namespace NMap.Service.Base
{
	public interface INMapBase<TMappingClass> where TMappingClass : class
	{
		void Register([NotNull] TMappingClass mappingClass, [NotNull] Type source, [NotNull] Type result, string customOption = "");
		TMappingClass Get([NotNull] Type source, [NotNull] Type result, string customOption);
	}
}
using System;
using System.Diagnostics;
using System.Linq;
using FijoCore.Infrastructure.DependencyInjection.InitKernel;
using NMap.Service.Base;

namespace NMap.ImplBase.Base
{
	public class NMappingRegistrationService<TMappingClass> where TMappingClass : class, INMappingRegistrationBase
	{
		private readonly INMapBase<TMappingClass> _mappingService = Kernel.Resolve<INMapBase<TMappingClass>>();
		private readonly NMappingClassRepository<TMappingClass> _mappingClassRepository = Kernel.Resolve<NMappingClassRepository<TMappingClass>>();

		public void Init() {
			foreach(var entry in _mappingClassRepository.Get()) Register(entry);
		}

		private void Register(TMappingClass mapping) {
			var genericArguments = GenericType(mapping).GetGenericArguments().ToArray();
			Debug.Assert(genericArguments.Count() == 2, "genericArguments.Count() == 2");
			_mappingService.Register(mapping, genericArguments[0], genericArguments[1], mapping.CustomOption);
		}

		private Type GenericType(TMappingClass mapping) {
			Type type;
			var nextType = mapping.GetType();
			do {
				type = nextType;
// ReSharper disable PossibleNullReferenceException
				nextType = type.BaseType;
// ReSharper restore PossibleNullReferenceException
			} while (nextType != typeof (TMappingClass));
			return type;
		}
	}
}
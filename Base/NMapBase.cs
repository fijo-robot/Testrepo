using System;
using Fijo.Infrastructure.DesignPattern.Store;
using FijoCore.Infrastructure.DependencyInjection.InitKernel;
using NMap.Dtos;
using NMap.Factories;

namespace NMap.Service.Base
{
	public abstract class NMapBase<TMappingClass> : INMapBase<TMappingClass> where TMappingClass : class
	{
		protected readonly IStore<NMapping<TMappingClass>> Store = Kernel.Resolve<IStore<NMapping<TMappingClass>>>();
		protected readonly NMappingFactory<TMappingClass> Factory = Kernel.Resolve<NMappingFactory<TMappingClass>>();
		
		public void Register(TMappingClass mappingClass, Type source, Type result, string customOption = "")
		{
			Store.Store(Factory.Create(mappingClass, source, result, customOption));
		}

		public TMappingClass Get(Type source, Type result, string customOption)
		{
			return Store.Get(Factory.CreateForRequest(source, result, customOption)).MappingClass;
		}
	}
}
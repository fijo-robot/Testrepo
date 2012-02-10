using System;
using System.Collections.Generic;
using System.Linq;

namespace NMap.ImplBase.Base {
	public class NMappingClassRepository<TMappingClass> where TMappingClass : class, INMappingRegistrationBase {
		public IEnumerable<TMappingClass> Get() {
			return AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes()).Where(x => x.IsAssignableFrom(typeof(TMappingClass))).Select(x => (TMappingClass)x.TypeInitializer.Invoke(new object[]{}));
		}
	}
}
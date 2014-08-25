using System.Collections;
using System.Collections.Generic;
using Iesi.Collections;
using Iesi.Collections.Generic;
using NUnit.Framework;

namespace NHibernate.Validator.Tests.DeepIntegration
{
	[TestFixture]
	public class MultipleSetFetchFixture : AbstractMultipleCollectionFixture
	{
		protected override IList Mappings
		{
			get { return new string[] { "DeepIntegration.PersonSet.hbm.xml" }; }
		}

		protected override ICollection<T> CreateCollection<T>()
		{
			return new HashSet<T>();
		}

		protected override ICollection<Person> GCreateCollection()
		{
			return new HashSet<Person>();
		}
	}
}
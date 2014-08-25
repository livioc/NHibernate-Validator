using System.Collections;
using System.Collections.Generic;
using NHibernate.Collection;
using NUnit.Framework;

namespace NHibernate.Validator.Tests.DeepIntegration
{
	[TestFixture]
	public class MultipleBagFetchFixture : AbstractMultipleCollectionFixture
	{
		protected override IList Mappings
		{
			get { return new string[] { "DeepIntegration.PersonBag.hbm.xml" }; }
		}

		protected override ICollection<T> CreateCollection<T>()
		{
			return new List<T>();
		}

		protected override ICollection<Person> GCreateCollection()
		{
			return new List<Person>();
		}
	}
}
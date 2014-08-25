using NHibernate.Validator.Engine;
using NUnit.Framework;
using SharpTestsEx;
using System.Collections.Generic;

namespace NHibernate.Validator.Tests.Engine
{
	[TestFixture]
	public class ReferenceEqualityComparerTests
	{
		public class Entity
		{
			public override bool Equals(object obj)
			{
				return true;
			}
			public override int GetHashCode()
			{
				return 17;
			}
		}

		[Test]
		public void TwoClassInstances_AreNotEquals()
		{
			IEqualityComparer<object> rec = new ReferenceEqualityComparer();
			var instance = new Entity();
			rec.Equals(instance, new Entity()).Should().Be.False();
			rec.Equals(instance, instance).Should().Be.True();

			rec.GetHashCode().Should().Not.Be.EqualTo(17);
			rec.GetHashCode().Should().Not.Be.EqualTo((new Entity()).GetHashCode());
		}
	}
}
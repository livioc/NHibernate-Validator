using System.Collections;
using System.Collections.Generic;
using NHibernate.Validator.Constraints;

namespace NHibernate.Validator.Tests.DeepIntegration
{
	public class Person
	{
		protected Person() {}

		public Person(string name)
		{
			Name = name;
		}

		public virtual int Id
		{
            get;
            set;
		}

		[NotEmpty, NotNull, Length(Min=2)]
		public virtual string Name
		{
            get;
            set;
		}

		[Valid, Size(Max=10)]
		public virtual ICollection<Person> Children
		{
            get;
            set;
		}

        [Valid, Size(Max = 5)]
        public virtual ICollection<Person> Friends
        {
            get;
            set;
        }

		[Valid]
		public virtual Person Parent
		{
            get;
            set;
		}
	}
}
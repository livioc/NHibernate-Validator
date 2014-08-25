using System;
using System.Runtime.Serialization;
using System.Text;
using NHibernate.Validator.Engine;

namespace NHibernate.Validator.Exceptions
{
	[Serializable]
	public class InvalidStateException : HibernateException
	{
		private readonly InvalidValue[] _invalidValues;

        protected InvalidStateException(SerializationInfo info, StreamingContext context)
            : base(info, context) 
        {
        }

		public InvalidStateException(string message, Exception inner) : base(message, inner) 
        {
        }

		public InvalidStateException(InvalidValue[] invalidValues)
			: this(invalidValues, invalidValues[0].EntityType.Name)
		{
		}

		public InvalidStateException(InvalidValue[] invalidValues, string className)
			: base(FormatMessage(invalidValues, className))
		{
			_invalidValues = invalidValues;
		}
        
		public InvalidValue[] GetInvalidValues() 
		{
			return _invalidValues;
		}

        private static string FormatMessage(InvalidValue[] invalidValues, string className)
        {
            var msg = new StringBuilder("validation failed for " + className + ":");
            foreach (var invalidValue in invalidValues)
            {
                if (!string.IsNullOrEmpty(invalidValue.PropertyName))
                {
                    msg.Append(invalidValue.PropertyName + ":");
                }
                msg.AppendLine(invalidValue.Message);
            }
            return msg.ToString();
        }
	}
}
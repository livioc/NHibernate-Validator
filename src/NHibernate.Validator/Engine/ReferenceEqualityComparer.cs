using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Collections.Generic;

namespace NHibernate.Validator.Engine
{
	/// <summary>
	/// <see cref="IEqualityComparer"/> used to prevent circular state validation.
	/// </summary>
	/// <remarks>
	/// The equality of two instances if done by Reference instead use the possible override of each element.
	/// The same for hash-code.
	/// </remarks>
	[Serializable]
	public class ReferenceEqualityComparer : IEqualityComparer<object>
	{
        #region IEqualityComparer<object> Members

        bool IEqualityComparer<object>.Equals(object x, object y)
        {
            return ReferenceEquals(x, y);
        }

        int IEqualityComparer<object>.GetHashCode(object obj)
        {
            return RuntimeHelpers.GetHashCode(obj);
        }

        #endregion
    }
}
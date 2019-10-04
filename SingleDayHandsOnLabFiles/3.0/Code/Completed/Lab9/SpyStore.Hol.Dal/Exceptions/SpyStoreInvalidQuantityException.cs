#region copyright

// Copyright Information
// ==================================
// SpyStore.Hol - SpyStore.Hol.Dal - SpyStoreInvalidQuantityException.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2019/10/04
// See License.txt for more information
// ==================================

#endregion

using System;

namespace SpyStore.Hol.Dal.Exceptions
{
    public class SpyStoreInvalidQuantityException : SpyStoreException
    {
        public SpyStoreInvalidQuantityException()
        {
        }

        public SpyStoreInvalidQuantityException(string message) : base(message)
        {
        }

        public SpyStoreInvalidQuantityException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
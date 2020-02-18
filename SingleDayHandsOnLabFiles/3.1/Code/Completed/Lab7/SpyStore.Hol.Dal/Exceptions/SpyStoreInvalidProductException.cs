#region copyright

// Copyright Information
// ==================================
// SpyStore.Hol - SpyStore.Hol.Dal - SpyStoreInvalidProductException.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2019/10/04
// See License.txt for more information
// ==================================

#endregion

using System;

namespace SpyStore.Hol.Dal.Exceptions
{
    public class SpyStoreInvalidProductException : SpyStoreException
    {
        public SpyStoreInvalidProductException()
        {
        }

        public SpyStoreInvalidProductException(string message) : base(message)
        {
        }

        public SpyStoreInvalidProductException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
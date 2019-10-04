#region copyright

// Copyright Information
// ==================================
// SpyStore.Hol - SpyStore.Hol.Dal - SpyStoreConcurrencyException.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2019/10/04
// See License.txt for more information
// ==================================

#endregion

using System;

namespace SpyStore.Hol.Dal.Exceptions
{
    public class SpyStoreConcurrencyException : SpyStoreException
    {
        public SpyStoreConcurrencyException()
        {
        }

        public SpyStoreConcurrencyException(string message) : base(message)
        {
        }

        public SpyStoreConcurrencyException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
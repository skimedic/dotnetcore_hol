// Copyright Information
// ==================================
// SpyStore.Hol - SpyStore.Hol.Dal - SpyStoreConcurrencyException.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/03/07
// See License.txt for more information
// ==================================

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
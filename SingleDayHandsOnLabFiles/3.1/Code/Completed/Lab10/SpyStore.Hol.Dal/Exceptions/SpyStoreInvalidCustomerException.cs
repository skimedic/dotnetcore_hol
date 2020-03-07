// Copyright Information
// ==================================
// SpyStore.Hol - SpyStore.Hol.Dal - SpyStoreInvalidCustomerException.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/03/07
// See License.txt for more information
// ==================================

using System;

namespace SpyStore.Hol.Dal.Exceptions
{
    public class SpyStoreInvalidCustomerException : SpyStoreException
    {
        public SpyStoreInvalidCustomerException()
        {
        }

        public SpyStoreInvalidCustomerException(string message) : base(message)
        {
        }

        public SpyStoreInvalidCustomerException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
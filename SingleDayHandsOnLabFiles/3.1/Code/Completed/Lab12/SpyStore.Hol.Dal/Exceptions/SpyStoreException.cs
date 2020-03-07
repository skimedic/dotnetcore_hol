// Copyright Information
// ==================================
// SpyStore.Hol - SpyStore.Hol.Dal - SpyStoreException.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/03/07
// See License.txt for more information
// ==================================

using System;
using System.Collections.Generic;
using System.Text;

namespace SpyStore.Hol.Dal.Exceptions
{
    public class SpyStoreException : Exception
    {
        public SpyStoreException()
        {
        }

        public SpyStoreException(string message) : base(message)
        {
        }

        public SpyStoreException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
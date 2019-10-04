#region copyright

// Copyright Information
// ==================================
// SpyStore.Hol - SpyStore.Hol.Dal - SpyStoreRetryLimitExceededException.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2019/10/04
// See License.txt for more information
// ==================================

#endregion

using System;

namespace SpyStore.Hol.Dal.Exceptions
{
    public class SpyStoreRetryLimitExceededException : SpyStoreException
    {
        public SpyStoreRetryLimitExceededException()
        {
        }

        public SpyStoreRetryLimitExceededException(string message) : base(message)
        {
        }

        public SpyStoreRetryLimitExceededException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
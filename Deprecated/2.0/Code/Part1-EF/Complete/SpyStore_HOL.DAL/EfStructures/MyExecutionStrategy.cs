using System;
using Microsoft.EntityFrameworkCore.Storage;

namespace SpyStore_HOL.DAL.EfStructures
{
    public class MyExecutionStrategy : ExecutionStrategy
    {
        public MyExecutionStrategy(ExecutionStrategyDependencies context) :
            base(context, ExecutionStrategy.DefaultMaxRetryCount, ExecutionStrategy.DefaultMaxDelay)
        {
        }

        public MyExecutionStrategy(ExecutionStrategyDependencies context, int maxRetryCount, TimeSpan maxRetryDelay) 
            : base(context, maxRetryCount, maxRetryDelay)
        {
        }

        protected override bool ShouldRetryOn(Exception exception)
        {
            return true;
        }
    }
}

using System;
using System.Transactions;
using Castle.DynamicProxy;
using PhoneBook.Core.Utilities.Interceptors;
using PhoneBook.Core.Utilities.IoC;
using Microsoft.EntityFrameworkCore;

namespace PhoneBook.Core.Aspects.Autofac.Transaction
{
    /// <summary>
    /// TransactionScopeAspect
    /// </summary>
    public class TransactionScopeAspectAsync : MethodInterception
    {
        private readonly Type _dbContextType;

        public TransactionScopeAspectAsync()
        {
        }

        public void InterceptDbContext(IInvocation invocation)
        {
            var db = ServiceTool.ServiceProvider.GetService(_dbContextType) as DbContext;
            using (var transactionScope = db.Database.BeginTransaction())
            {
                try
                {
                    invocation.Proceed();
                    transactionScope.Commit();
                }
                finally
                {
                    transactionScope.Rollback();
                }
            }
        }

        public override void Intercept(IInvocation invocation)
        {
            using (var tx = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                invocation.Proceed();
                tx.Complete();
            }
        }
    }
}
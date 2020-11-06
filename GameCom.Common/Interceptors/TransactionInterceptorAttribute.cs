using AspectCore.DynamicProxy;
using NHibernate;
using System;
using System.Threading.Tasks;

namespace GameCom.Common.Interceptors
{
    public class TransactionInterceptorAttribute : AbstractInterceptorAttribute
    {
        public async override Task Invoke(AspectContext context, AspectDelegate next)
        {
            var dbSession = context.ServiceProvider.GetService(typeof(ISession)) as ISession;
                        
            if (dbSession != null && dbSession.GetCurrentTransaction() == null)
            {
                using (var transaction = dbSession.BeginTransaction())
                {
                    try
                    {
                        await next(context);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
            else
            {
                await next(context);
            }
        }
    }
}

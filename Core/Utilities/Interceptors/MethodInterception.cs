using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        protected virtual void onBefore(IInvocation invocation) { }
        protected virtual void onAfter(IInvocation invocation) { }
        protected virtual void onException(IInvocation invocation, System.Exception e) { }
        protected virtual void onSuccess(IInvocation ınvocation) { }
    
        
        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;

            onBefore(invocation);
            try
            {
                invocation.Proceed();
            }

            catch (Exception e)
            {
                isSuccess = false;
                onException(invocation, e);
                throw;
            }

            finally
            {
                if (isSuccess)
                {
                    onSuccess(invocation);
                }
            }

            onAfter(invocation);
        }
    
    
    
    
    
    }
}

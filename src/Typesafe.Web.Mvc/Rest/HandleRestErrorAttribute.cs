using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Typesafe.Web.Mvc.Rest
{
	public class HandleRestErrorAttribute : HandleErrorAttribute
	{
		private static IDictionary<Type, Func<Exception, ActionResult>> exceptionShieldingMap = new Dictionary<Type, Func<Exception, ActionResult>>();

		public static void SetExceptionShieldingMap(IDictionary<Type, Func<Exception, ActionResult>> map)
		{
			exceptionShieldingMap = map ?? new Dictionary<Type, Func<Exception, ActionResult>>();
		}

		public static void Shield<T>(Func<Exception, ActionResult> resultFunc) where T : Exception
		{
			exceptionShieldingMap.Add(typeof(T), resultFunc);
		}

		public override void OnException(ExceptionContext filterContext)
		{
			if (ShieldException(filterContext)) return;

			base.OnException(filterContext);
		}

		private bool ShieldException(ExceptionContext exceptionContext)
		{
			var exception = exceptionContext.Exception;

			if (exception == null) return false;

			Func<Exception, ActionResult> resultFunc;

			if(exceptionShieldingMap.TryGetValue(exception.GetType(), out resultFunc))
			{
				exceptionContext.Result = resultFunc(exception);
				exceptionContext.HttpContext.Response.Clear();
				exceptionContext.ExceptionHandled = true;
				return true;
			}

			return false;
		}
	}
}
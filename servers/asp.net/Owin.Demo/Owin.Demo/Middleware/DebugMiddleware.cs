﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Owin;
using AppFunc = System.Func<
    System.Collections.Generic.IDictionary<string, object>,
    System.Threading.Tasks.Task
>;
namespace Owin.Demo.Middleware
{
    public class DebugMiddleware
    {
        AppFunc _next;
        DebubMiddlewareOptions _options;
        public DebugMiddleware(AppFunc next, DebubMiddlewareOptions options)
        {
            _next = next;
            _options = options;

            if (_options.OnIncomingRequest == null)
                _options.OnIncomingRequest = (ctx) => { Debug.WriteLine("Incoming request: " + ctx.Request.Path); };
            if (_options.OnOutgoingRequest == null)
                _options.OnOutgoingRequest = (ctx) => { Debug.WriteLine("Outgoing request: " + ctx.Request.Path); };
        }

        public async Task Invoke(IDictionary<string, object> environment)
        {
            var ctx = new OwinContext(environment);

            _options.OnIncomingRequest(ctx);
            await _next(environment);
            _options.OnOutgoingRequest(ctx);
        }
    }
}
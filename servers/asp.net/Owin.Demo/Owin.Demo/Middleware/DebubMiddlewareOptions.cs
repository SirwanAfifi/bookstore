using System;
using Microsoft.Owin;

namespace Owin.Demo.Middleware
{
    public class DebubMiddlewareOptions
    {
        public Action<IOwinContext> OnIncomingRequest { get; set; }
        public Action<IOwinContext> OnOutgoingRequest { get; set; }
    }
}
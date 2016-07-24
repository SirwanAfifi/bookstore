using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Razor;

namespace Core1RtmEmptyTest.Features.StartupCustomizations
{
    public class FeatureLocationExpander : IViewLocationExpander
    {
        public void PopulateValues(ViewLocationExpanderContext context)
        {
            context.Values["customviewlocation"] = nameof(FeatureLocationExpander);
        }

        public IEnumerable<string> ExpandViewLocations(
         ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            return new[]
            {
              "/Features/{1}/{0}.cshtml",
              "/Features/Shared/{0}.cshtml"
            };
        }
    }
}
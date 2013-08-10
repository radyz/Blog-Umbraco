using System;
using System.Web;
using System.Web.Optimization;

using dotless.Core;
using dotless.Core.Loggers;
using dotless.Core.configuration;

namespace Radyz.Web.Optimization
{
    public class LessTransform : IBundleTransform
    {
        #region IBundleTransform Members

        public void Process(BundleContext context, BundleResponse response)
        {
            //TODO - should we implement our own logger
            var config = new DotlessConfiguration
            {
                LogLevel = LogLevel.Error,
                Logger = typeof(ConsoleLogger)
            };

            var engine = new EngineFactory(config).GetEngine();

            response.Content = engine.TransformToCss(response.Content, null);
            response.ContentType = "text/css";
        }

        #endregion
    }
}
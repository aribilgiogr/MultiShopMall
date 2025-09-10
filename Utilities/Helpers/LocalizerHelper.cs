using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Helpers
{
    public static class LocalizerHelper<TResource>
    {
        private static IStringLocalizerFactory? localizerFactory;

        public static void Init(IStringLocalizerFactory factory)
        {
            localizerFactory = factory;
        }

        public static string T(string key)
        {
            if (localizerFactory == null) return key;

            var localizer = localizerFactory.Create(typeof(TResource));
            return localizer[key];
        }
    }
}

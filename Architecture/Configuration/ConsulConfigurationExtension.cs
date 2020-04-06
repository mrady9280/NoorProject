using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace Configuration
{
    public static class ConsulConfigurationExtension
    {
        public static IConfigurationBuilder AddConsul(this IConfigurationBuilder configurationBuilder, IEnumerable<Uri> consulUrls, string consulPath)
        {
            return configurationBuilder.Add(new ConsulConfigurationSource(consulUrls, consulPath));
        }

        public static IConfigurationBuilder AddConsul(this IConfigurationBuilder configurationBuilder, IEnumerable<string> consulUrls, string consulPath)
        {
            return configurationBuilder.AddConsul(consulUrls.Select(u => new Uri(u)), consulPath);
        }
    }
}
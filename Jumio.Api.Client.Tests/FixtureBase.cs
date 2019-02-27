using System;
using System.Collections.Generic;
using System.Linq;

namespace Jumio.Api.Tests
{
    public abstract class FixtureBase : IDisposable
    {
        public static readonly Guid MerchantIdScanReference = new Guid("79eaa575-ca41-4b35-9790-7319e455665b");

        protected static readonly List<string> Countries = AspNet.WebApi.Common.Helpers.CountryHelper.Regions.Select(_ => _.Value).ToList();

        public AutoFixture.Fixture Fixture { get; } = new AutoFixture.Fixture();

        internal static byte[] GetImage(string fileName) => System.IO.File.ReadAllBytes($"Data/{fileName}");

        internal static string GetBase64Image(string fileName)
        {
            var bytes = GetImage(fileName);

            return Convert.ToBase64String(bytes);
        }

        public void Dispose()
        {
        }
    }
}

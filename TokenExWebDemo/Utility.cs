using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TokenExWebDemo.Models;

namespace TokenExWebDemo
{
    public static class Utility
    {
        public static Dictionary<string, string> GenerateMonths()
        {
            var months = new Dictionary<string, string>();
            Enumerable.Range(1, 12).ToList().ForEach(x => months.Add(x.ToString().PadLeft(2, '0'), x.ToString().PadLeft(2, '0')));
            return months;
        }

        public static Dictionary<string, string> GenerateYears()
        {
            var years = new Dictionary<string, string>();
            Enumerable.Range(DateTime.Now.Year, 10).ToList().ForEach(x => years.Add(x.ToString(), x.ToString()));
            return years;
        }

        /// <summary>
        /// Using a given origin, generate an instance of an IframeConfiguration
        /// </summary>
        /// <param name="origin">The page from which the request originated</param>
        public static IframeConfiguration GenerateIframeConfiguration(string origin)
        {
            // Generate Authentication Key
            var timestamp = DateTime.UtcNow.ToString("yyyyMMddHHmmss");
            var concatenatedString = $"{Config.TokenExID}|{origin}|{timestamp}|{Config.TokenScheme}";
            var authenticationKey = GenerateHMAC(concatenatedString, Config.ClientSecretKey);


            return new IframeConfiguration()
            {
                Origin = origin,
                Timestamp = timestamp,
                TokenExID = Config.TokenExID,
                AuthenticationKey = authenticationKey,
                TokenScheme = Config.TokenScheme
            };
        }

        /// <summary>
        /// Valid HMAC signature to detect modifications from the browser
        /// </summary>
        /// <param name="payload">The information to hash</param>
        /// <param name="HMACKey">The SHA256 key to use in hashing</param>
        public static string GenerateHMAC(string payload, string HMACKey)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA256(Encoding.UTF8.GetBytes(HMACKey)))
            {
                var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(payload));
                return Convert.ToBase64String(hash);
            }
        }
    }
}
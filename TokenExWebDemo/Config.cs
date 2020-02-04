using System.Configuration;

namespace TokenExWebDemo
{
    public class Config
    {
        public static string TokenExID => ConfigurationManager.AppSettings["TokenEXID"];

        public static string APIKey => ConfigurationManager.AppSettings["APIKey"];

        public static string ClientSecretKey => ConfigurationManager.AppSettings["ClientSecretKey"];

        public static string BBEURL => ConfigurationManager.AppSettings["BBETokenizeEndpoint"];

        public static int  TokenScheme
        {
            get
            {
                int tokenscheme;
                if (!int.TryParse(ConfigurationManager.AppSettings["TokenScheme"], out tokenscheme))
                {
                    tokenscheme = 1;
                }
                return tokenscheme;
            }
        }

    }
}
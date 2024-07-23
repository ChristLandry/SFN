namespace SFN_FRONT.Core.BLL
{
    public class APILinkBll : IAPILinkBll
    {
        public IConfigurationRoot configuration;
        public APILinkBll()
        {
            var builder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "APILink.json");
            builder.AddJsonFile(path, optional: false);
            configuration = builder.Build();
        }

        public string GetBaseAdresse()
        {
            return configuration.GetSection("BaseAdresse").Value.ToString();
        }

        public string GetToken()
        {
            return configuration.GetSection("Token").Value.ToString();
        }

        //public string GetLDAPUser()
        //{
        //    return configuration.GetSection("APILDAPGETUSER").Value.ToString();
        //}

        //public string GetAllLDAPUser()
        //{
        //    return configuration.GetSection("APILDAPGETALLUSER").Value.ToString();
        //}

        //public string GetLDAPBase()
        //{
        //    return configuration.GetSection("APILDAP").Value.ToString();
        //}
    }
}

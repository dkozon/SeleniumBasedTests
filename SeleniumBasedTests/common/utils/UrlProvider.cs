using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumBasedTests
{
    public class UrlProviderAttr : Attribute
    {
        public string Url { get; private set; }
        internal UrlProviderAttr(string url)
        {
            this.Url = url;
        }
    }

    public static class UrlProvider
    {

        public static string GetUrl(this Url url)
        {
            UrlProviderAttr attr = GetAttr(url);
            return attr.Url;
        }

        public static UrlProviderAttr GetAttr(Url url)
        {
            return (UrlProviderAttr)Attribute.GetCustomAttribute(ForValue(url), typeof(UrlProviderAttr));
        }

        private static MemberInfo ForValue(Url url)
        {
            return typeof(Url).GetField(Enum.GetName(typeof(Url), url));
        }
    }

    public enum Url
    {
        [UrlProviderAttr("https://www.google.com/en")] GOOGLE_MAIN,
        [UrlProviderAttr("https://the-internet.herokuapp.com/")] THE_INTERNET
    }
}

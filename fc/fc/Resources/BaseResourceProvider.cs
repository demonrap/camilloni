using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace fc.Resources
{
    public abstract class BaseResourceProvider : IResourceProvider
    {
        //aaaa
        // Cache list of resources
        private static Dictionary<string, ResourceEntry> resources = null;
        private static object lockResources = new object();

        public BaseResourceProvider()
        {
            Cache = true; // By default, enable caching for performance
        }

        protected bool Cache { get; set; } // Cache resources ?

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object GetResource(string name, string culture)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Il nome della risorsa non può essere nullo o vuuoto.");

            if (string.IsNullOrWhiteSpace(culture))
                throw new ArgumentException("Il nome della Cultura non può essere nullo o vuuoto..");

            // normalize
            culture = culture.ToLowerInvariant();

            if (Cache && resources == null)
            {
                // Fetch all resources

                lock (lockResources)
                {

                    if (resources == null)
                    {
                        resources = ReadResources().ToDictionary(r => string.Format("{0}.{1}", r.Culture.ToLowerInvariant(), r.Name));
                    }
                }
            }

            if (Cache)
            {
                return resources[string.Format("{0}.{1}", culture, name)].Value;
            }

            return ReadResource(name, culture).Value;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected abstract IList<ResourceEntry> ReadResources();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        protected abstract ResourceEntry ReadResource(string name, string culture);
    }
}
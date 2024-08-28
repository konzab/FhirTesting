using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FhirConsole.Utils
{
    /// <summary>
    /// FHIR Utilities
    /// </summary>
    public class FhirUtilities
    {
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fhirClient"></param>
        /// <param name="authorizeUrl"></param>
        /// <param name="tokenUrl"></param>
        /// <returns></returns>
        public static bool TryGetSmartUrls(FhirClient fhirClient, 
            out string authorizeUrl, 
            out string tokenUrl)
        {
            authorizeUrl = string.Empty;
            tokenUrl = string.Empty;

            try
            {
                CapabilityStatement? capabilityStatement = fhirClient.Get("metadata") as CapabilityStatement;
                if (capabilityStatement != null)
                {
                    foreach (CapabilityStatement.RestComponent component in capabilityStatement.Rest)
                    {

                    }
                }


                if (string.IsNullOrEmpty(authorizeUrl) || string.IsNullOrEmpty(tokenUrl))
                    return false;

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}

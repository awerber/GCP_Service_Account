using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

/*
 * This class is intended for use in the Register method.
 * See https://developers.google.com/cloud-print/docs/proxyinterfaces#register for documentation
 * 
 */
namespace GoogleCloudPrint.Model
{
    [DataContract]
    public class UnregisteredCloudPrinter : CloudPrinter
    {
        [DataMember]
        // to hold some kind of repeated value, intended use is to allow filtering of printers
        public string tag { get; set; }

        [DataMember]
        // I don't think we need to list capabilities, but it's required to register
        public string capabilities { get; set; }

        
        // for trivial name of printer displayed at https://www.google.com/cloudprint#printers for the gmail user
        // used only for the update method, when calling method to get list this is returned as defaultDisplayName and displayName (weird)
        [DataMember]
        public string default_display_name { get; set; }
        
    }
}

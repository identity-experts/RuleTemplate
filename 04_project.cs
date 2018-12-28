
using System;
using Microsoft.MetadirectoryServices;

namespace Mms_ManagementAgent_RuleTemplate
{
    /// <summary>
    /// Summary description for MAExtensionObject.
	/// </summary>
	public partial class MAExtensionObject
    {        
        /// <summary>
        /// Controls whether the CSEntry should project to the MV
        /// and if it is projecting, what MVObjectType it will project as
        /// 
        /// 
        /// </summary>
        /// <param name="csentry"></param>
        /// <param name="MVObjectType"></param>
        /// <returns></returns>
        bool IMASynchronization.ShouldProjectToMV(CSEntry csentry, out string MVObjectType)
        {
            switch (csentry.ObjectType.ToUpper())
            {
                //-- example call out for the PERSON object class
                // case CLASSNAME_PERSON:  return FilterPerson(csentry);
                default:
                    //-- if we haven't got a handler in place, then throw an exception and log the object type so we've
                    //-- got a record of which object failed and why both out to the log *and* in the MIM Console
                    string message = string.Format("Unexpected object type - {0}", csentry.ObjectType);
                    logger.Error(message);
                    throw new EntryPointNotImplementedException(message);
            }
        }        
    }
}
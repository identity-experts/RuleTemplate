
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
        /// Specifies the Deprovisioning Action for the target CSEntry
        /// 
        /// do *not* use ExplicitDisconnector in any automated system
        /// </summary>
        /// <param name="csentry"></param>
        /// <returns></returns>
        DeprovisionAction IMASynchronization.Deprovision(CSEntry csentry)
        {
            switch (csentry.ObjectType.ToUpper())
            {
                case CLASSNAME_PERSON: return DeprovisionPerson(csentry);
                default:
                    //-- if we haven't got a handler in place, then throw an exception and log the object type so we've
                    //-- got a record of which object failed and why both out to the log *and* in the MIM Console
                    string message = string.Format("Unexpected object type in Deprovisioning - {0}", csentry.ObjectType);
                    logger.Error(message);
                    throw new EntryPointNotImplementedException(message);
            }
        }

        /// <summary>
        /// sample deprovisioning function for the Person object type
        /// </summary>
        /// <param name="csentry"></param>
        /// <returns></returns>
        private DeprovisionAction DeprovisionPerson(CSEntry csentry)
        {
            return DeprovisionAction.Disconnect;
        }
    }
}
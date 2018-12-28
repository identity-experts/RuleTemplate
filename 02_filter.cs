
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
        /// Split each filter down into object type and from there call a separate filter function
        /// this allows us to have distinct and readily identifiable filter rules that can be quickly reached
        /// while the main FilterForDisconnection code is only used to provide a routing function to the dedicated
        /// per-object-type filter rules.
        /// </summary>
        /// <param name="csentry">csentry to evaluate</param>
        /// <returns>true if the object is to be filtered, false otherwise</returns>
        bool IMASynchronization.FilterForDisconnection(CSEntry csentry)
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

        /// <summary>
        /// Sample stub for the PERSON object class - discard or adapt as needed
        /// </summary>
        /// <param name="csentry">csentry to evaluate</param>
        /// <returns>true if the object is to be filtered, false otherwise</returns>
        bool FilterPerson(CSEntry csentry)
        {
            return false;
        }

    }
}
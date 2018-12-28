
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
        /// Perform any initialization here - examples might include
        ///     creating database connections (I know these are "naughty" but...)
        ///     loading configuration (potentially from the database...)
        ///     preparing any lists or lookups used in flow rules
        /// </summary>
        void IMASynchronization.Initialize()
        {            
        }        
    }
}
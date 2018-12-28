
using System;
using Microsoft.MetadirectoryServices;
using NLog;

namespace Mms_ManagementAgent_RuleTemplate
{
    /// <summary>
    /// Summary description for MAExtensionObject.
	/// </summary>
	public partial class MAExtensionObject : IMASynchronization
	{
        //-- enable NLog
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Provide any constructor logic here       
        /// </summary>
		public MAExtensionObject()
		{            
        }		
	}
}


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
        /// Terminate the Rule Extension - add any close down / housekeeping functions here
        /// </summary>
        void IMASynchronization.Terminate()
        {
        }        
    }
}
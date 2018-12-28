
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
        /// Routing function that takes the flow-rule-name and calls out to the appropriate method to handle 
        /// the required flowrule
        /// 
        /// do *NOT* just drop everything into a single monolithic switch statement as it's horrible to work with
        /// and make use of constants rather than magic strings wherever possible
        /// 
        /// when creating flow rules, avoid using generic rules and try to employ a verb-noun style structure
        /// so our flow rules are creating meaning rather than just functioning as a place-holder for routing
        /// </summary>
        /// <param name="FlowRuleName"></param>
        /// <param name="mventry"></param>
        /// <param name="csentry"></param>
        void IMASynchronization.MapAttributesForExport(string FlowRuleName, MVEntry mventry, CSEntry csentry)
        {
            switch (FlowRuleName.ToUpper())
            {
                //-- example call out for the SAMPLE_FLOW_RULE
                case SAMPLE_RULE_NAME: sampleEAF(mventry, csentry); break;
                default:
                    //-- if we haven't got a handler in place, then throw an exception and log the object type so we've
                    //-- got a record of which object failed and why both out to the log *and* in the MIM Console
                    string message = string.Format("Unexpected export flow rule - {0}", FlowRuleName);
                    logger.Error(message);
                    throw new EntryPointNotImplementedException(message);
            }
        }

        /// <summary>
        /// Perform the export flow rule
        /// 
        /// note that we're going from MVEntry->CSEntry
        /// </summary>
        /// <param name="csentry"></param>
        /// <param name="mventry"></param>
        private void sampleEAF(MVEntry mventry, CSEntry csentry)
        {

        }
    }
}
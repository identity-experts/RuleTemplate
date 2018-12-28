
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
        /// MapAttributesForJoin
        /// 
        /// This rule allows us to take the CSEntry and construct a collection of values with which to attempt joins into the Metaverse with
        /// by applying lookups and transforms to the source-side data
        /// 
        /// use a switch statement to route out to each individual join rule rather than have a single monolithic method.
        /// </summary>
        /// <param name="FlowRuleName"></param>
        /// <param name="csentry"></param>
        /// <param name="values"></param>
        void IMASynchronization.MapAttributesForJoin(string FlowRuleName, CSEntry csentry, ref ValueCollection values)
        {
            switch (FlowRuleName.ToUpper())
            {
                case SAMPLE_RULE_NAME: ConstructJoinsSample(csentry, ref values); break;
                default:
                    //-- if we haven't got a handler in place, then throw an exception and log the object type so we've
                    //-- got a record of which object failed and why both out to the log *and* in the MIM Console
                    string message = string.Format("Unexpected Mapping for Join - {0}", FlowRuleName);
                    logger.Error(message);
                    throw new EntryPointNotImplementedException(message);
            }
        }

        /// <summary>
        /// sample function - potential join candidates and add them to the values collection
        /// </summary>
        /// <param name="csentry"></param>
        /// <param name="values"></param>
        private void ConstructJoinsSample(CSEntry csentry, ref ValueCollection values)
        {
            values.Add(csentry.DN);
            values.Add(csentry.RDN);
            values.Add(csentry.ObjectType);
        }

        /// <summary>
        /// Resolves which of the potential MV Entries (if any) that we're going to join our csentry to
        /// 
        /// use a switch statement to route out to each individual join rule rather than have a single monolithic method.
        /// </summary>
        /// <param name="joinCriteriaName"></param>
        /// <param name="csentry"></param>
        /// <param name="rgmventry"></param>
        /// <param name="imventry"></param>
        /// <param name="MVObjectType"></param>
        /// <returns></returns>
        bool IMASynchronization.ResolveJoinSearch(string joinCriteriaName, CSEntry csentry, MVEntry[] rgmventry, out int imventry, ref string MVObjectType)
        {
            switch (joinCriteriaName.ToUpper())
            {
                case SAMPLE_RULE_NAME: return SampleJoinSelection(csentry, rgmventry, out imventry, ref MVObjectType);
                default:
                    //-- if we haven't got a handler in place, then throw an exception and log the object type so we've
                    //-- got a record of which object failed and why both out to the log *and* in the MIM Console
                    string message = string.Format("Unexpected Join Resolution - {0}", joinCriteriaName);
                    logger.Error(message);
                    throw new EntryPointNotImplementedException(message);
            }
        }

        /// <summary>
        /// parse through the available MVEntrys in rgmventry to see which (if any) is the correct match
        /// return true if we've found a match or false otherwise
        /// set imventry to the index of the MVentry in rgmventry that we're matching (0 otherwise)
        /// set MVObjectType to the name of the MV ObjectType we've matched
        /// </summary>
        /// <param name="csentry"></param>
        /// <param name="rgmventry"></param>
        /// <param name="imventry"></param>
        /// <param name="MVObjectType"></param>
        /// <returns></returns>
        private bool SampleJoinSelection(CSEntry csentry, MVEntry[] rgmventry, out int imventry, ref string MVObjectType)
        {
            bool match_found = false;

            imventry = 0;
            MVObjectType = rgmventry[imventry].ObjectType;
            
            return match_found;
        }
    }
}
using AutomationKitCoreModel.Attributes;
using AutomationKitCoreModel.Authentication;
using System.Runtime.Serialization;

namespace HelloAutomationKit
{
    public class AutomationKitWebApiAppClaims
    {
        /// <summary>
        /// Claim to Read content / show app
        /// </summary>
        public const string Read = "pf_AutomationKitWebApi.read";
        /// <summary>
        /// Claim to make changes
        /// </summary>
        public const string Write = "pf_AutomationKitWebApi.write";

        /// <summary>
        /// Settings group name
        /// </summary>
        public const string ClaimsGroupName = "AutomationKitWebApiGroup";

        /// <summary>
        /// The enum in this class that has a “ClaimEnum”-Attribute, generates automatically the right Enum-Object for typescript to be able to customize the UI based on the user claims
        /// </summary>
        [ClaimEnum]
        public enum AutomationKitWebApiAppClaimsEnum
        {
            /// <summary>
            /// Show App / Read-Access
            /// </summary>
            [EnumMember(Value = AutomationKitWebApiAppClaims.Read)]
            Read,
            /// <summary>
            /// Make changes in app
            /// </summary>
            [EnumMember(Value = AutomationKitWebApiAppClaims.Write)]
            Write
        }

        /// <summary>
        /// Returns all Claims defined by the App
        /// </summary>
        /// <returns></returns>
        public static List<Claim> GetClaims()
        {
            return new List<Claim>()
            {
                new Claim(Read, ClaimsGroupName, "AutomationKitWebApiRead"),
                new Claim(Write, ClaimsGroupName, "AutomationKitWebApiWrite")
            };
        }
    }
}

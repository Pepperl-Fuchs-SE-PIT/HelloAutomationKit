using AutomationKitCoreModel.App;
using AutomationKitCoreModel.Authentication;

namespace HelloAutomationKit
{
    public class AutomationKitWebApiApp : BaseApp
    {
        /// <summary>
        /// Id of this App
        /// </summary>
        public const string AutomationKitWebApiAppGuid = "b27bf3d0-da8c-4025-a4bc-b5958876905a";
        /// <inheritdoc/>
        public override string AppGuid => AutomationKitWebApiAppGuid;
        /// <inheritdoc/>
        public override string Name => "AutomationKitWebApiApp";
        /// <inheritdoc/>
        public override string Description => "AutomationKitWebApiAppDescription";
        /// <inheritdoc/>
        public override string Icon => "fas fa-wrench";
        /// <inheritdoc/>
        public override string Path => "AutomationKitWebApi";
        /// <inheritdoc/>
        public override string NeededClaim => AutomationKitWebApiAppClaims.Read;
        /// <inheritdoc/>
        public override List<Claim> Claims => AutomationKitWebApiAppClaims.GetClaims();

    }
}

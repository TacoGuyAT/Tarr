using HarmonyLib;
using Il2CppMonomiPark.SlimeRancher.UI.MainMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarr.Patches {
    [HarmonyPatch(typeof(MainMenuLandingRootUI), "Init")]
    class MainMenuLandingRootUI_Init {
        public static bool isReopened = false;
        static void Postfix(MainMenuLandingRootUI __instance) {
            if(isReopened) return;
            isReopened = true;
            Callbacks.OnMainMenuOpen(__instance);
        }
    }
}

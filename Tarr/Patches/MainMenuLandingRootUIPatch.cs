using HarmonyLib;
using Il2CppMonomiPark.SlimeRancher.UI.MainMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarr.Patches {
    [HarmonyPatch(typeof(MainMenuLandingRootUI))]
    class MainMenuLandingRootUIPatch {
        public static bool isReopened = false;
        [HarmonyPostfix]
        [HarmonyPatch("Init")]
        static void InitPostfix(MainMenuLandingRootUI __instance) {
            if(isReopened) return;
            isReopened = true;
            Callbacks.OnMainMenuOpen(__instance);
        }
    }
}

using HarmonyLib;
using Il2CppMonomiPark.SlimeRancher.UI;
using Il2CppMonomiPark.SlimeRancher.UI.MainMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarr.Patches {
    [HarmonyPatch(typeof(PauseMenuRoot), "Awake")]
    class PauseMenuRoot_Awake {
        static void Postfix(PauseMenuRoot __instance) { // why it calls the thing twice, whyyyy
            Callbacks.OnPauseMenuOpen(__instance);
        }
    }
}

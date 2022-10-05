using HarmonyLib;
using Il2CppMonomiPark.SlimeRancher.Script.UI.Pause;
using Il2CppMonomiPark.SlimeRancher.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarr.Patches {
    [HarmonyPatch(typeof(PauseMenuDirector))]
    class PauseMenuDirectorPatch {
        static bool isReopened = false;
        [HarmonyPostfix]
        [HarmonyPatch("PauseGame")]
        static void PauseGamePostfix() { // why it calls the thing twice, whyyyy
            if(isReopened) return;
            isReopened = true;
            Callbacks.OnPauseMenuOpen(SRSingleton<SceneContext>.Instance.PauseMenuDirector.pauseUI.GetComponentInChildren<PauseMenuRoot>());
        }
        [HarmonyPostfix]
        [HarmonyPatch("UnPauseGame")]
        static void UnPauseGamePostfix() {
            isReopened = false;
        }
    }
}

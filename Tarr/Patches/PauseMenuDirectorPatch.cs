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
        [HarmonyPostfix]
        [HarmonyPatch("PauseGame")]
        static void PauseGamePostfix() {
            Callbacks.OnPauseMenuOpen(SRSingleton<SceneContext>.Instance.PauseMenuDirector.pauseUI.GetComponentInChildren<PauseMenuRoot>());
        }
    }
}

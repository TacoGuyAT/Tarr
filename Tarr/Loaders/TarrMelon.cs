using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnhollowerRuntimeLib;
using UnityEngine;

[assembly: MelonInfo(typeof(Tarr.Loaders.TarrMelon), "Tarr", "0.1.0", "__tacoguy", "https://github.com/TacoGuyAT/Tarr")]
[assembly: MelonColor(ConsoleColor.DarkMagenta)]

namespace Tarr.Loaders {
    public class TarrMelon : MelonMod {
        public static GameObject TarrObject;

        public override void OnInitializeMelon() {
            UniverseLib.Universe.Init();

            ClassInjector.RegisterTypeInIl2Cpp<TarrMod>();

            TarrObject = new GameObject("TarrMod");
            TarrObject.hideFlags = HideFlags.HideAndDontSave;
            TarrObject.AddComponent<TarrMod>();
            GameObject.DontDestroyOnLoad(TarrObject);

            Callbacks.OnMainMenuOpenEvent += (m) => {
                GUI.AddMainMenuButton(m, () => { GUI.CreateBasic("Mods", "doing...", ""); }, "Mods", null, -2);
            };
            Callbacks.OnPauseMenuOpenEvent += (m) => {
                GUI.AddPauseMenuButton(m, () => { GUI.CreateBasic("Mods", "doing...", ""); }, "Mods", -2);
            };

            TarrMod.Info("Hello, cruel world!");
        }
        public override void OnSceneWasLoaded(int buildIndex, string sceneName) {
            if(sceneName == "MainMenuUI")
                Patches.MainMenuLandingRootUIPatch.isReopened = false;
        }
    }
}

using MelonLoader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using uGUI = UnityEngine.GUI;
using OHarmony = HarmonyLib.Harmony;
using Il2CppMonomiPark.SlimeRancher.Player.CharacterController.Abilities;
using Il2CppMonomiPark.SlimeRancher.Player.CharacterController;
using UnhollowerRuntimeLib;

[assembly: MelonInfo(typeof(Tarr.TarrMod), "Tarr", "0.1.0", "__tacoguy", "https://github.com/TacoGuyAT/Tarr")]
[assembly: MelonColor(ConsoleColor.DarkMagenta)]

namespace Tarr {
    public class TarrMod : MelonMod {
        public override void OnInitializeMelon() {
            UniverseLib.Universe.Init();
            GetHarmony().PatchAll();
            Callbacks.OnMainMenuOpenEvent += (m) => {
                GUI.AddMainMenuButton(m, () => { GUI.CreateBasic("Mods", "doing...", ""); }, "Mods", null, -2);
            };
            Log("Hello, cruel world!");
        }
        public override void OnSceneWasLoaded(int buildIndex, string sceneName) {
            if(sceneName.Contains("MainMenuUI"))
                Patches.MainMenuLandingRootUIPatch.isReopened = false;
        }
        public override void OnGUI() {
            if(uGUI.Button(new Rect(10, 210, 80, 24), "Create GUI")) {
                GUI.CreateBasic(
                    "Sample text",
                    "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque faucibus fermentum efficitur. Cras cursus justo id leo mattis gravida. Nam eget elit a diam suscipit ullamcorper. Sed vitae egestas arcu. Mauris ultricies eleifend quam a egestas. Praesent euismod eros ex, in tristique purus euismod et. Maecenas porttitor ipsum pellentesque orci maximus fermentum.",
                    "GUI!",
                    new Action(() => Log("Clicked OK"))
                    );
            }
            if(uGUI.Button(new Rect(10, 238, 80, 24), "No Clip")) {
                DebugFlyAbilityBehavior dfab = SRSingleton<SceneContext>.Instance.player.GetComponent<SRCharacterController>().GetAbility<DebugFlyAbilityBehavior>();
                dfab.IsActive = true;
                dfab.Start();
            }
        }
        public static OHarmony GetHarmony() {
            return Melon<TarrMod>.Instance.HarmonyInstance;
        }
        // https://stackoverflow.com/a/35658387
        public static void Dump(Il2CppSystem.Object obj) {
            var props = obj.GetIl2CppType().GetProperties(Il2CppSystem.Reflection.BindingFlags.Default);
            StringBuilder sb = new StringBuilder();
            foreach(var item in props) {
                sb.Append($"\n{item.Name}: {item.GetValue(obj, null)};");
            }
            sb.AppendLine();
            Console.WriteLine(sb.ToString());
        }
        public static void Dump(object obj) {
            var props = obj.GetType().GetProperties();
            StringBuilder sb = new StringBuilder();
            foreach(var item in props) {
                sb.Append($"\n{item.Name}: {item.GetValue(obj, null)};");
            }
            sb.AppendLine();
            Console.WriteLine(sb.ToString());
        }
        public static void Log(object obj, LogLevel level = LogLevel.Information) {
            switch(level) {
                case LogLevel.Warning:
                    Melon<TarrMod>.Logger.Warning(obj);
                    break;
                case LogLevel.Error:
                    Melon<TarrMod>.Logger.Error(obj);
                    break;
                case LogLevel.Critical:
                    Melon<TarrMod>.Logger.Error(obj);
                    break;
                default:
                    Melon<TarrMod>.Logger.Msg(obj);
                    break;
            }
        }
    }
    public enum LogLevel {
        Trace,
        Debug,
        Information,
        Warning,
        Error,
        Critical
    }
}

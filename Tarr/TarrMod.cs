using MelonLoader;
using System;
using System.Linq;
using System.Text;
using UnityEngine;
using uGUI = UnityEngine.GUI;
using OHarmony = HarmonyLib.Harmony;
using Il2CppMonomiPark.SlimeRancher.Player.CharacterController.Abilities;
using Il2CppMonomiPark.SlimeRancher.Player.CharacterController;
using Tarr.Loaders;

namespace Tarr {
    public class TarrMod : MonoBehaviour {
        public TarrMod(IntPtr ptr) : base(ptr) { }
        public void OnGUI() {
            if(uGUI.Button(new Rect(10, 10, 80, 24), "No Clip")) {
                DebugFlyAbilityBehavior dfab = SRSingleton<SceneContext>.Instance.player.GetComponent<SRCharacterController>().GetAbility<DebugFlyAbilityBehavior>();
                if(dfab == null) Info("a");
                Dump(dfab);
                dfab.IsActive = true;
                dfab.abilityData.flySpeed = 1;
                dfab.flyUp = true;
            }
        }
        // https://stackoverflow.com/a/35658387
        public static void Dump(Il2CppSystem.Object obj) {
            var props = obj.GetIl2CppType().GetProperties(
                Il2CppSystem.Reflection.BindingFlags.NonPublic |
                Il2CppSystem.Reflection.BindingFlags.Public
                );
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
        public static void Log(LogLevel level = LogLevel.Information, params object[] obj) {
            var result = String.Join(" ", obj.Select((x) => x.ToString()));
            switch(level) {
                case LogLevel.Warning:
                    Melon<TarrMelon>.Logger.Warning(result);
                    break;
                case LogLevel.Error:
                    Melon<TarrMelon>.Logger.Error(result);
                    break;
                case LogLevel.Critical:
                    Melon<TarrMelon>.Logger.Error(result);
                    break;
                default:
                    Melon<TarrMelon>.Logger.Msg(result);
                    break;
            }
        }
        public static void LogFormat(LogLevel level = LogLevel.Information, string format = "", params object[] obj) {
            Log(level, String.Format(format, obj));
        }
        public static void Info(params object[] obj) {
            Log(LogLevel.Information, obj);
        }
        public static void Warning(params object[] obj) {
            Log(LogLevel.Warning, obj);
        }
        public static void Error(params object[] obj) {
            Log(LogLevel.Error, obj);
        }
        public static void InfoFormat(string format, params object[] obj) {
            LogFormat(LogLevel.Information, format, obj);
        }
        public static void WarningFormat(string format, params object[] obj) {
            LogFormat(LogLevel.Warning, format, obj);
        }
        public static void ErrorFormat(string format, params object[] obj) {
            LogFormat(LogLevel.Error, format, obj);
        }
        public static void AssertFormat(bool condition, string format, params object[] obj) {
            if(condition)
                LogFormat(LogLevel.Information, format, obj);
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

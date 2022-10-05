using Il2CppMonomiPark.SlimeRancher.UI;
using Il2CppMonomiPark.SlimeRancher.UI.MainMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarr {
    public static class Callbacks {
        public delegate void OnMainMenuOpenDelegate(MainMenuLandingRootUI mainMenu);
        public static event OnMainMenuOpenDelegate OnMainMenuOpenEvent;
        internal static void OnMainMenuOpen(MainMenuLandingRootUI mainMenu) => OnMainMenuOpenEvent?.Invoke(mainMenu);

        public delegate void OnPauseMenuOpenDelegate(PauseMenuRoot pauseMenu);
        public static event OnPauseMenuOpenDelegate OnPauseMenuOpenEvent;
        internal static void OnPauseMenuOpen(PauseMenuRoot pauseMenu) => OnPauseMenuOpenEvent?.Invoke(pauseMenu);
    }
}

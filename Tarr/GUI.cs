using Il2CppMonomiPark.SlimeRancher.Script.Util;
using Il2CppMonomiPark.SlimeRancher.UI;
using Il2CppMonomiPark.SlimeRancher.UI.MainMenu;
using Il2CppMonomiPark.SlimeRancher.UI.Popup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TMPro;
using UnhollowerRuntimeLib;
using UnityEngine;
using UnityEngine.Localization;
using Button = UnityEngine.UI.Button;

namespace Tarr {
    public static class GUI {
        /// <summary>
        /// Creates basic GUI with title, text and two buttons
        /// </summary>
        /// <param name="positiveButton">Leave empty for localized "OK"</param>
        /// <param name="negativeButton">Leave null to not initialize the button. Leave empty for localized "Cancel"</param>
        // TODO: Add same thing for PositiveNegativePopupPromptConfig (aka localized edition)
        public static MainMenuLandingRootUI CreateBasic(
            string title,
            string message,
            string positiveButton,
            Action positiveAction = null,
            string negativeButton = null,
            Action negativeAction = null,
            bool dimBackground = true
            ) {
			LocalizedString titleL = LocalizationUtil.CreateByKey("UI", "l.unknown");
			LocalizedString messageL = LocalizationUtil.CreateByKey("UI", "b.unavailable");
            LocalizedString warningL = LocalizationUtil.CreateByKey("UI", "b.unavailable");

            LocalizedString positiveL = LocalizationUtil.CreateByKey("UI", "b.ok");
            LocalizedString negativeL = LocalizationUtil.CreateByKey("UI", "b.cancel");

            LocalizedString countdownL = LocalizationUtil.CreateByKey("UI", "b.unavailable");

            GameObject gui_gameobject;

            if(negativeButton == null) {
                PositivePopupPromptConfig config = new PositivePopupPromptConfig {
                    shouldDimBackground = dimBackground,
                    activateActionsDelay = 0,
                    expires = false,
                    expirationDuration = 15,
                    name = $"TarrGUIPopup-{new System.Random().Next(1000, 9999)}",
                    title = titleL,
                    message = messageL,
                    warning = warningL,
                    countdownHeader = countdownL,
                    positiveButtonText = positiveL,
                };
                gui_gameobject = SRSingleton<GameContext>.Instance.UITemplates.CreatePositivePopupPrompt(config, positiveAction);
            } else {
                PositiveNegativePopupPromptConfig config = new PositiveNegativePopupPromptConfig {
                    shouldDimBackground = dimBackground,
                    activateActionsDelay = 0,
                    expires = false,
                    expirationDuration = 15,
                    name = $"TarrGUIPopup-{new System.Random().Next(1000, 9999)}",
                    title = titleL,
                    message = messageL,
                    warning = warningL,
                    countdownHeader = countdownL,
                    positiveButtonText = positiveL,
                    negativeButtonText = negativeL,
                };
                gui_gameobject = SRSingleton<GameContext>.Instance.UITemplates.CreatePositiveNegativePopupPrompt(config, positiveAction, negativeAction);
            }

            var gui = gui_gameobject.GetComponent<MainMenuLandingRootUI>();

            gui_gameobject.GetComponent<PopupPrompt>().titleText.text = title;
            gui_gameobject.GetComponent<PopupPrompt>().messageText.text = message;
            gui_gameobject.GetComponent<PopupPrompt>().warningText.text = "";
            if(positiveButton != null && positiveButton != "")
                gui_gameobject.GetComponent<PopupPrompt>().positiveActionButtonText.text = positiveButton;
            if(negativeButton != null && negativeButton != "")
                gui_gameobject.GetComponent<PopupPrompt>().negativeActionButtonText.text = negativeButton;

            return gui;
        }
        public static void CreateList(string title, string text, Action<string> selected = null) {

        }
        public static void CreateCustom(string title, UIElements.UIElement content) {
                                 //  maybe it should only have content field  ^
        }
        /// <summary>
        /// Adds custom main menu buttons
        /// </summary>
        /// <param name="index">
        /// If greater than 0, just sets index.
        /// If negative - sets index from bottom starting from -1 as last element (elements_amount-index).
        /// </param>
        public static void AddMainMenuButton(MainMenuLandingRootUI menu, Action onClick, string text, object icon = null, int index = 0) {
            var group = menu.transform.Find("MenuContent_OverscanAdjustment/LayoutGroup_Right (MainMenuButtons)");
            var go = GameObject.Instantiate(group.transform.GetChild(0), group, false); // change to find by name
            go.SetSiblingIndex(index + ((index < 0) ? group.childCount : 0));

            go.GetComponentInChildren<TMP_Text>().text = text;
            go.GetComponent<Button>().onClick.RemoveAllListeners();
            go.GetComponent<Button>().onClick.AddListener(onClick);
        }
        /// <summary>
        /// Adds custom main menu buttons
        /// </summary>
        /// <param name="index">
        /// If greater than 0, just sets index.
        /// If negative - sets index from bottom starting from -1 as last element (elements_amount-index).
        /// </param>
        public static void AddPauseMenuButton(PauseMenuRoot menu, Action onClick, string text, int index = 0) {
            var group = menu.transform.Find("PauseUI/AdapterView (Buttons)");
            var go = GameObject.Instantiate(group.transform.GetChild(2), group, false); // change to find by name
            go.SetSiblingIndex(index + ((index < 0) ? group.childCount : 0));

            go.GetComponentInChildren<TMP_Text>().text = text;
            go.GetComponent<Button>().onClick.RemoveAllListeners();
            go.GetComponent<Button>().onClick.AddListener(onClick);
        }
    }
}

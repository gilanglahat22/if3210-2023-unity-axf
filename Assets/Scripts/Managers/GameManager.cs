using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Threading.Tasks;

public class GameManager : MonoBehaviour
{
        public GameObject cheatMenu;
        public PlayerMovement player;

        bool isCheatMenuOpen = false;

        public static bool isLevel1completed = false;
        public static bool isLevel2completed = false;
        public static bool isLevel3completed = false;
        public static bool isLevel4completed = false;

    // Start is called before the first frame update
        void Start() {
            cheatMenu.SetActive(false);
        }

        void PauseGame() {
            // isGamePaused = true;
            Time.timeScale = 0;
        }

        void ResumeGame() {
            // isGamePaused = false;
            Time.timeScale = 1;
        }

        void openCheatMenu() {
            isCheatMenuOpen = true;
            cheatMenu.SetActive(true);
            PauseGame();
        }

        public void closeCheatMenu() {
            isCheatMenuOpen = false;
            ResumeGame();
            cheatMenu.SetActive(false);
        }

        public void OpenCloseCheatMenu() {
            // Debug.Log(isCheatMenuOpen);
            if (isCheatMenuOpen) {
                closeCheatMenu();
            } else {
                openCheatMenu();
            }
        }
}

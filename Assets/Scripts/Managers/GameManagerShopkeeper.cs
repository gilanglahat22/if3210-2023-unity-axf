using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Threading.Tasks;

public class GameManagerShopkeeper : MonoBehaviour
{
        public GameObject shopkeeperMenu;
        public GameObject myCollider;
        public GameObject errorMessage;
        public PlayerMovement player;

        bool isShopkeeperOpen = false;
        // bool isGamePaused = false;
        bool isErrorMessageOpen = false;

    // Start is called before the first frame update
        void Start() {
            shopkeeperMenu.SetActive(false);
            errorMessage.SetActive(false);
        }

        void PauseGame() {
            // isGamePaused = true;
            Time.timeScale = 0;
        }

        void ResumeGame() {
            // isGamePaused = false;
            Time.timeScale = 1;
        }

        public void OpenShopkeeperMenu() {
            shopkeeperMenu.SetActive(true);
        }

        public void CloseShopkeeperMenu() {
            shopkeeperMenu.SetActive(false);
        }

        public void OpenCloseShopkeeper() {
            float dist = Vector3.Distance(myCollider.transform.position,player.transform.position);
            if(!isShopkeeperOpen) {
                if(dist<10) {
                    OpenShopkeeperMenu();
                    isShopkeeperOpen = true;
                    errorMessage.SetActive(false);
                } else {
                    if(isErrorMessageOpen) {
                        errorMessage.SetActive(false);
                        isErrorMessageOpen = false;
                    } else {
                        errorMessage.SetActive(true);
                        isErrorMessageOpen = true;
                    }
                }
            } else {
                CloseShopkeeperMenu();
                isShopkeeperOpen = false;
                errorMessage.SetActive(false);
            }
        }
}

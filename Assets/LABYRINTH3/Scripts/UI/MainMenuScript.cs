﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Labyrinth3.UI
{
    public class MainMenuScript : MonoBehaviour
    {
        void Start()
        {
            GoToMainMenu();
        }

        private void ToggleMenu(string menuName)
        {
            foreach (Transform child in transform)
                child.gameObject.SetActive(child.gameObject.name == menuName ? true : false);
        }

        public void StartGame()
        {
            SceneManager.LoadScene("lvl1");
        }

        public void GoToLevelSelect()
        {
            ToggleMenu("LevelMenu");
        }

        public void GoToMainMenu()
        {
            ToggleMenu("MainMenu");
        }
    }
}
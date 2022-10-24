using System;
using System.Collections;
using System.Collections.Generic;
using Labyrinth3.Game;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Labyrinth3.UI
{
    public class UIScript : MonoBehaviour
    {
        public Joystick joystick;
        public KeyGroupScript keyGroup;
        public PowerUpGroup powerUpGroup;
        public PauseMenu pauseMenu;

        public void OnMainMenuPressed()
        {
            SceneManager.LoadScene("MainMenu");
        }

        private void OnKeyPickup(KeyPickupEvent e)
        {
            keyGroup.AddKey();
        }

        private void OnSpeedUpPowerupPickup(SpeedUpPowerupPickupEvent e)
        {
            powerUpGroup.AddPowerUpRun();
        }

        private void OnTimePowerUpPickup(TimePowerupPickupEvent e)
        {
            powerUpGroup.AddPowerUpTime();
        }

        private void OnJumpBoostPickup(JumpBoostPowerupPickupEvent e)
        {
            powerUpGroup.AddPowerUpJump();
        }

        public void OnPauseMenuButtonPressed()
        {
            pauseMenu.ShowPauseMenu();
        }

        public void OnReturnToGameButtonPressed()
        {
            pauseMenu.HidePauseMenu();
        }

        public void OnRestartButtonClicked()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }


        // Start is called before the first frame update
        void Start()
        {
            Screen.orientation = ScreenOrientation.LandscapeRight;
            EventManager.AddListener<KeyPickupEvent>(OnKeyPickup);
            EventManager.AddListener<SpeedUpPowerupPickupEvent>(OnSpeedUpPowerupPickup);
            EventManager.AddListener<TimePowerupPickupEvent>(OnTimePowerUpPickup);
            EventManager.AddListener<JumpBoostPowerupPickupEvent>(OnJumpBoostPickup);
        }

        private void OnDestroy()
        {
            EventManager.RemoveListener<KeyPickupEvent>(OnKeyPickup);
            EventManager.RemoveListener<SpeedUpPowerupPickupEvent>(OnSpeedUpPowerupPickup);
            EventManager.RemoveListener<TimePowerupPickupEvent>(OnTimePowerUpPickup);
            EventManager.RemoveListener<JumpBoostPowerupPickupEvent>(OnJumpBoostPickup);
        }
    }
}
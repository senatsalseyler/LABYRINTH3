using System;
using Labyrinth3.Game;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Labyrinth3.Gameplay
{
    public class FinishLevel : MonoBehaviour
    {
        private int foundKeys = 0;
        public int keysNeedToTaken = 1;
        public AudioSource warning;

        private void OnKeyPickup(KeyPickupEvent e)
        {
            foundKeys++;
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("FinishLevel OnTriggerEnter" + foundKeys + keysNeedToTaken);
            warning.Play();

            if (foundKeys >= keysNeedToTaken)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }

        private void Start()
        {
            EventManager.AddListener<KeyPickupEvent>(OnKeyPickup);
        }
    }
}
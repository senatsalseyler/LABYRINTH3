using UnityEngine;

namespace Labyrinth3.UI
{
    public class PowerUpGroup : MonoBehaviour
    {
        public GameObject powerUpRunPrefab;
        public GameObject powerUpJumpPrefab;
        public GameObject powerUpTimePrefab;
        
        public void AddPowerUpRun()
        {
            powerUpRunPrefab.gameObject.SetActive(true);
        }

        public void AddPowerUpJump()
        {
            powerUpJumpPrefab.gameObject.SetActive(true);
        }

        public void AddPowerUpTime()
        {
            powerUpTimePrefab.gameObject.SetActive(true);
        }
    }
}
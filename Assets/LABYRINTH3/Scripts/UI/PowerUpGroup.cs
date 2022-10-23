using UnityEditor.SceneManagement;
using UnityEngine;

namespace Labyrinth3.UI
{
    public class PowerUpGroup : MonoBehaviour
    {
        public GameObject powerUpRunPrefab;
        public GameObject powerUpJumpPrefab;
        public GameObject powerUpTimePrefab;

        private void AddGameObject(GameObject gameObj)
        {
            Instantiate(gameObj, transform);
        }

        public void AddPowerUpRun()
        {
            AddGameObject(powerUpRunPrefab);
        }

        public void AddPowerUpJump()
        {
            AddGameObject(powerUpJumpPrefab);

        }

        public void AddPowerUpTime()
        {
            AddGameObject(powerUpTimePrefab);
        }
    }
}
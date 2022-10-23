using UnityEngine;
using UnityEngine.SceneManagement;

namespace Labyrinth3.UI
{
    public class PauseMenu : MonoBehaviour
    {
        public void HidePauseMenu()
        {
            transform.gameObject.SetActive(false);
        }

        public void ShowPauseMenu()
        {
            transform.gameObject.SetActive(true);
        }

        public void OnMainMenuPress()
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
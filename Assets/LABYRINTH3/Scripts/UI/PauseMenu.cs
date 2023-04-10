using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace Labyrinth3.UI
{
    public class PauseMenu : MonoBehaviour
    {
        public AudioMixer audioMixer;
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

        public void SetVolume(float volume)
        {
            audioMixer.SetFloat("volume", volume);
        }
        
    }
}
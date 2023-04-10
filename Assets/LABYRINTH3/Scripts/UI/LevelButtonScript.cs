using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Labyrinth3.UI
{
    public class LevelButtonScript : MonoBehaviour
    {
        public int level;

        public TMP_Text levelText;

        // Start is called before the first frame update
        void Start()
        {
            levelText.text = level.ToString();
        }

        // Update is called once per frame
        public void LoadLevel()
        {
            SceneManager.LoadScene("lvl" + level.ToString());
        }
    }
}
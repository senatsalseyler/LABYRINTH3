using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class finish_lvl : MonoBehaviour
{
    public Text textBox;
    public string textValue;

    private void OnTriggerEnter(Collider other)
    {
        if (GameObject.Find("key") == null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            textBox.text = textValue;
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class key_interaction : MonoBehaviour
{
    public Text textBox;
    public string textValue;


    private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.tag == "key")
            {
                Destroy(collision.gameObject);
                textBox.text = textValue;
            }
        }
}

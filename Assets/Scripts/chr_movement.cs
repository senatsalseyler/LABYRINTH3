using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class chr_movement : MonoBehaviour
{
    public GameObject player;
   
    private void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
            player.GetComponent<Transform>().position = new Vector3(player.GetComponent<Transform>().position.x - 5 * Time.deltaTime, player.GetComponent<Transform>().position.y, player.GetComponent<Transform>().position.z);
        }

        else if (Input.GetKey(KeyCode.A))
        {
            player.GetComponent<Transform>().position = new Vector3(player.GetComponent<Transform>().position.x, player.GetComponent<Transform>().position.y, player.GetComponent<Transform>().position.z + 5 *Time.deltaTime);
        }

        else if (Input.GetKey(KeyCode.W))
        {
            player.GetComponent<Transform>().position = new Vector3(player.GetComponent<Transform>().position.x + 5 * Time.deltaTime, player.GetComponent<Transform>().position.y, player.GetComponent<Transform>().position.z);

        }
        else if (Input.GetKey(KeyCode.D))
        {
            player.GetComponent<Transform>().position = new Vector3(player.GetComponent<Transform>().position.x, player.GetComponent<Transform>().position.y, player.GetComponent<Transform>().position.z - 5 * Time.deltaTime);

        }


    }

}

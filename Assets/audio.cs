using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audio : MonoBehaviour
{
    public AudioSource hit;

    void OnTriggerEnter(Collider other)
    {
        GetComponent<AudioSource>().Play();
    }

}

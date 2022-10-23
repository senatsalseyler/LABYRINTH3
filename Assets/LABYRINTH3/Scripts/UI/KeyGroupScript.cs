using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Labyrinth3.UI
{
    public class KeyGroupScript : MonoBehaviour
    {
        private GameObject[] keys;
        public GameObject keySprite;

        public void AddKey()
        {
            Instantiate(keySprite, transform);
        }

        public void RemoveAllKeys()
        {
            foreach (GameObject key in keys)
            {
                Destroy(key);
            }
        }

        public void RemoveKey()
        {
            Destroy(keys[keys.Length - 1]);
        }
    }
}
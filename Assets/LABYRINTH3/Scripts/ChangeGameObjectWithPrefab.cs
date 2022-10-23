using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[ExecuteInEditMode]
public class ChangeGameObjectWithPrefab : MonoBehaviour
{

        // List of GameObjects
        public GameObject prefab;
        private void Awake()
        {
            Vector3 position = gameObject.transform.position;
            Quaternion rotation = gameObject.transform.rotation;
            
            GameObject gameObj = PrefabUtility.InstantiatePrefab(prefab,gameObject.scene) as GameObject;
            
            gameObj.transform.position = position;
            gameObj.transform.rotation = rotation;
        }
}

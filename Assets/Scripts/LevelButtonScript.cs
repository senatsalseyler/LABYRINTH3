using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine;
public class LevelButtonScript : MonoBehaviour
{
    static int level = 0;
    private int currentLevel = 0;
    public TMP_Text levelText;
    // Start is called before the first frame update
    void Start()
    {
        currentLevel = level;
        level++;
        levelText.text = currentLevel.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

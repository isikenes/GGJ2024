using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YogurtController : MonoBehaviour
{
    int score=0;
    int scorePerClick = 1;
    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetInt("score", 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click()
    {
        score += scorePerClick;
        Debug.Log(score);
    }

    
}

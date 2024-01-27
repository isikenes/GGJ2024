using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Textefekt : MonoBehaviour
{
    public GameObject textefekt;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void tiklamaefekti()
    {
        Instantiate(textefekt, new Vector2(0,0), Quaternion.identity);
        

    }
}

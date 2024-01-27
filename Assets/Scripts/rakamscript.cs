using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rakamscript : MonoBehaviour
{
    public Rigidbody2D rb;
    void Start()
    {
        Destroy(gameObject, 3f);
        rb.AddForce(new Vector2(Random.Range(-250,250), 250));
        //transform.Translate(0, 0.01f,0);
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
        
    }
}

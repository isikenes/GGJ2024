using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rakamscript : MonoBehaviour
{
    public Rigidbody2D rb;
    void Start()
    {
        Destroy(gameObject, 2f);
        rb.AddForce(new Vector2(Random.Range(-100,100), 250));
        //transform.Translate(0, 0.01f,0);
    }

    // Update is called once per frame
    void Update()
    {
        
        
        
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rgd = gameObject.GetComponent<Rigidbody2D>();
        rgd.AddForce(new Vector2 (5,5));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blok : MonoBehaviour
{
    int can =0;
    
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.black;
    }
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        
        
            if (can == 3)
            {
                can--;
                gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            }
            else if (can == 2)
            {
                can--;
                gameObject.GetComponent<SpriteRenderer>().color = Color.magenta;
            }
            else if (can == 1)
            {
                can--;
                gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
            }
            else if (can == 0)
            {
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }

        
    }
}

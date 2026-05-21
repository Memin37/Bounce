using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hareket : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public float speed=0;
    float konum_x;
    float konum_y;
    float aci;
    bool topAtildiMi=false;

    private void Update()
    {
        if (!topAtildiMi)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (Camera.main.ScreenToWorldPoint(Input.mousePosition).y>-9f)
                {
                    konum_x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
                    konum_y = Camera.main.ScreenToWorldPoint(Input.mousePosition).y+9;
                    aci = Mathf.Atan2(konum_y, konum_x);
                    rb2D.AddForce(new Vector3(5*Mathf.Cos(aci), 5*Mathf.Sin(aci), 0) * speed);
                    topAtildiMi = true;     
                }
            }
        } 
    }
}

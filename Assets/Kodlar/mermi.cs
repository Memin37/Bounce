using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mermi : MonoBehaviour
{
    public Rigidbody2D fizik;
    Vector2 x = new Vector2(0, 0);
    float aci_x;
    float aci_y;
    float aci;
    Vector3 vec3;
    void Start()
    {
        
        fizik = GetComponent<Rigidbody2D>();
        fizik.AddForce(x,ForceMode2D.Impulse);

    }
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            vec3 = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            aci_y = vec3.y + 4;
            aci_x = vec3.x;
            aci = aci_x / aci_y;
            x = new Vector2(aci*5, 5 / aci);
            fizik.AddForce(x, ForceMode2D.Impulse);
            //Debug.Log(aci_y);
            //Debug.Log(aci_x);
            //Debug.Log(aci);
            Debug.Log(x);
        }
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "yokedici")
        {
            //Destroy(gameObject);
            fizik.AddForce(-x, ForceMode2D.Impulse);
        }
    }

}

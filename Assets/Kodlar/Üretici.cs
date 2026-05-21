using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Üretici : MonoBehaviour
{

    public GameObject oyuncu;
    public Rigidbody2D rb2d;
    public GameObject gosterge;
    float hiz = 20f;
    public List<GameObject> gostergeList;
    Vector3 ilkKonum;
    Vector3 ikinciKonum;
    Vector3 geçiciKonum;
    float açıX, açıY, konumX, konumY;
    private void Start()
    {
        ilkKonum = oyuncu.transform.position;
        geçiciKonum = ilkKonum;
        gostergeList = new List<GameObject>();
        Oluştur();
    }
    private void Oluştur() 
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject üretim = Instantiate(gosterge, Vector3.zero, Quaternion.identity);
            üretim.name = "Gösterge" + i.ToString();
            gostergeList.Add(üretim);
            üretim.SetActive(false);
        }
    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase==TouchPhase.Began)
            {
                ikinciKonum = Camera.main.ScreenToWorldPoint(touch.position);
                TopuYönlendir();
            }
            else if (touch.phase==TouchPhase.Moved)
            {
                ikinciKonum = Camera.main.ScreenToWorldPoint(touch.position);
            }
            else if (touch.phase == TouchPhase.Ended||Input.GetMouseButtonDown(0))
            {
                Ateşle(ikinciKonum-ilkKonum);
                for (int i = 0; i < 10; i++)
                {
                    gostergeList[i].SetActive(false);
                }
            }
            if (Mathf.Abs(ikinciKonum.y - geçiciKonum.y) > 0.1f && Mathf.Abs(ikinciKonum.x - geçiciKonum.x) > 0.1f)
            {
                TopuYönlendir();
            }

        }
    }

    private void Ateşle(Vector2 şiddet)
    {
        rb2d.AddForce(şiddet.normalized*hiz);
    }

    private void TopuYönlendir() 
    {
        float açı = Mathf.Atan2(ikinciKonum.y - ilkKonum.y, ikinciKonum.x - ilkKonum.x);
        açıX = Mathf.Cos(açı);
        açıY = Mathf.Sin(açı);

        konumX = ilkKonum.x;
        konumY = ilkKonum.y;
        ToplarıDiz();


    }
    public LayerMask mask;
    public bool dokunmaKontrol=true,dokunmaDuvar=false;
    private void ToplarıDiz() 
    {
        for (int i = 0; i < 10; i++)
        {
            if (dokunmaKontrol)
            {
                Collider2D col = Physics2D.OverlapCircle(new Vector2(konumX, konumY), gostergeList[i].transform.localScale.x + 0.1f, mask);
                if (col == null)
                {
                    dokunmaKontrol = true;
                }
                else if (col.CompareTag("MainCamera"))
                {
                    if (!dokunmaDuvar)
                    {
                        dokunmaKontrol = true;
                        açıX *= -1;
                        dokunmaDuvar = true;
                    }
                }
                else if (col.CompareTag("Blok"))
                {
                    dokunmaKontrol = false;
                }
            }
            
            konumX += açıX;
            konumY += açıY;
            gostergeList[i].transform.position = new Vector3(konumX, konumY, 0);
            if (dokunmaKontrol)
            {
                gostergeList[i].SetActive(true);
            }
            else 
            {
                gostergeList[i].SetActive(false);
            }

        }
    
    }
    public void Reset()
    {
        SceneManager.LoadScene("LevelTaslak");
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inflame : MonoBehaviour
{
    public GameObject fr;

    public GameObject LeftCollis;
    public GameObject RightCollis;
    public GameObject UpCollis;
    public GameObject DownCollis;

    public FireDetector fd;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "fire")
        {
            StartCoroutine(delay());
            for (int i = 0; i<4; i++)
            {
                boomFire(i);
            }
            Destroy(gameObject);
        }
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(0.5f);
    }
    
    public void boomFire(int windDir)
    {
        Vector3 nlocation;
        

        switch (windDir)
        {
            case 0://좌
                fd = LeftCollis.GetComponent<FireDetector>();
                nlocation = transform.position;
                nlocation.x -= 0.7f;
                if (fd.hit == false && nlocation.x >= -2.1f)
                {
                    Instantiate(fr, nlocation, transform.rotation);
                }

                break;
            case 1://우

                fd = RightCollis.GetComponent<FireDetector>();

                nlocation = transform.position;
                nlocation.x += 0.7f;
                if (fd.hit == false && nlocation.x <= 2.1f)
                {
                    Instantiate(fr, nlocation, transform.rotation);
                }
                break;
            case 2://상

                fd = UpCollis.GetComponent<FireDetector>();

                nlocation = transform.position;
                nlocation.y += 0.7f;


                if (fd.hit == false && nlocation.y <= 4.0f)
                {
                    Instantiate(fr, nlocation, transform.rotation);
                }
                break;
            case 3://하

                fd = DownCollis.GetComponent<FireDetector>();

                nlocation = transform.position;
                nlocation.y -= 0.7f;

                if (fd.hit == false && nlocation.y >= -1.4f)
                {
                    Instantiate(fr, nlocation, transform.rotation);
                }
                break;
            //case 4://중앙
            //
            //    fd = DownCollis.GetComponent<FireDetector>();
            //
            //    nlocation = transform.position;
            //
            //    Instantiate(fr, nlocation, transform.rotation);
            //
            //    break;
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharatorDetector : MonoBehaviour
{
    [SerializeField]
    private bool isFire;
    [SerializeField]
    private bool isRescue;
    [SerializeField]
    private bool isFlame;

    public Fire cdr;
    public Rescue res;
    public Inflame inf;


    public bool hitFire
    {
        get { return isFire; }
    }

    public bool hitRescue
    {
        get { return isRescue; }
    }

    public bool hitFlame
    {
        get { return isFlame;  }
    }

    // Start is called before the first frame update
    void Start()
    {
        isFire = false;
        isRescue = false;
        isFlame = false;

    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.tag == "fire")
        {
            isFire = true;
            cdr = collision.GetComponent<Fire>();
        }
        else if(collision.transform.tag == "rescue")
        {
            isRescue = true;
            res = collision.GetComponent<Rescue>();
        }
        else if (collision.transform.tag == "inflame")
        {
            isFlame = true;
            inf = collision.GetComponent<Inflame>();
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "fire")
        {
            isFire = false;
            cdr = null;
        }
        else if (collision.transform.tag == "rescue")
        {
            isRescue = false;
            res = null;
        }
        else if (collision.transform.tag == "inflame")
        {
            isFlame = false;
            inf = null;
        }
    }
}

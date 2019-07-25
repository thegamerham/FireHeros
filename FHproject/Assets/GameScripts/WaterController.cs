using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    Animator AT;
    public GameObject Waters;

    GameObject[] water;

    private void Start()
    {
        AT = GetComponent<Animator>();
    }

    public void waterAction(Vector3 pos)
    {
        Instantiate(Waters, pos, transform.rotation);
        AT.SetBool("firedie", true);
        water = GameObject.FindGameObjectsWithTag("water");
        Invoke("DestorWater", 0.4f);
        
    }

    void DestorWater()
    {
        if (water.Length != 0)
        {
            for (int i = 0; i < water.Length; i++)
            {
                Destroy(water[i]);
            }
        }
    }
}

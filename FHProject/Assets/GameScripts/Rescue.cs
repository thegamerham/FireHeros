using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rescue : MonoBehaviour
{
    public GameObject[] nowRescueCount;
    GameManager GM;

    private void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        nowRescueCount = GameObject.FindGameObjectsWithTag("rescue");
    }

    private void Update()
    {
        nowRescueCount = GameObject.FindGameObjectsWithTag("rescue");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "fire")
        {
            Destroy(gameObject);
            GM.rescueDieCount++;
        }
    }
}

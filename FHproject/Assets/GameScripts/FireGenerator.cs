using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGenerator : MonoBehaviour
{

    public GameObject[] fires; //생성된 불을 보관하는 배열

    WindDir WD;

    float span = 10.0f;
    float ranTime = 10.0f;


    int windDir;
    private void Awake()
    {
        this.fires = GameObject.FindGameObjectsWithTag("fire");
        this.WD = GameObject.Find("GameManager").GetComponent<WindDir>();
    }

    private void Update()
    {
        span -= Time.deltaTime;
        ranTime -= Time.deltaTime;

        if (span <= 0.0f)
        {
            //생성된 불 검색
            this.fires = GameObject.FindGameObjectsWithTag("fire");

            this.span = 10.0f;

            //WindDir에 저장된 배열에서 바람의 방향을 참조
            windDir = WD.wind();

            //불 생성
            createFires();

            //print(fires.Length); //불오브젝트가 잘 생성되는지 체크
        }
        
    }

    void createFires()
    {
        if (fires.Length < 70)
        {
            for (int i = 0; i < fires.Length; i++)
            {
                fires[i].GetComponent<Fire>().deffusionFire(windDir);
            }
        }
    }
}

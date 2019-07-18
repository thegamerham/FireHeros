using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindDir : MonoBehaviour
{
    public int[] WindList = new int[50];
    public Image img_dir;
    

    public int windWhere;
    int futureWind;
    int i = 0;

    float time = 10.0f;
    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < WindList.Length; i++)
        {
            WindList[i] = Random.Range(0, 4);
        }

        //시작 시 바람의 방향 알려줌
        futureWind = WindList[0];
        dir();
    }

    // Update is called once per frame
    void Update()
    {
        //10초 마다 10초 후의 바람 방향을 알려줌
        time -= Time.deltaTime;
        if(time <= 0.0f)
        {
            wind();
            dir();
            i++;
            time = 10f;
        }
    }

    //바람 방향 저장하는 배열
    public int wind()
    {
        windWhere = WindList[i];
        futureWind = WindList[i + 1];
        return windWhere;
    }

    //풍향계 방향 바꾸기. 다음에 번지는 방향을 알려줌
    public void dir()
    {
        if(futureWind == 0)
        {
            this.img_dir.transform.rotation = Quaternion.Euler(0, 0, -270);
        }
        else if (futureWind == 1)
        {
            this.img_dir.transform.rotation = Quaternion.Euler(0, 0, -90);
        }
        else if (futureWind == 2)
        {
            this.img_dir.transform.rotation = Quaternion.identity;
        }
        else if (futureWind == 3)
        {
            this.img_dir.transform.rotation = Quaternion.Euler(0, 0, -270);
        }

    }
}

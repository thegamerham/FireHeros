using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    //맵 속성
    public GameObject map; // 일반 맵
    public GameObject stair; // 계단 맵
    public GameObject entry; // 시작 포인트
    public GameObject[] mapCollect = new GameObject[80]; //맵 생성 후 배열에 저장
    int index = 0; //배열 인덱스

    GameObject stairs;
    GameObject maps;

    //맵 생성 기준 좌표
    float posX = -2.1f;
    float posY = -1.5f;

    //맵 생성
    void Start()
    {
        //세로
        for (int y = 0; y < 11; y++)
        {
            //가로
            for (int x = 0; x < 7; x++)
            {
                if (x == 3 && y != 0 && y != 10)
                {
                    //계단 맵
                    stairs = Instantiate(stair, new Vector3(posX, posY, 0), Quaternion.identity);
                    posX += 0.7f;
                }
                else if (x != 3 && y != 10 && y != 0)
                {
                    //일반 맵
                    maps = Instantiate(map, new Vector3(posX, posY, 0), Quaternion.identity);
                    posX += 0.7f;
                }
                else if (x == 3 && y == 0)
                {
                    //시작점
                    Instantiate(entry, new Vector3(0, -3.0f, 0), Quaternion.identity);
                }
                else if (x == 3 && y == 10)
                {
                    //옥상
                    Instantiate(entry, new Vector3(0, -3.0f, 0), Quaternion.identity);
                }

                //생성된 맵 배열에 저장
                if(stairs != null)
                {
                    mapCollect[index] = stairs;
                    index++;
                    stairs = null;
                }
                else if(maps != null)
                {
                    mapCollect[index] = maps;
                    index++;
                    maps = null;
                }
            }
            //좌표 초기화
            posX = -2.1f;
            posY += 0.7f;
        }
    }
}

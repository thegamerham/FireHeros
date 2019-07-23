using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    //맵 속성
    public GameObject map; // 일반 맵
    public GameObject stair; // 계단 맵
    public GameObject entry; // 시작 포인트
    public GameObject[] mapCollect = new GameObject[63]; //맵 생성 후 배열에 저장

    int index = 0; //맵 배열 인덱스

    //맵 공간 분할. 오브젝트 랜덤 배치를 위한
    int[] easy_main_map = {1, 2, 4, 5, 8, 9, 11, 12, 15, 16, 18, 19};
    int[] easy_side_map = {0, 6, 7, 13, 14, 20};
    int[] nomal_main_map = {22, 23, 25, 26, 29, 30, 32, 33, 36, 37, 39, 40};
    int[] nomal_side_map = {21, 27, 28, 34, 35, 41};
    int[] hard_main_map = {43, 44, 46, 47, 50, 51, 53, 54, 57, 58, 60, 61};
    int[] hard_side_map = {42, 48, 49, 55, 56, 62};
    
    //레벨디자인에 따른 불 오브젝트 갯수 할당
    public int easy_fire_Count = 0; // Easy 구역의 불 개수
    public int easyside_fire_Count = 0;
    public int nomal_fire_Count = 0; //Nomal 구역의 불 개수
    public int nomalside_fire_Count = 0;
    public int hard_fire_Count = 0; // Hard 구역의 불 개수
    public int hardside_fire_Count = 0;

    //레벨디자인에 따른 인화물질 오브젝트 갯수 할당
    public int easy_inflame_Count = 0; // Easy 구역의 불 개수
    public int easyside_inflame_Count = 0;
    public int nomal_inflame_Count = 0; //Nomal 구역의 불 개수
    public int nomalside_inflame_Count = 0;
    public int hard_inflame_Count = 0; // Hard 구역의 불 개수
    public int hardside_inflame_Count = 0;

    //레벨디자인에 따른 환자 오브젝트 갯수 할당
    public int easy_rescue_Count = 0; // Easy 구역의 불 개수
    public int easyside_rescue_Count = 0;
    public int nomal_rescue_Count = 0; //Nomal 구역의 불 개수
    public int nomalside_rescue_Count = 0;
    public int hard_rescue_Count = 0; // Hard 구역의 불 개수
    public int hardside_rescue_Count = 0;

    int rnd_fire; // 불 오브젝트 랜덤 위치 생성에 필요한 값
    int[] rnd_fire_List = new int[12];
    int rnd_inflame; // 인화물질 오브젝트 랜덤 위치 생성에 필요한 값
    int[] rnd_inflame_List = new int[12];
    int rnd_rescue; // 환자 오브젝트 랜덤 위치 생성에 필요한 값
    int[] rnd_rescue_List = new int[11];


    

    GameObject stairs; //맵 가운데
    GameObject maps; // 일반 맵
    public GameObject prf_fires; //불 오브젝트 프리펩
    public GameObject prf_flame; //인화물질 오브젝트 프리펩
    public GameObject prf_rescue; //환자 오브젝트 프리펩
    public GameObject GM;
    FireGenerator FG;
    public GameObject[] inflameList;
    GameObject[] FireInf;

    //맵 생성 기준 좌표
    float posX = -2.1f;
    float posY = -2.2f;

    //맵 생성
    void Awake()
    {
        CreateMap();
        

        main_Stage_Fire();
        side_Stage_Fire();
        FG = GameObject.Find("FireGenerator").GetComponent<FireGenerator>();
        FG.fires = GameObject.FindGameObjectsWithTag("fire");
        main_Stage_Inflame();
        side_Stage_Inflame();
        inflameList = GameObject.FindGameObjectsWithTag("inflame");
        FireInf = new GameObject[FG.fires.Length + inflameList.Length];
        System.Array.Copy(FG.fires, 0, FireInf, 0, FG.fires.Length);
        System.Array.Copy(inflameList, 0, FireInf, FG.fires.Length, inflameList.Length);

        main_Stage_Rescue();
        side_Stage_Rescue();
    }

    void CreateMap()
    {
        //세로
        for (int y = 0; y < 10; y++)
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
                    Instantiate(entry, new Vector3(0, -2.2f, 0), Quaternion.identity);
                }

                //생성된 맵 배열에 저장
                if (stairs != null)
                {
                    mapCollect[index] = stairs;
                    index++;
                    stairs = null;
                }
                else if (maps != null)
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
    
    void main_Stage_Fire()
    {
        //easy 범위에 불 생성
        if(easy_fire_Count !=0)
        {
            //생성 될 위치 잡기
            for (int e = 0; e < easy_fire_Count; e++)
            {
                //랜덤으로 위치 설정
                rnd_fire = easy_main_map[Random.Range(0, easy_main_map.Length)];
                rnd_fire_List[e] = rnd_fire;

                //중복 검사
                if (e != 0)
                {
                    for (int j = 0; j < e; j++)
                    {
                        if (rnd_fire_List[j] == rnd_fire)
                        {
                            e--;
                            break;
                        }
                    }
                }
            }

            //생성
            for (int e = 0; e < easy_fire_Count; e++)
            {
                Instantiate(prf_fires, mapCollect[rnd_fire_List[e]].transform.position, transform.rotation);
            }
        }

        //nomal 범위에 불 생성
        if (nomal_fire_Count != 0)
        {
            //생성 될 위치 잡기
            for (int e = 0; e < nomal_fire_Count; e++)
            {
                //랜덤으로 위치 설정
                rnd_fire = nomal_main_map[Random.Range(0, nomal_main_map.Length)];
                rnd_fire_List[e] = rnd_fire;

                //중복 검사
                if (e != 0)
                {
                    for (int j = 0; j < e; j++)
                    {
                        if (rnd_fire_List[j] == rnd_fire)
                        {
                            e--;
                            break;
                        }
                    }
                }
            }

            //생성
            for (int e = 0; e < nomal_fire_Count; e++)
            {
                Instantiate(prf_fires, mapCollect[rnd_fire_List[e]].transform.position, transform.rotation);
            }
        }

        //hard 범위에 불 생성
        if (hard_fire_Count != 0)
        {
            //생성 될 위치 잡기
            for (int e = 0; e < hard_fire_Count; e++)
            {
                //랜덤으로 위치 설정
                rnd_fire = hard_main_map[Random.Range(0, hard_main_map.Length)];
                rnd_fire_List[e] = rnd_fire;

                //중복 검사
                if (e != 0)
                {
                    for (int j = 0; j < e; j++)
                    {
                        if (rnd_fire_List[j] == rnd_fire)
                        {
                            e--;
                            break;
                        }
                    }
                }
            }

            //생성
            for (int e = 0; e < hard_fire_Count; e++)
            {
                Instantiate(prf_fires, mapCollect[rnd_fire_List[e]].transform.position, transform.rotation);
            }
        }
    }

    void side_Stage_Fire()
    {
        if (easyside_fire_Count != 0)
        {
            //생성 될 위치 잡기
            for (int e = 0; e < easyside_fire_Count; e++)
            {
                //랜덤으로 위치 설정
                rnd_fire = easy_side_map[Random.Range(0, easy_side_map.Length)];
                rnd_fire_List[e] = rnd_fire;

                //중복 검사
                if (e != 0)
                {
                    for (int j = 0; j < e; j++)
                    {
                        if (rnd_fire_List[j] == rnd_fire)
                        {
                            e--;
                            break;
                        }
                    }
                }
            }

            //생성
            for (int e = 0; e < easyside_fire_Count; e++)
            {
                Instantiate(prf_fires, mapCollect[rnd_fire_List[e]].transform.position, transform.rotation);
            }
        }

        if (nomalside_fire_Count != 0)
        {
            //생성 될 위치 잡기
            for (int e = 0; e < nomalside_fire_Count; e++)
            {
                //랜덤으로 위치 설정
                rnd_fire = nomal_side_map[Random.Range(0, nomal_side_map.Length)];
                rnd_fire_List[e] = rnd_fire;

                //중복 검사
                if (e != 0)
                {
                    for (int j = 0; j < e; j++)
                    {
                        if (rnd_fire_List[j] == rnd_fire)
                        {
                            e--;
                            break;
                        }
                    }
                }
            }

            //생성
            for (int e = 0; e < nomalside_fire_Count; e++)
            {
                Instantiate(prf_fires, mapCollect[rnd_fire_List[e]].transform.position, transform.rotation);
            }
        }

        if (hardside_fire_Count != 0)
        {
            //생성 될 위치 잡기
            for (int e = 0; e < hardside_fire_Count; e++)
            {
                //랜덤으로 위치 설정
                rnd_fire = hard_side_map[Random.Range(0, hard_side_map.Length)];
                rnd_fire_List[e] = rnd_fire;

                //중복 검사
                if (e != 0)
                {
                    for (int j = 0; j < e; j++)
                    {
                        if (rnd_fire_List[j] == rnd_fire)
                        {
                            e--;
                            break;
                        }
                    }
                }
            }

            //생성
            for (int e = 0; e < hardside_fire_Count; e++)
            {
                Instantiate(prf_fires, mapCollect[rnd_fire_List[e]].transform.position, transform.rotation);
            }
        }
    }

    void main_Stage_Inflame()
    {
        //easy 범위에 인화물질 생성
        if (easy_inflame_Count != 0)
        {
            //생성 될 위치 잡기
            for (int e = 0; e < easy_inflame_Count; e++)
            {
                //랜덤으로 위치 설정
                rnd_inflame = easy_main_map[Random.Range(0, easy_main_map.Length)];
                
                for (int fi = 0; fi < FG.fires.Length; fi++)
                {
                    if (FG.fires[fi].transform.position == mapCollect[rnd_inflame].transform.position)
                    {
                        e--;
                        break;
                    }
                    else if (FG.fires[fi].transform.position != mapCollect[rnd_inflame].transform.position)
                    {
                        rnd_inflame_List[e] = rnd_inflame;
                        //중복 검사
                        if (e != 0)
                        {
                            for (int j = 0; j < e; j++)
                            {
                                if ((rnd_inflame_List[j] == rnd_inflame))
                                {
                                    e--;
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            //생성
            for (int e = 0; e < easy_inflame_Count; e++)
            {
                Instantiate(prf_flame, mapCollect[rnd_inflame_List[e]].transform.position, transform.rotation);
            }
        }

        //nomal 범위에 인화물질 생성
        if (nomal_inflame_Count != 0)
        {
            //생성 될 위치 잡기
            for (int e = 0; e < nomal_inflame_Count; e++)
            {
                //랜덤으로 위치 설정
                rnd_inflame = nomal_main_map[Random.Range(0, nomal_main_map.Length)];

                for (int fi = 0; fi < FG.fires.Length; fi++)
                {
                    if (FG.fires[fi].transform.position == mapCollect[rnd_inflame].transform.position)
                    {
                        e--;
                        break;
                    }
                    else if (FG.fires[fi].transform.position != mapCollect[rnd_inflame].transform.position)
                    {
                        rnd_inflame_List[e] = rnd_inflame;
                        //중복 검사
                        if (e != 0)
                        {
                            for (int j = 0; j < e; j++)
                            {
                                if ((rnd_inflame_List[j] == rnd_inflame))
                                {
                                    e--;
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            //생성
            for (int e = 0; e < nomal_inflame_Count; e++)
            {
                Instantiate(prf_flame, mapCollect[rnd_inflame_List[e]].transform.position, transform.rotation);
            }
        }

        //hard 범위에 인화물질 생성
        if (hard_inflame_Count != 0)
        {
            //생성 될 위치 잡기
            for (int e = 0; e < hard_inflame_Count; e++)
            {
                //랜덤으로 위치 설정
                rnd_inflame = hard_main_map[Random.Range(0, hard_main_map.Length)];

                for (int fi = 0; fi < FG.fires.Length; fi++)
                {
                    if (FG.fires[fi].transform.position == mapCollect[rnd_inflame].transform.position)
                    {
                        e--;
                        break;
                    }
                    else if (FG.fires[fi].transform.position != mapCollect[rnd_inflame].transform.position)
                    {
                        rnd_inflame_List[e] = rnd_inflame;
                        //중복 검사
                        if (e != 0)
                        {
                            for (int j = 0; j < e; j++)
                            {
                                if ((rnd_inflame_List[j] == rnd_inflame))
                                {
                                    e--;
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            //생성
            for (int e = 0; e < hard_inflame_Count; e++)
            {
                Instantiate(prf_flame, mapCollect[rnd_inflame_List[e]].transform.position, transform.rotation);
            }
        }
    }

    void side_Stage_Inflame()
    {
        //easy 범위에 인화물질 생성
        if (easyside_inflame_Count != 0)
        {
            //생성 될 위치 잡기
            for (int e = 0; e < easyside_inflame_Count; e++)
            {
                //랜덤으로 위치 설정
                rnd_inflame = easy_side_map[Random.Range(0, easy_side_map.Length)];

                for (int fi = 0; fi < FG.fires.Length; fi++)
                {
                    if (FG.fires[fi].transform.position == mapCollect[rnd_inflame].transform.position)
                    {
                        e--;
                        break;
                    }
                    else if (FG.fires[fi].transform.position != mapCollect[rnd_inflame].transform.position)
                    {
                        rnd_inflame_List[e] = rnd_inflame;
                        //중복 검사
                        if (e != 0)
                        {
                            for (int j = 0; j < e; j++)
                            {
                                if ((rnd_inflame_List[j] == rnd_inflame))
                                {
                                    e--;
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            //생성
            for (int e = 0; e < easyside_inflame_Count; e++)
            {
                Instantiate(prf_flame, mapCollect[rnd_inflame_List[e]].transform.position, transform.rotation);
            }
        }

        //nomal 범위에 인화물질 생성
        if (nomalside_inflame_Count != 0)
        {
            //생성 될 위치 잡기
            for (int e = 0; e < nomalside_inflame_Count; e++)
            {
                //랜덤으로 위치 설정
                rnd_inflame = nomal_side_map[Random.Range(0, nomal_side_map.Length)];

                for (int fi = 0; fi < FG.fires.Length; fi++)
                {
                    if (FG.fires[fi].transform.position == mapCollect[rnd_inflame].transform.position)
                    {
                        e--;
                        break;
                    }
                    else if (FG.fires[fi].transform.position != mapCollect[rnd_inflame].transform.position)
                    {
                        rnd_inflame_List[e] = rnd_inflame;
                        //중복 검사
                        if (e != 0)
                        {
                            for (int j = 0; j < e; j++)
                            {
                                if ((rnd_inflame_List[j] == rnd_inflame))
                                {
                                    e--;
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            //생성
            for (int e = 0; e < nomalside_inflame_Count; e++)
            {
                Instantiate(prf_flame, mapCollect[rnd_inflame_List[e]].transform.position, transform.rotation);
            }
        }

        //hard 범위에 인화물질 생성
        if (hardside_inflame_Count != 0)
        {
            //생성 될 위치 잡기
            for (int e = 0; e < hardside_inflame_Count; e++)
            {
                //랜덤으로 위치 설정
                rnd_inflame = hard_side_map[Random.Range(0, hard_side_map.Length)];

                for (int fi = 0; fi < FG.fires.Length; fi++)
                {
                    if (FG.fires[fi].transform.position == mapCollect[rnd_inflame].transform.position)
                    {
                        e--;
                        break;
                    }
                    else if (FG.fires[fi].transform.position != mapCollect[rnd_inflame].transform.position)
                    {
                        rnd_inflame_List[e] = rnd_inflame;
                        //중복 검사
                        if (e != 0)
                        {
                            for (int j = 0; j < e; j++)
                            {
                                if ((rnd_inflame_List[j] == rnd_inflame))
                                {
                                    e--;
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            //생성
            for (int e = 0; e < hardside_inflame_Count; e++)
            {
                Instantiate(prf_flame, mapCollect[rnd_inflame_List[e]].transform.position, transform.rotation);
            }
        }
    }

    void main_Stage_Rescue()
    {
        //easy 범위에 환자 생성
        if (easy_rescue_Count != 0)
        {
            //생성 될 위치 잡기
            for (int e = 0; e < easy_rescue_Count; e++)
            {
                //랜덤으로 위치 설정
                rnd_rescue = easy_main_map[Random.Range(0, easy_main_map.Length)];
                
                for (int fi = 0; fi < FireInf.Length;  fi++)
                {
                    if (FireInf[fi].transform.position == mapCollect[rnd_rescue].transform.position)
                    {
                        e--;
                        break;
                    }
                    else if (FireInf[fi].transform.position != mapCollect[rnd_rescue].transform.position)
                    {
                        rnd_rescue_List[e] = rnd_rescue;
                        //중복 검사
                        if (e != 0)
                        {
                            for (int j = 0; j < e; j++)
                            {
                                if (rnd_rescue_List[j] == rnd_rescue)
                                {
                                    e--;
                                    break;
                                }
                            }
                        }
                        
                    }
                }
                
            }
            for (int e = 0; e < easy_rescue_Count; e++)
            {
                Instantiate(prf_rescue, mapCollect[rnd_rescue_List[e]].transform.position, transform.rotation);
            }
        }

        //nomal 범위에 환자 생성
        if (nomal_rescue_Count != 0)
        {
            //생성 될 위치 잡기
            for (int e = 0; e < nomal_rescue_Count; e++)
            {
                //랜덤으로 위치 설정
                rnd_rescue = nomal_main_map[Random.Range(0, nomal_main_map.Length)];

                for (int fi = 0; fi < FireInf.Length; fi++)
                {
                    if (FireInf[fi].transform.position == mapCollect[rnd_rescue].transform.position)
                    {
                        e--;
                        break;
                    }
                    else if (FireInf[fi].transform.position != mapCollect[rnd_rescue].transform.position)
                    {
                        rnd_rescue_List[e] = rnd_rescue;
                        //중복 검사
                        if (e != 0)
                        {
                            for (int j = 0; j < e; j++)
                            {
                                if (rnd_rescue_List[j] == rnd_rescue)
                                {
                                    e--;
                                    break;
                                }
                            }
                        }

                    }
                }

            }
            for (int e = 0; e < nomal_rescue_Count; e++)
            {
                Instantiate(prf_rescue, mapCollect[rnd_rescue_List[e]].transform.position, transform.rotation);
            }
        }

        //nomal 범위에 환자 생성
        if (hard_rescue_Count != 0)
        {
            //생성 될 위치 잡기
            for (int e = 0; e < hard_rescue_Count; e++)
            {
                //랜덤으로 위치 설정
                rnd_rescue = hard_main_map[Random.Range(0, hard_main_map.Length)];

                for (int fi = 0; fi < FireInf.Length; fi++)
                {
                    if (FireInf[fi].transform.position == mapCollect[rnd_rescue].transform.position)
                    {
                        e--;
                        break;
                    }
                    else if (FireInf[fi].transform.position != mapCollect[rnd_rescue].transform.position)
                    {
                        rnd_rescue_List[e] = rnd_rescue;
                        //중복 검사
                        if (e != 0)
                        {
                            for (int j = 0; j < e; j++)
                            {
                                if (rnd_rescue_List[j] == rnd_rescue)
                                {
                                    e--;
                                    break;
                                }
                            }
                        }

                    }
                }

            }
            for (int e = 0; e < hard_rescue_Count; e++)
            {
                Instantiate(prf_rescue, mapCollect[rnd_rescue_List[e]].transform.position, transform.rotation);
            }
        }
    }

    void side_Stage_Rescue()
    {
        //easy 범위에 환자 생성
        if (easyside_rescue_Count != 0)
        {
            //생성 될 위치 잡기
            for (int e = 0; e < easyside_rescue_Count; e++)
            {
                //랜덤으로 위치 설정
                rnd_rescue = easy_side_map[Random.Range(0, easy_side_map.Length)];

                for (int fi = 0; fi < FireInf.Length; fi++)
                {
                    if (FireInf[fi].transform.position == mapCollect[rnd_rescue].transform.position)
                    {
                        e--;
                        break;
                    }
                    else if (FireInf[fi].transform.position != mapCollect[rnd_rescue].transform.position)
                    {
                        rnd_rescue_List[e] = rnd_rescue;
                        //중복 검사
                        if (e != 0)
                        {
                            for (int j = 0; j < e; j++)
                            {
                                if (rnd_rescue_List[j] == rnd_rescue)
                                {
                                    e--;
                                    break;
                                }
                            }
                        }

                    }
                }

            }
            for (int e = 0; e < easyside_rescue_Count; e++)
            {
                Instantiate(prf_rescue, mapCollect[rnd_rescue_List[e]].transform.position, transform.rotation);
            }
        }

        //nomal 범위에 환자 생성
        if (nomalside_rescue_Count != 0)
        {
            //생성 될 위치 잡기
            for (int e = 0; e < nomalside_rescue_Count; e++)
            {
                //랜덤으로 위치 설정
                rnd_rescue = nomal_side_map[Random.Range(0, nomal_side_map.Length)];

                for (int fi = 0; fi < FireInf.Length; fi++)
                {
                    if (FireInf[fi].transform.position == mapCollect[rnd_rescue].transform.position)
                    {
                        e--;
                        break;
                    }
                    else if (FireInf[fi].transform.position != mapCollect[rnd_rescue].transform.position)
                    {
                        rnd_rescue_List[e] = rnd_rescue;
                        //중복 검사
                        if (e != 0)
                        {
                            for (int j = 0; j < e; j++)
                            {
                                if (rnd_rescue_List[j] == rnd_rescue)
                                {
                                    e--;
                                    break;
                                }
                            }
                        }

                    }
                }

            }
            for (int e = 0; e < nomalside_rescue_Count; e++)
            {
                Instantiate(prf_rescue, mapCollect[rnd_rescue_List[e]].transform.position, transform.rotation);
            }
        }

        //nomal 범위에 환자 생성
        if (hardside_rescue_Count != 0)
        {
            //생성 될 위치 잡기
            for (int e = 0; e < hardside_rescue_Count; e++)
            {
                //랜덤으로 위치 설정
                rnd_rescue = hard_side_map[Random.Range(0, hard_side_map.Length)];

                for (int fi = 0; fi < FireInf.Length; fi++)
                {
                    if (FireInf[fi].transform.position == mapCollect[rnd_rescue].transform.position)
                    {
                        e--;
                        break;
                    }
                    else if (FireInf[fi].transform.position != mapCollect[rnd_rescue].transform.position)
                    {
                        rnd_rescue_List[e] = rnd_rescue;
                        //중복 검사
                        if (e != 0)
                        {
                            for (int j = 0; j < e; j++)
                            {
                                if (rnd_rescue_List[j] == rnd_rescue)
                                {
                                    e--;
                                    break;
                                }
                            }
                        }

                    }
                }

            }
            for (int e = 0; e < hardside_rescue_Count; e++)
            {
                Instantiate(prf_rescue, mapCollect[rnd_rescue_List[e]].transform.position, transform.rotation);
            }
        }
    }
}

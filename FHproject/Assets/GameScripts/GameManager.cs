using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //캐릭터 정보
    public Text ap;
    public float playAP;
    public int playerDieCount = 0;
    public int rescueCount = 0;
    public int rescueDieCount = 0;

    public GameObject ClearPanel;
    public GameObject FailPanel;

    FireGenerator FG;
    SaveUserInfo SUI;
    MapManager MM;
    Rescue RES;

    float times = 10f;

    private void Awake()
    {
        SUI = GameObject.Find("SaveUserInfo").GetComponent<SaveUserInfo>();
    }

    private void Start()
    {
        FG = GameObject.Find("FireGenerator").GetComponent<FireGenerator>();
        MM = GameObject.Find("MapManager").GetComponent<MapManager>();
        RES = GameObject.Find("RescuGenerator").GetComponent<Rescue>();
        playAP = SUI.AP;
    }

    private void Update()
    {
        times -= Time.deltaTime;
        //10초 마다 AP 회복
        if(times <= 0f)
        {
            times = 10.0f;
            recoveryAP();
        }
        //AP 표시
        ap.text = string.Format("{0:f0}", playAP);

        

        GameClear();
        GameLose();
    }

    void recoveryAP()
    {
        playAP = SUI.AP;
    }

    void GameClear()
    {
        //화재를 모두 진화 시
        if (FG.fires.Length == 0)
        {
            Time.timeScale = 0;
            ClearPanel.SetActive(true);
        }
        //구조자를 모두 구조 시
        else if (RES.nowRescueCount.Length / 2 > rescueDieCount && RES.nowRescueCount.Length == 0)
        {
            Time.timeScale = 0;
            ClearPanel.SetActive(true);
        }
    }

    void GameLose()
    {
        //화재가 80%이상 진행 시
        if (FG.fires.Length >= 54)
        {
            Time.timeScale = 0;
            FailPanel.SetActive(true);
        }
        //캐릭터 1, 2가 사망 시
        else if (playerDieCount == 2)
        {
            Time.timeScale = 0;
            FailPanel.SetActive(true);
        }
        //총 구조자 중 반 이상이 사망 시
        else if (MM.RescueCount / 2 <= rescueDieCount)
        {
            Time.timeScale = 0;
            FailPanel.SetActive(true);
        }
    }

    public void btn_Stop()
    {
        Time.timeScale = 0;
    }

    public void btn_Start()
    {
        Time.timeScale = 1;
    }
}

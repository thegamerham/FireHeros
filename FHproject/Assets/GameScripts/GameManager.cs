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

    FireGenerator FG;
    SaveUserInfo SUI;
    float times = 10f;

    private void Awake()
    {
        SUI = GameObject.Find("SaveUserInfo").GetComponent<SaveUserInfo>();
    }

    private void Start()
    {
        FG = GameObject.Find("FireGenerator").GetComponent<FireGenerator>();
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

        if(FG.fires.Length == 0)
        {
            SceneManager.LoadScene("StageClear");
        }
        else if(FG.fires.Length >= 60)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    void recoveryAP()
    {
        playAP = SUI.AP;
    }
}

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

    Timer TM;
    FireGenerator FG;
    SaveUserInfo SUI;

    private void Awake()
    {
        SUI = GameObject.Find("SaveUserInfo").GetComponent<SaveUserInfo>();
    }

    private void Start()
    {
        TM = GameObject.Find("Timer").GetComponent<Timer>();
        FG = GameObject.Find("FireGenerator").GetComponent<FireGenerator>();
        playAP = SUI.AP;
    }

    private void Update()
    {
        //10초 마다 AP 회복
        if((int)TM.timer <= 0)
        {
            playAP = SUI.AP;
        }
        //AP 표시
        ap.text = string.Format("{0:f0}", "AP : " + playAP);

        if(FG.fires.Length == 0)
        {
            SceneManager.LoadScene("StageClear");
        }
        else if(FG.fires.Length >= 60)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{ // 게임 승패 액션만 변경했음.
    //캐릭터 정보
    public Text ap;
    public float playAP;
    public GameObject GameOver; // 게임 오버 팝업
    public GameObject clear; // 스테이지 클리어 팝업

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

        if (FG.fires.Length == 0)
        {
            //if(stage1 == stage1)
            // 스테이지 1 => Stage_1

            clear.SetActive(true);
            string _stage = SceneManager.GetActiveScene().name;



            switch (_stage) // case 에 stage는 실제로 진짜 플레이하는 화면(대화화면 말고)
            {//신의 이름을 받아와서 case 찾아가고 SUI의 stageclear의 현황을 보고 최고난이도 클리어시 한단계 더 높임.
                case "stage1_3":
                    if (SUI.stageclear == 0)
                    {
                        SUI.stageclear = 1;
                    }
                    //SceneLoad.stage1_4();
                    break;
                case "stage2_2":
                    if (SUI.stageclear == 1)
                    {
                        SUI.stageclear = 2;
                    }
                    //SceneLoad.stage2_3();
                    break;
                case "stage3_2":
                    if (SUI.stageclear == 2)
                    {
                        SUI.stageclear = 3;
                    }
                    //SceneLoad.stage3_3();
                    break;
                case "stage4_2":
                    if (SUI.stageclear == 3)
                    {
                        SUI.stageclear = 4;
                    }
                    //SceneLoad.stage4_3();
                    break;
                case "stage5_2":
                    if (SUI.stageclear == 4)
                    {
                        SUI.stageclear = 5;
                    }
                    //SceneLoad.stage5_3();
                    break;
                case "stage6_2":

                    if (SUI.stageclear == 5)
                    {
                        SUI.stageclear = 6;
                    }
                    //SceneLoad.stage6_3();
                    break;
                case "stage7_2":
                    if (SUI.stageclear == 6)
                    {
                        SUI.stageclear = 7;
                    }
                    //SceneLoad.stage7_3();
                    break;
                case "stage8_2":
                    if (SUI.stageclear == 7)
                    {
                        SUI.stageclear = 8;
                    }
                    //SceneLoad.stage8_3();
                    break;



                case "stage9_2":
                    if (SUI.stageclear == 8)
                    {
                        SUI.stageclear = 9;
                    }
                    //SceneLoad,stage9_3();
                    break;

                case "stage10_2":
                    if (SUI.stageclear == 9)
                    {
                        SUI.stageclear = 10;
                    }
                    //SceneLoad.stage10_3();
                    break;
                case "stage11_2":
                    if (SUI.stageclear == 10)
                    {
                        SUI.stageclear = 11;
                    }
                    //SceneLoad.stage11_3();
                    break;

                default:
                    break;
            }
        }
        else if (FG.fires.Length >= 60)
        {
            GameOver.SetActive(true);
        }
    }

    void recoveryAP()
    {
        playAP = SUI.AP;
    }
}

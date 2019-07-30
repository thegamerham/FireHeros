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
            //Time.timeScale = 0;
            ClearPanel.SetActive(true);
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
        
        //구조자를 모두 구조 시
        else if (RES.nowRescueCount.Length / 2 > rescueDieCount && RES.nowRescueCount.Length == 0)
        {
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

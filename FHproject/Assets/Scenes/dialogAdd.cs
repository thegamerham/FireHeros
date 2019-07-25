using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dialogAdd : MonoBehaviour
{
    SaveUserInfo SUI;
    public GameObject skip;
    public GameObject skipTrigger;
    private void Awake()
    {
        SUI = GameObject.Find("SaveUserInfo").GetComponent<SaveUserInfo>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    private void Update()
    {   //씬이름 비교해서 스킵버튼 활성화
         string _stage = SceneManager.GetActiveScene().name;
         switch (_stage)
         {

            //before 씬 스킵버튼활성화
            case "stage1_1":
                if (SUI.stageclear >= 1)
                {
                    skip.SetActive(SUI.stageclear >= 1 ? true : false);
                }
                break;
            case "stage1_2":
                 if(SUI.stageclear >=1)
                 {
                     skip.SetActive(SUI.stageclear >= 1 ? true : false);
                 }
                 break;
             case "stage2_1":
                 if (SUI.stageclear >= 2)
                 {
                     skip.SetActive(SUI.stageclear >= 2 ? true : false);
                 }
                 break;
             case "stage3_1":
                 if (SUI.stageclear >= 3)
                 {
                     skip.SetActive(SUI.stageclear >= 3 ? true : false);
                 }
                 break;
             case "stage4_1":
                 if (SUI.stageclear >= 4)
                 {
                     skip.SetActive(SUI.stageclear >= 4 ? true : false);
                 }
                 break;
             case "stage5_1":
                 if (SUI.stageclear >= 5)
                 {
                     skip.SetActive(SUI.stageclear >= 5 ? true : false);
                 }
                 break;
             case "stage6_1":
                 if (SUI.stageclear >= 6)
                 {
                     skip.SetActive(SUI.stageclear >= 6 ? true : false);
                 }
                 break;
             case "stage7_1":
                 if (SUI.stageclear >= 7)
                 {
                     skip.SetActive(SUI.stageclear >= 7 ? true : false);
                 }
                 break;
             case "stage8_1":
                 if (SUI.stageclear >= 8)
                 {
                     skip.SetActive(SUI.stageclear >= 8 ? true : false);
                 }
                 break;
             case "stage9_1":
                if (SUI.stageclear >= 9)
                 {
                     skip.SetActive(SUI.stageclear >= 9 ? true : false);
                 }
                 break;
             case "stage10_1":
                 if (SUI.stageclear >= 10)
                 {
                     skip.SetActive(SUI.stageclear >= 10 ? true : false);
                 }
                 break;
             case "stage11_1":
                 if (SUI.stageclear >= 11)
                 {
                     skip.SetActive(SUI.stageclear >= 11 ? true : false);
                 }
                 break;

            // 여기부터 after scene 스킵 버튼 활성화

            case "stage1_4":
                  if(SUI.afterSkip >= 1)
                {
                    skip.SetActive(SUI.stageclear >= 1 ? true : false);
                }
                break;
            case "stage2_3":
                  if (SUI.afterSkip >= 2)
                {
                    skip.SetActive(SUI.stageclear >= 2 ? true : false);
                }
                break;
            case "stage3_3":
                  if (SUI.afterSkip >= 3)
                {
                    skip.SetActive(SUI.stageclear >= 3 ? true : false);
                }
                break;
            case "stage4_3":
                  if (SUI.afterSkip >= 4)
                {
                    skip.SetActive(SUI.stageclear >= 4 ? true : false);
                }
                break;
            case "stage5_3":
                  if (SUI.afterSkip >= 5)
                {
                    skip.SetActive(SUI.stageclear >= 5 ? true : false);
                }
                break;
            case "stage6_3":
                  if (SUI.afterSkip >= 6)
                {
                    skip.SetActive(SUI.stageclear >= 6 ? true : false);
                }
                break;
            case "stage7_3":
                  if (SUI.afterSkip >= 7)
                {
                    skip.SetActive(SUI.stageclear >= 7 ? true : false);
                }
                break;
            case "stage8_3":
                    if (SUI.afterSkip >= 8)
                {
                    skip.SetActive(SUI.stageclear >= 8 ? true : false);
                }
                break;
            case "stage9_3":
                 if (SUI.afterSkip >= 9)
                {
                    skip.SetActive(SUI.stageclear >= 9 ? true : false);
                }
                break;
            case "stage10_3":
                 if (SUI.afterSkip >= 10)
                {
                    skip.SetActive(SUI.stageclear >= 10 ? true : false);
                }
                break;
            case "stage11_3":
                if (SUI.afterSkip  >= 11)
                {
                    skip.SetActive(SUI.stageclear >= 11 ? true : false);
                }
                break;

                



        }

    }

    // Update is called once per frame
    public void skipScene()
    {   //스킵 버튼을 통해 사용되는 함수. 씬이름 조건으로 들어가서 스테이지명 비교한 뒤 clear수치가 더 높으면 이동.

        string _stage = SceneManager.GetActiveScene().name;



        switch (_stage) // case 에 stage는 실제로 진짜 플레이하는 화면(대화화면 말고)
        {
            case "stage1_1":
             //   if (SUI.stageclear >= 1)
                {
                    this.skipTrigger.GetComponent<SceneLoad>().stage1_3();
                }
                break;
            case "stage1_2":
             //   if (SUI.stageclear >= 1)
                {
                    this.skipTrigger.GetComponent<SceneLoad>().stage1_3();
                }
                break;

            case "stage2_1":
             //   if (SUI.stageclear >= 2)
                {
                    this.skipTrigger.GetComponent<SceneLoad>().stage2_2();
                }
                break;
            case "stage3_1":
              //  if (SUI.stageclear >= 3)
                {
                    this.skipTrigger.GetComponent<SceneLoad>().stage3_2();
                }
                break;
            case "stage4_1":
              //  if (SUI.stageclear >= 4)
                {
                    this.skipTrigger.GetComponent<SceneLoad>().stage4_2();
                }
                break;
            case "stage5_1":
              //  if (SUI.stageclear >= 5)
                {
                    this.skipTrigger.GetComponent<SceneLoad>().stage5_2();
                }
                break;
            case "stage6_1":
              //  if (SUI.stageclear >= 6)
                {
                    this.skipTrigger.GetComponent<SceneLoad>().stage6_2();
                }
                break;
            case "stage7_1":
              //  if (SUI.stageclear >= 7)
                {
                    this.skipTrigger.GetComponent<SceneLoad>().stage7_2();
                }
                break;
            case "stage8_1":
              //  if (SUI.stageclear >= 8)
                {
                    this.skipTrigger.GetComponent<SceneLoad>().stage8_2();
                }
                break;
            case "stage9_1":
              //  if (SUI.stageclear >= 9)
                {
                    this.skipTrigger.GetComponent<SceneLoad>().stage9_2();
                }
                break;
            case "stage10_1":
               // if (SUI.stageclear >= 10)
                {
                    this.skipTrigger.GetComponent<SceneLoad>().stage10_2();
                }
                break;
            case "stage11_1":
                //if (SUI.stageclear >= 11)
                {
                    this.skipTrigger.GetComponent<SceneLoad>().stage11_2();
                }
                break;




            case "stage1_4": // afterSkip으로 넣으면 1스테이지 skip을 눌러야 afterskip이 Scene타고 1이 되는데 조건문이 1이상이라 실행이 막힘. 스킵버튼은 stageclear조건에 충족하지만 활성화는 afterSkip이기에 버튼이 없어서 못누름
                if (SUI.stageclear >= 1)
                {
                    this.skipTrigger.GetComponent<SceneLoad>().Scene();
                }
                break;

            case "stage2_3":
                if (SUI.stageclear >= 2)
                {
                    this.skipTrigger.GetComponent<SceneLoad>().Scene();
                }
                break;
            case "stage3_3":
                if (SUI.stageclear >= 3)
                {
                    this.skipTrigger.GetComponent<SceneLoad>().Scene();
                }
                    break;
            case "stage4_3":
                if (SUI.stageclear >= 4)
                {
                    this.skipTrigger.GetComponent<SceneLoad>().Scene();
                }
                break;
            case "stage5_3":
                if (SUI.stageclear >= 5)
                {
                    this.skipTrigger.GetComponent<SceneLoad>().Scene();
                }
                break;
            case "stage6_3":
                if (SUI.stageclear >= 6)
                {
                    this.skipTrigger.GetComponent<SceneLoad>().Scene();
                }
                break;
            case "stage7_3":
                if (SUI.stageclear >= 7)
                {
                    this.skipTrigger.GetComponent<SceneLoad>().Scene();
                }
                break;
            case "stage8_3":
                if (SUI.stageclear >= 8)
                {
                    this.skipTrigger.GetComponent<SceneLoad>().Scene();
                }
                break;
            case "stage9_3":
                if (SUI.stageclear >= 9)
                {
                    this.skipTrigger.GetComponent<SceneLoad>().Scene();
                }
                break;
            case "stage10_3":
                if (SUI.stageclear >= 10)
                {
                    this.skipTrigger.GetComponent<SceneLoad>().Scene();
                }
                break;
            case "stage11_3":
                if (SUI.stageclear >= 11)
                {
                    this.skipTrigger.GetComponent<SceneLoad>().Scene();
                }
                break;
        





            default:
                break;
        }



    }

}
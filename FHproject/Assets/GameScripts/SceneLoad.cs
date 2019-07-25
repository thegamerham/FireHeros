using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoad : MonoBehaviour
{//1-3을 제외하면 전부다 2가 플레이씬
    public Image fadeImage;
    public GameObject fadeOnOff;
    SaveUserInfo SUI;


    private void Awake()
    {
        SUI = GameObject.Find("SaveUserInfo").GetComponent<SaveUserInfo>();
    }
    void Start()
    {
        fadeImage.canvasRenderer.SetAlpha(1.0f);
        
        fadeImage.CrossFadeAlpha(0, 2, false);
        
        Invoke("panelCancel", 2f);
        
    }

    public void Scene() // 2초뒤 Scenecall을 부른다.
    {
        fadeOnOff.SetActive(true);  
        fadeImage.canvasRenderer.SetAlpha(0.0f);
        
        fadeImage.CrossFadeAlpha(1, 2, false);

        string _stage = SceneManager.GetActiveScene().name;
        switch (_stage)
        {//후속 스킵 스위치 온. after씬에서 로비로 가는 scene() 한번 실행시 최고 스킵가능한 스테이지 갱신. 액션은 dialogAdd에 있음
            case "stage1_4":
                if (SUI.stageclear >= 1)
                {
                    SUI.afterSkip = 1;
                }
                break;
            case "stage2_3":
                if (SUI.stageclear >= 2)
                {
                    SUI.afterSkip = 2;
                }
                break;
            case "stage3_3":
                if (SUI.stageclear >= 3)
                {
                    SUI.afterSkip = 3;
                }

                break;
            case "stage4_3":
                if (SUI.stageclear >= 4)
                {
                    SUI.afterSkip = 4;
                }
                break;
            case "stage5_3":
                if (SUI.stageclear >= 5)
                {
                    SUI.afterSkip = 5;
                }
                break;
            case "stage6_3":
                if (SUI.stageclear >= 6)
                {
                    SUI.afterSkip = 6;
                }
                break;
            case "stage7_3":
                if (SUI.stageclear >= 7)
                {
                    SUI.afterSkip = 7;
                }
                break;
            case "stage8_3":
                if (SUI.stageclear >= 8)
                {
                    SUI.afterSkip = 8;
                }
                break;
            case "stage9_3":
                if (SUI.stageclear >= 9)
                {
                    SUI.afterSkip = 9;
                }
                break;
            case "stage10_3":
                if (SUI.stageclear >= 10)
                {
                    SUI.afterSkip = 10;
                }
                break;
            case "stage11_3":
                if (SUI.stageclear >= 11)
                {
                    SUI.afterSkip = 11;
                }
                break;
        }


        Invoke("Scenecall", 2f);  
    }
    public void Scenecall()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void stage1_1()
    {

        fadeOnOff.SetActive(true);
        fadeImage.canvasRenderer.SetAlpha(0.0f);
        fadeImage.CrossFadeAlpha(1, 2, false);
        
        Invoke("stage1_1call", 2f);
    }
    public void stage1_2()
    {
        fadeOnOff.SetActive(true);
        fadeImage.canvasRenderer.SetAlpha(0.0f);
        fadeImage.CrossFadeAlpha(1, 2, false);
        
        Invoke("stage1_2call", 2f);
    }
    public void stage1_3()
    {
        
        fadeOnOff.SetActive(true);
        fadeImage.canvasRenderer.SetAlpha(0.0f);
        fadeImage.CrossFadeAlpha(1, 2, false);
        
        Invoke("stage1_3call", 2f);
        
    }
    public void stage1_4()
    {
        fadeOnOff.SetActive(true);
        fadeImage.canvasRenderer.SetAlpha(0.0f);
        fadeImage.CrossFadeAlpha(1, 2, false);
       
        Invoke("stage1_4call", 2f);
    }
    public void stage2_1()
    {
        fadeOnOff.SetActive(true);
        fadeImage.canvasRenderer.SetAlpha(0.0f);
        fadeImage.CrossFadeAlpha(1, 2, false);
       
        Invoke("stage2_1call", 2f);
    }
    public void stage2_2()
    {
        fadeOnOff.SetActive(true);
        fadeImage.canvasRenderer.SetAlpha(0.0f);
        fadeImage.CrossFadeAlpha(1, 2, false);
       
        Invoke("stage2_2call", 2f);
    }
    public void stage2_3()
    {
        fadeOnOff.SetActive(true);
        fadeImage.canvasRenderer.SetAlpha(0.0f);
        fadeImage.CrossFadeAlpha(1, 2, false);
       
        Invoke("stage2_3call", 2f);
    }
    public void stage3_1()
    {
        fadeOnOff.SetActive(true);
        fadeImage.canvasRenderer.SetAlpha(0.0f);
        fadeImage.CrossFadeAlpha(1, 2, false);
        
        Invoke("stage3_1call", 2f);
    }
    public void stage3_2()
    {
        fadeOnOff.SetActive(true);
        fadeImage.canvasRenderer.SetAlpha(0.0f);
        fadeImage.CrossFadeAlpha(1, 2, false);
       
        Invoke("stage3_2call", 2f);
    }
    public void stage3_3()
    {
        fadeOnOff.SetActive(true);
        fadeImage.canvasRenderer.SetAlpha(0.0f);
        fadeImage.CrossFadeAlpha(1, 2, false);
        
        Invoke("stage3_3call", 2f);
    }
    public void stage4_1()
    {
        fadeOnOff.SetActive(true);
        fadeImage.canvasRenderer.SetAlpha(0.0f);
        fadeImage.CrossFadeAlpha(1, 2, false);
        
        Invoke("stage4_1call", 2f);
    }
    public void stage4_2()
    {
        fadeOnOff.SetActive(true);
        fadeImage.canvasRenderer.SetAlpha(0.0f);
        fadeImage.CrossFadeAlpha(1, 2, false);
      
        Invoke("stage4_2call", 2f);
    }
    public void stage4_3()
    {
        fadeOnOff.SetActive(true);
        fadeImage.canvasRenderer.SetAlpha(0.0f);
        fadeImage.CrossFadeAlpha(1, 2, false);
       
        Invoke("stage4_3call", 2f);
    }
    public void stage5_1()
    {
        fadeOnOff.SetActive(true);
        fadeImage.canvasRenderer.SetAlpha(0.0f);
        fadeImage.CrossFadeAlpha(1, 2, false);
       
        Invoke("stage5_1call", 2f);
    }
    public void stage5_2()
    {
        fadeOnOff.SetActive(true);
        fadeImage.canvasRenderer.SetAlpha(0.0f);
        fadeImage.CrossFadeAlpha(1, 2, false);
       
        Invoke("stage5_2call", 2f);
    }
    public void stage5_3()
    {
        fadeOnOff.SetActive(true);
        fadeImage.canvasRenderer.SetAlpha(0.0f);
        fadeImage.CrossFadeAlpha(1, 2, false);
       
        Invoke("stage5_3call", 2f);
    }
    public void stage6_1()
    {
        fadeOnOff.SetActive(true);
        fadeImage.canvasRenderer.SetAlpha(0.0f);
        fadeImage.CrossFadeAlpha(1, 2, false);
       
        Invoke("stage6_1call", 2f);
    }
    public void stage6_2()
    {
        fadeOnOff.SetActive(true);
        fadeImage.canvasRenderer.SetAlpha(0.0f);
        fadeImage.CrossFadeAlpha(1, 2, false);
        
        Invoke("stage6_2call", 2f);
    }
    public void stage6_3()
    {
        fadeOnOff.SetActive(true);
        fadeImage.canvasRenderer.SetAlpha(0.0f);
        fadeImage.CrossFadeAlpha(1, 2, false);
       
        Invoke("stage6_3call", 2f);
    }
    public void stage7_1()
    {
        fadeOnOff.SetActive(true);
        fadeImage.canvasRenderer.SetAlpha(0.0f);
        fadeImage.CrossFadeAlpha(1, 2, false);
        
        Invoke("stage7_1call", 2f);
    }
    public void stage7_2()
    {
        fadeOnOff.SetActive(true);
        fadeImage.canvasRenderer.SetAlpha(0.0f);
        fadeImage.CrossFadeAlpha(1, 2, false);
        
        Invoke("stage7_2call", 2f);
    }
    public void stage7_3()
    {
        fadeOnOff.SetActive(true);
        fadeImage.canvasRenderer.SetAlpha(0.0f);
        fadeImage.CrossFadeAlpha(1, 2, false);
       
        Invoke("stage7_3call", 2f);
    }
    public void stage8_1()
    {
        fadeOnOff.SetActive(true);
        fadeImage.canvasRenderer.SetAlpha(0.0f);
        fadeImage.CrossFadeAlpha(1, 2, false);
       
        Invoke("stage8_1call", 2f);
    }
    public void stage8_2()
    {
        fadeOnOff.SetActive(true);
        fadeImage.canvasRenderer.SetAlpha(0.0f);
        fadeImage.CrossFadeAlpha(1, 2, false);
        
        Invoke("stage8_2call", 2f);
    }
    public void stage8_3()
    {
        fadeOnOff.SetActive(true);
        fadeImage.canvasRenderer.SetAlpha(0.0f);
        fadeImage.CrossFadeAlpha(1, 2, false);
       
        Invoke("stage8_3call", 2f);
    }
    public void stage9_1()
    {
        fadeOnOff.SetActive(true);
        fadeImage.canvasRenderer.SetAlpha(0.0f);
        fadeImage.CrossFadeAlpha(1, 2, false);
       
        Invoke("stage9_1call", 2f);
    }
    public void stage9_2()
    {
        fadeOnOff.SetActive(true);
        fadeImage.canvasRenderer.SetAlpha(0.0f);
        fadeImage.CrossFadeAlpha(1, 2, false);
       
        Invoke("stage9_2call", 2f);
    }
    public void stage9_3()
    {
        fadeOnOff.SetActive(true);
        fadeImage.canvasRenderer.SetAlpha(0.0f);
        fadeImage.CrossFadeAlpha(1, 2, false);
        
        Invoke("stage9_3call", 2f);
    }
    public void stage10_1()
    {
        fadeOnOff.SetActive(true);
        fadeImage.canvasRenderer.SetAlpha(0.0f);
        fadeImage.CrossFadeAlpha(1, 2, false);
        
        Invoke("stage10_1call", 2f);
    }
    public void stage10_2()
    {
        fadeOnOff.SetActive(true);
        fadeImage.canvasRenderer.SetAlpha(0.0f);
        fadeImage.CrossFadeAlpha(1, 2, false);
       
        Invoke("stage10_2call", 2f);
    }
    public void stage10_3()
    {
        fadeOnOff.SetActive(true);
        fadeImage.canvasRenderer.SetAlpha(0.0f);
        fadeImage.CrossFadeAlpha(1, 2, false);
        
        Invoke("stage10_3call", 2f);
    }
    public void stage11_1()
    {
        fadeOnOff.SetActive(true);
        fadeImage.canvasRenderer.SetAlpha(0.0f);
        fadeImage.CrossFadeAlpha(1, 2, false);
        
        Invoke("stage11_1call", 2f);
    }
    public void stage11_2()
    {
        fadeOnOff.SetActive(true);
        fadeImage.canvasRenderer.SetAlpha(0.0f);
        fadeImage.CrossFadeAlpha(1, 2, false);
        
        Invoke("stage11_2call", 2f);
    }
    public void stage11_3()
    {
        fadeOnOff.SetActive(true);
        fadeImage.canvasRenderer.SetAlpha(0.0f);
        fadeImage.CrossFadeAlpha(1, 2, false);
        
        Invoke("stage11_3call", 2f);
    }
    public void panelCancel()
    {
        
        fadeOnOff.SetActive(false);
        
    }

















    public void stage1_1call()
    {

        SceneManager.LoadScene("stage1_1");
    }
    public void stage1_2call()
    {

        SceneManager.LoadScene("stage1_2");
    }
    public void stage1_3call()
    {

        SceneManager.LoadScene("Stage1_3");
    }
    public void stage1_4call()
    {

        SceneManager.LoadScene("Stage1_4");
    }
    public void stage2_1call()
    {

        SceneManager.LoadScene("Stage2_1");
    }
    public void stage2_2call()
    {

        SceneManager.LoadScene("Stage2_2");
    }
    public void stage2_3call()
    {

        SceneManager.LoadScene("Stage2_3");
    }
    public void stage3_1call()
    {

        SceneManager.LoadScene("Stage3_1");
    }
    public void stage3_2call()
    {
        SceneManager.LoadScene("Stage3_2");
    }
    public void stage3_3call()
    {
        SceneManager.LoadScene("Stage3_3");
    }
    public void stage4_1call()
    {
        SceneManager.LoadScene("Stage4_1");
    }
    public void stage4_2call()
    {
        SceneManager.LoadScene("Stage4_2");
    }
    public void stage4_3call()
    {
        SceneManager.LoadScene("Stage4_3");
    }
    public void stage5_1call()
    {
        SceneManager.LoadScene("Stage5_1");
    }
    public void stage5_2call()
    {
        SceneManager.LoadScene("Stage5_2");
    }
    public void stage5_3call()
    {
        SceneManager.LoadScene("Stage5_3");
    }
    public void stage6_1call()
    {
        SceneManager.LoadScene("Stage6_1");
    }
    public void stage6_2call()
    {
        SceneManager.LoadScene("Stage6_2");
    }
    public void stage6_3call()
    {
        SceneManager.LoadScene("Stage6_3");
    }
    public void stage7_1call()
    {
        SceneManager.LoadScene("Stage7_1");
    }
    public void stage7_2call()
    {
        SceneManager.LoadScene("Stage7_2");
    }
    public void stage7_3call()
    {
        SceneManager.LoadScene("Stage7_3");
    }
    public void stage8_1call()
    {
        SceneManager.LoadScene("Stage8_1");
    }
    public void stage8_2call()
    {
        SceneManager.LoadScene("Stage8_2");
    }
    public void stage8_3call()
    {
        SceneManager.LoadScene("Stage8_3");
    }
    public void stage9_1call()
    {
        SceneManager.LoadScene("Stage9_1");
    }
    public void stage9_2call()
    {
        SceneManager.LoadScene("Stage9_2");
    }
    public void stage9_3call()
    {
        SceneManager.LoadScene("Stage9_3");
    }
    public void stage10_1call()
    {
        SceneManager.LoadScene("Stage10_1");
    }
    public void stage10_2call()
    {
        SceneManager.LoadScene("Stage10_2");
    }
    public void stage10_3call()
    {
        SceneManager.LoadScene("Stage10_3");
    }
    public void stage11_1call()
    {
        SceneManager.LoadScene("Stage11_1");
    }
    public void stage11_2call()
    {
        SceneManager.LoadScene("Stage11_2");
    }
    public void stage11_3call()
    {
        SceneManager.LoadScene("Stage11_3");
    }
    public void ending_call()
    {
        SceneManager.LoadScene("EndingCreditScene");
    }

    /// <summary>
    /// //////////////////////////////////////////////////////////////
    /// </summary>

    public void stageClearButton()
    {
        string _stage = SceneManager.GetActiveScene().name;



        switch (_stage) // case 에 stage는 실제로 진짜 플레이하는 화면(대화화면 말고)
        {
            case "stage1_3":
                stage1_4();
                break;
            case "stage2_2":
                stage2_3();
                break;
            case "stage3_2":
                stage3_3();
                break;
            case "stage4_2":
               stage4_3();
                break;
            case "stage5_2":
                stage5_3();
                break;
            case "stage6_2":
                stage6_3();
                break;
            case "stage7_2":
                stage7_3();
                break;
            case "stage8_2":
                stage8_3();
                break;
            case "stage9_2":
                stage9_3();
                break;
            case "stage10_2":
                stage10_3();
                break;
            case "stage11_2":
                stage11_3();
                break;

            default:
                break;
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class currentStageClear : MonoBehaviour
{
    SaveUserInfo SUI;

    public int stageclearNumber;
    public GameObject stage_1;
    public GameObject stage_2;
    public GameObject stage_3;
    public GameObject stage_4;
    public GameObject stage_5;
    public GameObject stage_6;
    public GameObject stage_7;
    public GameObject stage_8;
    public GameObject stage_9;
    public GameObject stage_10;
    //public GameObject stage_11;

    public Button stageC_2;
    public Button stageC_3;
    public Button stageC_4;
    public Button stageC_5;
    public Button stageC_6;
    public Button stageC_7;
    public Button stageC_8;
    public Button stageC_9;
    public Button stageC_10;
    public Button stageC_11;


    private void Awake()
    {
        SUI = GameObject.Find("SaveUserInfo").GetComponent<SaveUserInfo>();
    }
    private void Start()
    {
        // stageclearNumber = 0;
    }


    void Update()
    {

        stageclearNumber = SUI.stageclear;
    }

    public void stageClearCheck()
    {


        //stage_1.SetActive(SUI.stageclear >= 1 ? false : true);
        stage_2.SetActive(SUI.stageclear >= 2 ? false : true);
        stage_3.SetActive(SUI.stageclear >= 3 ? false : true);
        stage_4.SetActive(SUI.stageclear >= 4 ? false : true);
        stage_5.SetActive(SUI.stageclear >= 5 ? false : true);
        stage_6.SetActive(SUI.stageclear >= 6 ? false : true);
        stage_7.SetActive(SUI.stageclear >= 7 ? false : true);
        stage_8.SetActive(SUI.stageclear >= 8 ? false : true);
        stage_9.SetActive(SUI.stageclear >= 9 ? false : true);
        stage_10.SetActive(SUI.stageclear >= 10 ? false : true);
        // stage_11.SetActive(SUI.stageclear >= 11 ? false : true);


        //stageC_2.enabled = (SUI.stageclear >= 1 ? true : false);
        stageC_3.enabled = (SUI.stageclear >= 2 ? true : false);
        stageC_4.enabled = (SUI.stageclear >= 3 ? true : false);
        stageC_5.enabled = (SUI.stageclear >= 4 ? true : false);
        stageC_6.enabled = (SUI.stageclear >= 5 ? true : false);
        stageC_7.enabled = (SUI.stageclear >= 6 ? true : false);
        stageC_8.enabled = (SUI.stageclear >= 7 ? true : false);
        stageC_9.enabled = (SUI.stageclear >= 8 ? true : false);
        stageC_10.enabled = (SUI.stageclear >= 9 ? true : false);
        stageC_11.enabled = (SUI.stageclear >= 10 ? true : false);
        /*
        if (stageclearNumber == 0)
        {
         stageC_2.enabled = true;
            stage_1.SetActive(true);
            stage_2.SetActive(true);
            stage_3.SetActive(true);
            stage_4.SetActive(true);
            stage_5.SetActive(true);
            stage_6.SetActive(true);
            stage_7.SetActive(true);
            stage_8.SetActive(true);
            stage_9.SetActive(true);
            stage_10.SetActive(true);

            




        }
        else if (stageclearNumber == 1)
        {

            stage_1.SetActive(false);
            stage_2.SetActive(true);
            stage_3.SetActive(true);
            stage_4.SetActive(true);
            stage_5.SetActive(true);
            stage_6.SetActive(true);
            stage_7.SetActive(true);
            stage_8.SetActive(true);
            stage_9.SetActive(true);
            stage_10.SetActive(true);

           
            



        }
        else if (stageclearNumber == 2)
        {

            stage_1.SetActive(false);
            stage_2.SetActive(false);
            stage_3.SetActive(true);
            stage_4.SetActive(true);
            stage_5.SetActive(true);
            stage_6.SetActive(true);
            stage_7.SetActive(true);
            stage_8.SetActive(true);
            stage_9.SetActive(true);
            stage_10.SetActive(true);

            stageC_2.enabled = true;
            stageC_3.enabled = true;



        }
        else if (stageclearNumber == 3)
        {
            stage_1.SetActive(false);
            stage_2.SetActive(false);
            stage_3.SetActive(false);
            stage_4.SetActive(true);
            stage_5.SetActive(true);
            stage_6.SetActive(true);
            stage_7.SetActive(true);
            stage_8.SetActive(true);
            stage_9.SetActive(true);
            stage_10.SetActive(true);

            stageC_2.enabled = true;
            stageC_3.enabled = true;
            stageC_4.enabled = true;
        }
        else if (stageclearNumber == 4)
        {
            stage_1.SetActive(false);
            stage_2.SetActive(false);
            stage_3.SetActive(false);
            stage_4.SetActive(false);
            stage_5.SetActive(true);
            stage_6.SetActive(true);
            stage_7.SetActive(true);
            stage_8.SetActive(true);
            stage_9.SetActive(true);
            stage_10.SetActive(true);

            stageC_2.enabled = true;
            stageC_3.enabled = true;
            stageC_4.enabled = true;
            stageC_5.enabled = true;
        }
        else if (stageclearNumber == 5)
        {
            stage_1.SetActive(false);
            stage_2.SetActive(false);
            stage_3.SetActive(false);
            stage_4.SetActive(false);
            stage_5.SetActive(false);
            stage_6.SetActive(true);
            stage_7.SetActive(true);
            stage_8.SetActive(true);
            stage_9.SetActive(true);
            stage_10.SetActive(true);

            stageC_2.enabled = true;
            stageC_3.enabled = true;
            stageC_4.enabled = true;
            stageC_5.enabled = true;
            stageC_6.enabled = true;
        }
        else if (stageclearNumber == 6)
        {
            stage_1.SetActive(false);
            stage_2.SetActive(false);
            stage_3.SetActive(false);
            stage_4.SetActive(false);
            stage_5.SetActive(false);
            stage_6.SetActive(false);
            stage_7.SetActive(true);
            stage_8.SetActive(true);
            stage_9.SetActive(true);
            stage_10.SetActive(true);

            stageC_2.enabled = true;
            stageC_3.enabled = true;
            stageC_4.enabled = true;
            stageC_5.enabled = true;
            stageC_6.enabled = true;
            stageC_7.enabled = true;
        }
        else if (stageclearNumber == 7)
        {
            stage_1.SetActive(false);
            stage_2.SetActive(false);
            stage_3.SetActive(false);
            stage_4.SetActive(false);
            stage_5.SetActive(false);
            stage_6.SetActive(false);
            stage_7.SetActive(false);
            stage_8.SetActive(true);
            stage_9.SetActive(true);
            stage_10.SetActive(true);

            stageC_2.enabled = true;
            stageC_3.enabled = true;
            stageC_4.enabled = true;
            stageC_5.enabled = true;
            stageC_6.enabled = true;
            stageC_7.enabled = true;
            stageC_8.enabled = true;
        }
        else if (stageclearNumber == 8)
        {
            stage_1.SetActive(false);
            stage_2.SetActive(false);
            stage_3.SetActive(false);
            stage_4.SetActive(false);
            stage_5.SetActive(false);
            stage_6.SetActive(false);
            stage_7.SetActive(false);
            stage_8.SetActive(false);
            stage_9.SetActive(true);
            stage_10.SetActive(true);

            stageC_2.enabled = true;
            stageC_3.enabled = true;
            stageC_4.enabled = true;
            stageC_5.enabled = true;
            stageC_6.enabled = true;
            stageC_7.enabled = true;
            stageC_8.enabled = true;
            stageC_9.enabled = true;

        }
       

        else if (stageclearNumber == 9)
        {
            stage_1.SetActive(false);
            stage_2.SetActive(false);
            stage_3.SetActive(false);
            stage_4.SetActive(false);
            stage_5.SetActive(false);
            stage_6.SetActive(false);
            stage_7.SetActive(false);
            stage_8.SetActive(false);
            stage_9.SetActive(false);
            stage_10.SetActive(true);

            stageC_2.enabled = true;
            stageC_3.enabled = true;
            stageC_4.enabled = true;
            stageC_5.enabled = true;
            stageC_6.enabled = true;
            stageC_7.enabled = true;
            stageC_8.enabled = true;
            stageC_9.enabled = true;
            stageC_10.enabled = true;

        }

        
        else if (stageclearNumber == 10)
        {
            stage_1.SetActive(false);
            stage_2.SetActive(false);
            stage_3.SetActive(false);
            stage_4.SetActive(false);
            stage_5.SetActive(false);
            stage_6.SetActive(false);
            stage_7.SetActive(false);
            stage_8.SetActive(false);
            stage_9.SetActive(false);
            stage_10.SetActive(false);

            stageC_2.enabled = true;
            stageC_3.enabled = true;
            stageC_4.enabled = true;
            stageC_5.enabled = true;
            stageC_6.enabled = true;
            stageC_7.enabled = true;
            stageC_8.enabled = true;
            stageC_9.enabled = true;
            stageC_10.enabled = true;
            
        }*/
    }
}








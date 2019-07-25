using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TutorialScene : MonoBehaviour
{


    SaveUserInfo SUI;
    public GameObject before;
    public GameObject after;
    public GameObject tutoend;
    public GameObject skip;
    public int chatNum;
    public GameObject tutoimg_1;
    public GameObject tutoimg_2;
    public GameObject tutoimg_3;
    public GameObject tutoimg_4;
    public GameObject tutoimg_5;
    public GameObject tutoimg_6;
    public GameObject tutoimg_7;
    public GameObject tutoimg_8;
    public GameObject tutoimg_9;
    public GameObject tutoimg_10;
    public GameObject tutoimg_11;
    public GameObject tutoimg_12;
    public GameObject tutoimg_13;
    public GameObject tutoimg_14;
    public GameObject tutoimg_15;
    public GameObject tutoimg_16;
    public GameObject tutoimg_17;
    public GameObject tutoimg_18;
    public GameObject tutoimg_19;
    public GameObject tutoimg_20;
    public GameObject tutoimg_21;
    public GameObject tutoimg_22;
    public GameObject tutoimg_23;
    public GameObject tutoimg_24;
    public GameObject tutoimg_25;
    public GameObject tutoimg_26;
    public GameObject tutoimg_27;
    public GameObject tutoimg_28;
    public GameObject tutoimg_29;

    private void Awake()
    {
        SUI = GameObject.Find("SaveUserInfo").GetComponent<SaveUserInfo>();
    }
    // Start is called before the first frame update
    void Start()
    {
        chatNum = 1;
        tutoimg_1.SetActive(true);

        //할거다했으면(조건충족. if문때려서 업데이트 실행)

    }

    // Update is called once per frame
    void Update()
    {

        before.SetActive(chatNum > 1 ? true : false);
        after.SetActive(chatNum > 0 && chatNum < 29 ? true : false);
        tutoend.SetActive(chatNum == 29 ? true : false);

        // skip.SetActive(SUI.stageclear >= 1 ? true : false);



    }
    /*
    public void startChat()
    {
        if (chatNum == 0)
        {
            chatNum += 1;
            tutoimg_1.SetActive(true);
            Debug.Log(chatNum);
        }
        else if (chatNum != 0)
        {
            chatNum = 0;
            Chat(chatNum);
        }
    }
    */
    public void Before()
    {
        chatNum -= 1;
        Chat(chatNum);
    }
    public void After()
    {
        chatNum += 1;
        Chat(chatNum);
    }
    public void Chat(int chatNum)
    {
        tutoimg_1.SetActive(chatNum == 1 ? true : false);
        tutoimg_2.SetActive(chatNum == 2 ? true : false);
        tutoimg_3.SetActive(chatNum == 3 ? true : false);
        tutoimg_4.SetActive(chatNum == 4 ? true : false);
        tutoimg_5.SetActive(chatNum == 5 ? true : false);
        tutoimg_6.SetActive(chatNum == 6 ? true : false);
        tutoimg_7.SetActive(chatNum == 7 ? true : false);
        tutoimg_8.SetActive(chatNum == 8 ? true : false);
        tutoimg_9.SetActive(chatNum == 9 ? true : false);
        tutoimg_10.SetActive(chatNum == 10 ? true : false);
        tutoimg_11.SetActive(chatNum == 11 ? true : false);
        tutoimg_12.SetActive(chatNum == 12 ? true : false);
        tutoimg_13.SetActive(chatNum == 13 ? true : false);
        tutoimg_14.SetActive(chatNum == 14 ? true : false);
        tutoimg_15.SetActive(chatNum == 15 ? true : false);
        tutoimg_16.SetActive(chatNum == 16 ? true : false);
        tutoimg_17.SetActive(chatNum == 17 ? true : false);
        tutoimg_18.SetActive(chatNum == 18 ? true : false);
        tutoimg_19.SetActive(chatNum == 19 ? true : false);
        tutoimg_20.SetActive(chatNum == 20 ? true : false);
        tutoimg_21.SetActive(chatNum == 21 ? true : false);
        tutoimg_22.SetActive(chatNum == 22 ? true : false);
        tutoimg_23.SetActive(chatNum == 23 ? true : false);
        tutoimg_24.SetActive(chatNum == 24 ? true : false);
        tutoimg_25.SetActive(chatNum == 25 ? true : false);
        tutoimg_26.SetActive(chatNum == 26 ? true : false);
        tutoimg_27.SetActive(chatNum == 27 ? true : false);
        tutoimg_28.SetActive(chatNum == 28 ? true : false);
        tutoimg_29.SetActive(chatNum == 29 ? true : false);

    }

    public void Tutoend()
    {
        SceneManager.LoadScene("stage1_2");
    }

}
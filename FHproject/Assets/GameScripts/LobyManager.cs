using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobyManager : MonoBehaviour
{
    public Text now_SP1;
    public Text now_HP1;
    public Text now_SP2;
    public Text now_HP2;
    public Text now_SP3;


    SaveUserInfo SUI;

    int checker;
    int now_SP;
    int now_HP;
    int add_point;

    private void Start()
    {
        SUI = GameObject.Find("SaveUserInfo").GetComponent<SaveUserInfo>();
    }

    private void Update()
    {
        if(checker == 1)
        {
            now_SP1.text = string.Format("{0:f0}", now_SP);
            now_HP1.text = string.Format("{0:f0}", now_HP);
        }
        else if (checker == 2)
        {
            now_SP2.text = string.Format("{0:f0}", now_SP);
            now_HP2.text = string.Format("{0:f0}", now_HP);
        }
        else if (checker == 3)
        {
            now_SP3.text = string.Format("{0:f0}", now_SP);
        }
        //now_SP1.text = string.Format("{0:f0}", SUI.SP);
        //now_SP2.text = string.Format("{0:f0}", SUI.SP);
        //now_SP3.text = string.Format("{0:f0}", SUI.SP);
    }

    public void selectPlayer1()
    {
        checker = 1;
        now_SP = SUI.SP;
        now_HP = SUI.player1_HP;
    }

    public void selectPlayer2()
    {
        checker = 2;
        now_SP = SUI.SP;
        now_HP = SUI.player2_HP;
    }

    public void selectPlayer3()
    {
        checker = 3;
        now_SP = SUI.SP;
    }

    public void add_HP()
    {
       // now_HP += need_SP;
    }
}

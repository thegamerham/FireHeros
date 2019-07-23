using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusManager : MonoBehaviour
{
    public Text SkillPoint;
    public Text ActionPoint;
    public Text tx_now_HP1;
    public Text tx_now_HP2;


    SaveUserInfo SUI;

    int checker = 0;
    int now_SP;
    int now_AP;
    int now_HP1;
    int now_HP2;
    int add_point;
    int need_SP = 1;

    private void Start()
    {
        SUI = GameObject.Find("SaveUserInfo").GetComponent<SaveUserInfo>();
        now_SP = SUI.SP;
        now_AP = SUI.AP;
        now_HP1 = SUI.player1_HP;
        now_HP2 = SUI.player2_HP;
    }

    private void Update()
    {
        SkillPoint.text = string.Format("{0:f0}", now_SP);
        if (checker == 1)
        {
            SkillPoint.text = string.Format("{0:f0}", now_SP);
            tx_now_HP1.text = string.Format("{0:f0}", now_HP1);
            ActionPoint.text = string.Format("{0:f0}", now_AP);
        }
        else if (checker == 2)
        {
            SkillPoint.text = string.Format("{0:f0}", now_SP);
            tx_now_HP2.text = string.Format("{0:f0}", now_HP2);
            ActionPoint.text = string.Format("{0:f0}", now_AP);
        }
        else if (checker == 3)
        {
            SkillPoint.text = string.Format("{0:f0}", now_SP);

            ActionPoint.text = string.Format("{0:f0}", now_AP);

        }
        //now_SP1.text = string.Format("{0:f0}", SUI.SP);
        //now_SP2.text = string.Format("{0:f0}", SUI.SP);
        //now_SP3.text = string.Format("{0:f0}", SUI.SP);
    }

    public void selectPlayer1()
    {
        checker = 1;
    }

    public void selectPlayer2()
    {
        checker = 2;
    }

    public void selectPlayer3()
    {
        checker = 3;
    }

    //HP 강화 버튼
    public void add_HP()
    {
        if (checker ==1 && now_SP - need_SP >= 0)
        {
            now_HP1 += 1;
            now_SP -= 1;
        }
        else if (checker == 2 && now_SP - need_SP >= 0)
        {
            now_HP2 += 1;
            now_SP -= 1;
        }
        else if (now_SP == 0)
        {
            print("SP 부족으로 강화 불가");
        }
        else if (now_SP - need_SP < 0)
        {
            print("SP 부족으로 강화 불가");
        }
    }

    //HP 강화 취소 버튼
    public void sub_HP()
    {
        if (checker == 1 && now_HP1 >= 5)
        {
            now_HP1 -= 1;
            now_SP += 1;
        }
        else if (checker == 2 && now_HP2 >= 4)
        {
            now_HP2 -= 1;
            now_SP += 1;
        }
        else if (checker == 1 && now_HP1 == 4)
        {
            print("기본 HP이므로 SP반환 불가");
        }
        else if (checker == 2 && now_HP2 == 3)
        {
            print("기본 HP이므로 SP반환 불가");
        }
    }

    //AP 강화 버튼
    public void add_AP()
    {
        Debug.Log("djsej");
        if (now_SP - need_SP >= 0)
        {
            now_AP += 1;
            now_AP -= 1;
        }
        else if (now_SP == 0)
        {
            print("AP 부족으로 강화 불가");
        }
        else if (now_SP - need_SP < 0)
        {
            print("SP 부족으로 강화 불가");
        }

    }

    //AP 강화 취소 버튼
    public void sub_AP()
    {
        if (now_AP > 7)
        {
            now_AP -= 1;
            now_SP += 1;
        }
        else if (now_AP == 7)
        {
            print("기본 AP이므로 SP반환 불가");
        }
    }

    //강화 안함 버튼
    public void cancel()
    {
        now_HP1 = SUI.player1_HP;
        now_HP2 = SUI.player2_HP;
        now_SP = SUI.SP;
        now_AP = SUI.AP;
    }

    //강화 적용 버튼
    public void build()
    {
        SUI.player1_HP = now_HP1;
        SUI.player2_HP = now_HP2;
        SUI.SP = now_SP;
        SUI.AP = now_AP;
    }
}

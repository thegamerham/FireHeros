using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusManager : MonoBehaviour
{
    public Text SkillPoint;
    public Text ActionPoint;
    public Text tx_now_HP1;
    public Text player_now_Yrange;
    public Text tx_now_HP2;


    SaveUserInfo SUI;

    int checker = 0;
    int now_SP;
    int now_AP;
    int now_HP1;
    int now_HP2;
    int add_point;
    int need_SP = 1;

    int player_range;

    private void Start()
    {
        SUI = GameObject.Find("SaveUserInfo").GetComponent<SaveUserInfo>();
        now_SP = SUI.SP;
        now_AP = SUI.AP;
        now_HP1 = SUI.player1_HP;
        now_HP2 = SUI.player2_HP;
        player_range = SUI.player1_Range;
    }

    private void Update()
    {
        SkillPoint.text = string.Format("{0:f0}", now_SP);
        ActionPoint.text = string.Format("{0:f0}", now_AP);
        if (checker == 1)
        {
            tx_now_HP1.text = string.Format("{0:f0}", now_HP1);
            player_now_Yrange.text = string.Format("{0:f0}", player_range);
        }
        else if (checker == 2)
        {
            tx_now_HP2.text = string.Format("{0:f0}", now_HP2);
        }
        else if (checker == 3)
        {
            SkillPoint.text = string.Format("{0:f0}", now_SP);

            

        }
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

    //HP + 버튼
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

    //HP - 버튼
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

    //AP + 버튼
    public void add_AP()
    {
        if (now_SP - need_SP >= 0)
        {
            now_AP += 1;
            now_SP -= 1;
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

    //AP - 버튼
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

    //player1 Range + 버튼
    public void player_Range_Up()
    {
        if (now_SP - need_SP >= 0 && player_range == 1)
        {
            print("emfdj");
            player_range++;
            now_SP -= need_SP;
        }
        else if (now_SP - need_SP <= 0)
        {
            print("SP부족으로 강화 불가");
        }
        else if (player_range == 2)
        {
            print("더 이상 강화할 수 없습니다");
        }
        else if (SUI.player1_Range == 2)
        {
            print("이미 최고 강화 입니다");
        }
    }

    //player1 Range - 버튼
    public void player_Range_Down()
    {
        if (player_range == 2)
        {
            player_range -= 1;
            now_SP += 1;
        }
        else if (player_range == 1)
        {
            print("최소 사거리입니다");
        }
    }

    //강화 안함 버튼
    public void cancel()
    {
        now_HP1 = SUI.player1_HP;
        now_HP2 = SUI.player2_HP;
        now_SP = SUI.SP;
        now_AP = SUI.AP;
        player_range = SUI.player1_Range;
    }

    //강화 적용 버튼
    public void build()
    {
        SUI.player1_HP = now_HP1;
        SUI.player2_HP = now_HP2;
        SUI.SP = now_SP;
        SUI.AP = now_AP;
        SUI.player1_Range = player_range;
    }
}

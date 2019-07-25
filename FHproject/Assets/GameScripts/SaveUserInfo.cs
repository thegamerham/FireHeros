﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveUserInfo : MonoBehaviour
{
    public int player1_HP = 4;
    public int player2_HP = 3;
    public int AP = 7;
    public int SP = 10;
    public int player1_Range = 1;
    public int player2_Rescue = 2;


    public int stageclear; // 최고 스테이지 클리어 현황. 다음스테이지 해금용.
    public int afterSkip; // 최고 스테이지 클리어 이후 after scene 조회 현황. skip버튼 활성화용.

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void Status(int add_player1_HP, int add_player2_HP, int add_AP)
    {
        player1_HP += add_player1_HP;
        player2_HP += add_player2_HP;
        AP += add_AP;
    }
}

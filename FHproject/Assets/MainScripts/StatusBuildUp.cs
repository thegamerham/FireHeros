using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusBuildUp : MonoBehaviour
{
    SaveUserInfo SUI;
    //스탯 증가에 필요한 SP
    int needSP = 2;
    
    void Start()
    {
        SUI = GameObject.Find("SaveUserInfo").GetComponent<SaveUserInfo>();
    }

    void Update()
    {
        
    }

    //SP를 소모하여 HP를 증가 시킴
    public void add_HP()
    {
        if (SUI.SP >= needSP)
        {
            Debug.Log("now HP : " + SUI.player1_HP);
            SUI.SP -= needSP;
            needSP++;
            SUI.player1_HP += 1;
            Debug.Log("after HP : " + SUI.player1_HP);
        }
        else if (SUI.SP < needSP && SUI.SP == 0)
        {
            print("SP부족");
        }
    }
}

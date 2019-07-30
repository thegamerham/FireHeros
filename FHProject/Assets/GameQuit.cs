using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameQuit : MonoBehaviour
{

    public void DoQuit()
    {
        Debug.Log("게임 꺼버뤼기");
        Application.Quit();
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public void Scen()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void stage()
    {
        print(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Stage1");
    }
}

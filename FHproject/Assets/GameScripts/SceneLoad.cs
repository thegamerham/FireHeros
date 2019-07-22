using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public void Scen()
    {
        SceneManager.LoadScene("Lobby");
    }
    public void stage1()
    {
        SceneManager.LoadScene("Stage1");
    }
}

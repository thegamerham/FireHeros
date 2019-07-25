using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class stagePOPUP : MonoBehaviour

{
    public GameObject Panel1;
    public GameObject Panel2;
    public GameObject Panel3;
    public GameObject Player;
    public GameObject PassPanel;
    public GameObject Image1;
    public GameObject Image2;
    public GameObject Image3;
    public int firefighter = 0;


    public void OpenPanel1()
    {
        Panel1.SetActive(true);
     }
    public void OpenPanel2()
    {
        Panel2.SetActive(true);
    }
    public void OpenPanel3()
    {
        Panel3.SetActive(true);
    }

    public void closePanel1()
    {
        Panel1.SetActive(false);
    }
    public void closePanel2()
    {
        Panel2.SetActive(false);
    }
    public void closePanel3()
    {
        Panel3.SetActive(false);
    }

    public void openPassPanel()
    {
        PassPanel.SetActive(true);
    }

    public void closePassPanel()
    {
        PassPanel.SetActive(false);
    }



    public void openImage1()
    {
        Image1.SetActive(true);
    }
    public void openImage2()
    {
        Image2.SetActive(true);
    }

    public void openImage3()
    {
        Image3.SetActive(true);
    }
    public void closeImage1()
    {
        Image1.SetActive(false);
    }
    public void closeImage2()
    {
        Image1.SetActive(false);
    }
    public void closeImage3()
    {
        Image1.SetActive(false);
    }

    public void stage1()
    {
        SceneManager.LoadScene("stage1_3");
    }
}

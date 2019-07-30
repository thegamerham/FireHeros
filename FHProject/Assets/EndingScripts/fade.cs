using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fade : MonoBehaviour
{

    public Image fadeImage;
    public GameObject fadeOnOff;
    // Start is called before the first frame update
    void Start()
    {
        fadeImage.canvasRenderer.SetAlpha(0.0f);

    }

    // Update is called once per frame
    public void fadeIn()
    {
        fadeOnOff.SetActive(true);
        fadeImage.CrossFadeAlpha(1, 2, false);
    }
    public void fadeOut()
    {
        fadeOnOff.SetActive(true);
        fadeImage.CrossFadeAlpha(0, 2, false);
        fadeOnOff.SetActive(false);
    }
}

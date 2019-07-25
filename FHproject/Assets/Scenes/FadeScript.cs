﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScript : MonoBehaviour
{
    public Image Panel;
    float time = 0f;
    float F_time = 1f;
    public void Fade()
    {
        StartCoroutine(FadeFlow());
    }
    IEnumerator FadeFlow()
    {
        Panel.gameObject.SetActive(true); // 붉은 fade
        Color alpha = Panel.color;
        while (alpha.a < 1f)
        {
            time += Time.deltaTime / F_time;
            alpha.a = Mathf.Lerp(0, 0.5f, time);
            Panel.color = alpha;
            yield return null;
        }
        yield return null;
    }


    public void Fade2()
    {
        Panel.gameObject.SetActive(false);
    }

}
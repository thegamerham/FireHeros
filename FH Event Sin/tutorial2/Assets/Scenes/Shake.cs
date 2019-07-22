using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public float shakes = 2f;
    public float shakeAmount = 0.5f;
    public float decreaseFacetor = 1.0f;
    Vector3 OriginalPos;
    public bool CameraShaking;

    void OnEnable()
    {
        CameraShaking = false;
        OriginalPos = gameObject.transform.position;
    }

    void Update()
    {
        if (CameraShaking)
        {
            if(shakes > 0f)
            {
                gameObject.transform.position = OriginalPos + Random.insideUnitSphere * shakeAmount;

                shakes -= Time.deltaTime * decreaseFacetor;

            }
            else
            {
                shakes = 0;
                CameraShaking = false;
                gameObject.transform.position = OriginalPos;
            }
        }
    }

    public void ShakeCamera(float shaking)
    {
        if (!CameraShaking)
        {
            OriginalPos = gameObject.transform.position;

        }

        shakes = shaking;
        CameraShaking = true;
    }
}

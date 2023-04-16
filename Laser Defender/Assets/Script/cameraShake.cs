using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShake : MonoBehaviour
{
    [SerializeField] float shakeDuration = 1.0f;
    [SerializeField] float shakeMagnitude = 0.5f;

    Vector3 initalPositon;
    void Start()
    {
        initalPositon= transform.position;
    }

    public void play()
    {
        StartCoroutine(shake());
    }

    IEnumerator shake() 
    {
        float elapseTime = 0;
        while (elapseTime< shakeDuration) 
        {
            transform.position = initalPositon + (Vector3)Random.insideUnitCircle * shakeMagnitude;
            elapseTime += Time.deltaTime;
             yield return new WaitForEndOfFrame();

        }
        transform.position = initalPositon;
    }

}

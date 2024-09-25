using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float shakeDuration = 1.0f;
    [SerializeField] float shameMagnitude = 0.5f;

    Vector3 initialposition;
    void Start()
    {
        initialposition = transform.position;
    }

    public void Play()
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {

        float elapsedtime = 0f;

        while (elapsedtime < shakeDuration)
        {

            transform.position = initialposition + (Vector3)Random.insideUnitCircle * shameMagnitude;
            elapsedtime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = initialposition;
    }


}

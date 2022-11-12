using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    Vector3 cameraPos;

    // Start is called before the first frame update
    void Start()
    {
        cameraPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
            StartCoroutine(CamShake(0.5f, 0.9f)); //유지시간, 흔들범위
    }

    public IEnumerator CamShake(float duration, float range)
    {
        float timer = 0;

        while (timer <= duration)
        {
            transform.localPosition = (Vector3)Random.insideUnitSphere * range + cameraPos;

            timer += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = cameraPos;
    }
}

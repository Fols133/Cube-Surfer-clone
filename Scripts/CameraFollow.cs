using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float durationShaking = 1f;

    private Vector3 newPos;
    private Vector3 cameraPos;
    private float cameraPosY;
    private bool shaking = false;
    private float force = 0.3f;

    private void Start()
    {
        cameraPos = transform.position - player.position;
        cameraPosY = cameraPos.y;
    }

    void LateUpdate()
    {
        newPos = player.position + cameraPos;
        newPos.y = cameraPosY;
        transform.position = newPos;
        if(shaking)
            transform.position += Random.insideUnitSphere * force;
    }

    public IEnumerator ShakingEnable()
    {
        shaking = true;
        yield return new WaitForSecondsRealtime(durationShaking);
        shaking = false;
    }
}



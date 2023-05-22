using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float swipeSpeed = 0.5f;
    [SerializeField] private float fieldLimit = 2f;

    private float newPosX;

    void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        transform.Translate(Vector3.forward * speed * Time.fixedDeltaTime);
        newPosX = transform.position.x + SwipeController.x * swipeSpeed * Time.fixedDeltaTime;
        newPosX = Mathf.Clamp(newPosX, -fieldLimit, fieldLimit);
        transform.position = new Vector3(newPosX, transform.position.y, transform.position.z);
    }
}

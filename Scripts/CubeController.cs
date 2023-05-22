using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    private StackBlock stackBlock;
    private bool isCubeStack = false;

    private void Start()
    {
        stackBlock = FindObjectOfType<StackBlock>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pickup"))
        {
            if (!isCubeStack)
            {
                isCubeStack = true;
                stackBlock.CubeAdd(gameObject.transform.parent.gameObject);
            }
        }

        if (collision.gameObject.CompareTag("Wall"))
        {

            if (isCubeStack)
                stackBlock.CubeDelete(gameObject.transform.parent.gameObject);
        }
    }
}

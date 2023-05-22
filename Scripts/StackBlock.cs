using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackBlock : MonoBehaviour
{
    [SerializeField] private float heightCube = 1f;
    [SerializeField] private CameraFollow cameraFollow;
    [SerializeField] private Transform trail;
    private List<GameObject> cubeList = new List<GameObject>();
    private Vector3 newPosPlayer;
    private Vector3 newPosObj;
    private GameObject lastCube;

    void Start()
    {
        cubeList.Add(gameObject);
        SetLastCube();
    }

    private void Update()
    {
        trail.position = new Vector3(transform.position.x, trail.position.y, transform.position.z);
    }

    public void CubeAdd(GameObject gameObject)
    {
        newPosPlayer = new Vector3(transform.position.x, transform.position.y + heightCube, transform.position.z);
        transform.position = newPosPlayer;

        newPosObj = new Vector3(lastCube.transform.position.x, lastCube.transform.position.y - heightCube, lastCube.transform.position.z);
        gameObject.transform.position = newPosObj;
        gameObject.transform.SetParent(transform);
        cubeList.Add(gameObject);
        SetLastCube();
    }

    public void CubeDelete(GameObject gameObject)
    {
        cubeList.Remove(gameObject);
        gameObject.transform.parent = null;
        SetLastCube();
        StartCoroutine(cameraFollow.ShakingEnable());
        Destroy(gameObject, 5f);
    }

    private void SetLastCube()
    {
        lastCube = cubeList[cubeList.Count - 1];
    }
}

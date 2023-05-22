using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEndGame : MonoBehaviour
{
    [SerializeField] GameObject diePanel;

    void Start()
    {
        diePanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Wall"))
        {
            Time.timeScale = 0f;
            diePanel.SetActive(true);
        }
    }
}

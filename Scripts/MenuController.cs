using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private GameObject mainPanel;

    void Start()
    {
        Time.timeScale = 0f;
        mainPanel.SetActive(true);
    }

    public void StartGame()
    {
        mainPanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void TryAgain()
    {
        SceneManager.LoadScene(0);
    }
}

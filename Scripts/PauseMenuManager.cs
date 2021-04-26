using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenuManager : MonoBehaviour
{
    public GameObject pauseMenu;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Pause))
        {
            pauseMenu.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene(3);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            SceneManager.LoadScene(4);
        }
    }
}

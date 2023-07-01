using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [Header ("Pause")]
    private bool isPaused;
    public GameObject pausePanel;
    public GameObject inventoryPanel;
    public bool usingPausePanel;
    public string mainMenu;

    [Header("Map")]
    private bool isActivate;
    public GameObject map;
    public bool usingMap;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        pausePanel.SetActive(false);
        inventoryPanel.SetActive(false);
        usingPausePanel = false;

        isActivate = false;
        map.SetActive(false);
        usingMap = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("pause"))
        {
            ChangePause();
        }
        if (Input.GetButtonDown("map"))
        {
            Map();
        }
    }

    public void Map()
    {
        isActivate = !isActivate;
        if (isActivate)
        {
            map.SetActive(true);
            Time.timeScale = 0f;
            usingMap = true;
        }
        else
        {
            map.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void ChangePause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
            usingPausePanel = true;
        }
        else
        {
            inventoryPanel.SetActive(false);
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene(mainMenu);
        Time.timeScale = 1f;
    }

    public void SwitchPanel()
    {
        usingPausePanel = !usingPausePanel;
        if (usingPausePanel)
        {
            pausePanel.SetActive(true);
            inventoryPanel.SetActive(false);
        }
        else
        {
            inventoryPanel.SetActive(true);
            pausePanel.SetActive(false);
        }
    }

}

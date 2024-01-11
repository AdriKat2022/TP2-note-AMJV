using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    private float timerTime;

    [SerializeField] GameObject PauseMenu;
    private bool isPaused;

    private void Update()
    {
        timerTime += Time.deltaTime;
        displayTime(timerTime);
        
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                Time.timeScale = 0f;
                PauseMenu.SetActive(true);
            }
            else
            {
                Time.timeScale = 1f;
                PauseMenu.SetActive(false);
            }
            
        }
    }

    public void Quit()
    {
        SceneManager.LoadScene(0);
    }

    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1f;
        PauseMenu.SetActive(false);
    }
    void displayTime(float timeToDisplay)
    {
        timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

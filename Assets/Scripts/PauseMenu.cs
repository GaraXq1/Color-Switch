using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public Transform Player;
    public Transform cam;
    public GameObject DeathMenuUI;


    public void Continue()
    {
        Time.timeScale = 1f;
        DeathMenuUI.SetActive(false);
        player.IsPaused = false;
    }
 
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        cam.position = new Vector2 (cam.position.x,Player.position.y);
        DeathMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void returnToMenu()
    {
        SceneManager.LoadScene("StartMenu");
        Time.timeScale = 1f;
    }
}

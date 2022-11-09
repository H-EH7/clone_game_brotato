using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // ΩÃ±€≈œ ∞¥√º
    public static GameManager instance;

    public GameObject pausedUI;

    public int money;

    private void Awake()
    {
        // ΩÃ±€≈œ ∞¥√º √ ±‚»≠
        if (instance == null)
        {
            instance = gameObject.GetComponent<GameManager>();
        }
    }

    private void Update()
    {
        PauseGame();
    }

    void PauseGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1f)
            {
                Time.timeScale = 0f;
                pausedUI.SetActive(true);
            }
            else
            {
                pausedUI.SetActive(false);
                Time.timeScale = 1f;
            }
        }
    }
}

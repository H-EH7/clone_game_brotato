using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitBt : MonoBehaviour
{
    public void ExitBtEvent()
    {
        SceneManager.LoadScene("TitleScene");
        Time.timeScale = 1f;
    }
}

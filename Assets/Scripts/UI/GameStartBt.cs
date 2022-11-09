using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartBt : MonoBehaviour
{
    public void GameStartBtEvent()
    {
        SceneManager.LoadScene("MainScene");
    }
}

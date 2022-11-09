using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    // 싱글턴 객체
    public static HPBar instance;

    Player player;
    Text hPText;
    Slider hPSlider;

    private void Awake()
    {
        if (instance == null)
        {
            instance = gameObject.GetComponent<HPBar>();
        }

        hPSlider = GetComponent<Slider>();
        hPText = GetComponentInChildren<Text>();
    }

    private void Update()
    {
        UpdateHPBar();
    }


    /// <summary>
    /// HP Bar 초기화 함수
    /// </summary>
    public void InitHPBar()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        hPSlider.maxValue = player.maxHP;
        hPSlider.value = hPSlider.maxValue;
        hPText.text = Mathf.Floor(player.currentHP) + " / " + player.maxHP;
    }

    /// <summary>
    /// HP Bar 갱신 함수 (Update)
    /// </summary>
    void UpdateHPBar()
    {
        hPSlider.value = Mathf.Floor(player.currentHP);
        hPText.text = Mathf.Floor(player.currentHP) + " / " + player.maxHP;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    // �̱��� ��ü
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
    /// HP Bar �ʱ�ȭ �Լ�
    /// </summary>
    public void InitHPBar()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        hPSlider.maxValue = player.maxHP;
        hPSlider.value = hPSlider.maxValue;
        hPText.text = Mathf.Floor(player.currentHP) + " / " + player.maxHP;
    }

    /// <summary>
    /// HP Bar ���� �Լ� (Update)
    /// </summary>
    void UpdateHPBar()
    {
        hPSlider.value = Mathf.Floor(player.currentHP);
        hPText.text = Mathf.Floor(player.currentHP) + " / " + player.maxHP;
    }
}

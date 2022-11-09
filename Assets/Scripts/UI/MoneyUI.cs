using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    // �̱��� ��ü
    public static MoneyUI instance;

    private void Awake()
    {
        // �̱��� ��ü �ʱ�ȭ
        if (instance == null)
        {
            instance = gameObject.GetComponent<MoneyUI>();
        }
    }

    /// <summary>
    /// MoneyUI ���� �Լ� (������)
    /// </summary>
    public void UpdateMoneyUI()
    {
        GetComponentInChildren<Text>().text = "Money : " + GameManager.instance.money;
    }
}

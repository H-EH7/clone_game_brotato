using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    // 싱글턴 객체
    public static MoneyUI instance;

    private void Awake()
    {
        // 싱글턴 객체 초기화
        if (instance == null)
        {
            instance = gameObject.GetComponent<MoneyUI>();
        }
    }

    /// <summary>
    /// MoneyUI 갱신 함수 (참조용)
    /// </summary>
    public void UpdateMoneyUI()
    {
        GetComponentInChildren<Text>().text = $"Money : {GameManager.instance.money}";
    }
}

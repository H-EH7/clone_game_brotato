using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{

    Text moneyText;
    Button BuyWeaponButton;

    private void Awake()
    {
        moneyText = GameObject.Find("ShopMoneyText").GetComponent<Text>();
        BuyWeaponButton = GameObject.Find("BuyWeaponButton").GetComponent<Button>();
    }

    private void Update()
    {
        moneyText.text = $"Money : {GameManager.instance.money}";
        if (GameManager.instance.money < 10 || GameManager.instance.isFullWeaponSlot == true)
        {
            BuyWeaponButton.interactable = false;
        }
        else
        {
            BuyWeaponButton.interactable = true;
        }
    }

    public void buyWeaponBt()
    {
        GameManager.instance.money -= 10;
        GameManager.instance.GetWeapon();
    }

    public void nextStageBt()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}

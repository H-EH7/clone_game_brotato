using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // �̱��� ��ü
    public static GameManager instance;

    public GameObject pausedUI;
    public GameObject shopUI;
    public List<GameObject> weapons;

    [SerializeField]
    GameObject[] weaponPositions = new GameObject[6];
    [SerializeField]
    GameObject[] inventorySlots = new GameObject[6];
    [SerializeField]
    GameObject weapon;
    [SerializeField]
    GameObject weaponImg;
    [SerializeField]
    GameObject timer;

    public int money;
    public bool isFullWeaponSlot = false;
    public float stageTime;

    float currentTime;

    private void Awake()
    {
        // �̱��� ��ü �ʱ�ȭ
        if (instance == null)
        {
            instance = gameObject.GetComponent<GameManager>();
        }
    }

    private void Start()
    {
        currentTime = stageTime;
        GetWeapon();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }


        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            timer.GetComponent<Text>().text = $"{Mathf.FloorToInt(currentTime)}";
        }
        else
        {
            GoToNextStage();
        }
    }
           
    void ResetGame()
    {
        // �÷��̾� ��ġ �ʱ�ȭ
        if (GameObject.Find("Player") != null)
        {
            Vector3 initialPosition = Vector3.zero;
            GameObject.Find("Player").transform.position = initialPosition;
            Camera.main.transform.position = initialPosition;
        }

        // ���� ���� ������ ����
        if (GameObject.FindGameObjectsWithTag("Enemy") != null)
        {
            GameObject[] remainedEnemy = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < remainedEnemy.Length; i++)
            {
                Destroy(remainedEnemy[i]);
            }
        }

        // ������ ������ ����
        if (GameObject.FindGameObjectsWithTag("Item") != null)
        {
            GameObject[] remainedItem = GameObject.FindGameObjectsWithTag("Item");
            for (int i = 0; i < remainedItem.Length; i++)
            {
                Destroy(remainedItem[i]);
            }
        }

        // ���� �Ѿ� ����
        if (GameObject.FindGameObjectsWithTag("Bullet") != null)
        {
            GameObject[] remainedBullet = GameObject.FindGameObjectsWithTag("Bullet");
            for (int i = 0; i < remainedBullet.Length; i++)
            {
                Destroy(remainedBullet[i]);
            }
        }

        currentTime = stageTime;
    }

    /// <summary>
    /// ���� �ð� ���� �� �Ͻ����� �޴� Ȱ��ȭ�ϴ� �Լ�
    /// </summary>
    void PauseGame()
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

    void GoToNextStage()
    {
        Time.timeScale = 0f;
        currentTime = 0f;
        shopUI.SetActive(true);
        ResetGame();
    }

    /// <summary>
    /// ���⸦ ����� �� ����ϴ� �Լ�
    /// </summary>
    public void GetWeapon()
    {
        if (isFullWeaponSlot == false)
        {
            // ���� ���� ���⿡ ���
            weapons.Add(weapon);

            // �κ��丮�� �̹��� ����
            GameObject weaponImgObject = Instantiate(weaponImg, inventorySlots[weapons.Count - 1].transform);
            weaponImgObject.AddComponent<Image>().sprite = weapon.GetComponent<Weapon>().weaponSprite;

            // ���� ������Ʈ ����
            Instantiate(weapon, weaponPositions[weapons.Count - 1].transform);
            weaponPositions[weapons.Count - 1].SetActive(true);
        }

        if (weapons.Count == 6)
        {
            isFullWeaponSlot = true;
        }
    }

}

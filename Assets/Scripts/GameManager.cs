using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // 싱글턴 객체
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
        // 싱글턴 객체 초기화
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
        // 플레이어 위치 초기화
        if (GameObject.Find("Player") != null)
        {
            Vector3 initialPosition = Vector3.zero;
            GameObject.Find("Player").transform.position = initialPosition;
            Camera.main.transform.position = initialPosition;
        }

        // 적이 남아 있으면 제거
        if (GameObject.FindGameObjectsWithTag("Enemy") != null)
        {
            GameObject[] remainedEnemy = GameObject.FindGameObjectsWithTag("Enemy");
            for (int i = 0; i < remainedEnemy.Length; i++)
            {
                Destroy(remainedEnemy[i]);
            }
        }

        // 떨어진 아이템 제거
        if (GameObject.FindGameObjectsWithTag("Item") != null)
        {
            GameObject[] remainedItem = GameObject.FindGameObjectsWithTag("Item");
            for (int i = 0; i < remainedItem.Length; i++)
            {
                Destroy(remainedItem[i]);
            }
        }

        // 남은 총알 제거
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
    /// 게임 시간 정지 후 일시정지 메뉴 활성화하는 함수
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
    /// 무기를 얻었을 때 등록하는 함수
    /// </summary>
    public void GetWeapon()
    {
        if (isFullWeaponSlot == false)
        {
            // 현재 가진 무기에 등록
            weapons.Add(weapon);

            // 인벤토리에 이미지 생성
            GameObject weaponImgObject = Instantiate(weaponImg, inventorySlots[weapons.Count - 1].transform);
            weaponImgObject.AddComponent<Image>().sprite = weapon.GetComponent<Weapon>().weaponSprite;

            // 무기 오브젝트 생성
            Instantiate(weapon, weaponPositions[weapons.Count - 1].transform);
            weaponPositions[weapons.Count - 1].SetActive(true);
        }

        if (weapons.Count == 6)
        {
            isFullWeaponSlot = true;
        }
    }

}

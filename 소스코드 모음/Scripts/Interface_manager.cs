using UnityEngine;

// 이 코드는 주변에 아이템과 적이있다면 알려주는 인터페이스를 활성화 하는 스크립트 입니다.
public class Interface_manager : MonoBehaviour
{
    public GameObject[] enemyObj;
    public GameObject[] itemObj;

    private EnemyManager[] theEnemy;
    private ItemManager[] theItem;

    public GameObject red;
    public GameObject blue;

    public bool nearFlag = false;
    public bool nearFlag_Enemy = false;

    public GameObject thePlayer;
    private CharcterMoving thePlayerMoving;

    void Start() // 괴물과 아이템의 종류를 선업합니.
    {

        var Key_ran = GameObject.Find("key_o").GetComponent<Keyrandom>();
        for (int i = 0; i < Key_ran.key.Length; i++)
        {
            if (Key_ran.cnt[i] == 1)
            {
                itemObj[1] = Key_ran.key[i];
            }
        }
        var Po_ran = GameObject.Find("po_o").GetComponent<Keyrandom>();
        for (int i = 0; i < Po_ran.key.Length; i++)
        {
            if (Po_ran.cnt[i] == 1)
            {
                itemObj[0] = Po_ran.key[i];
            }
        }

        thePlayerMoving = thePlayer.GetComponent<CharcterMoving>();
        theEnemy = new EnemyManager[enemyObj.Length];
        for (int i = 0; i < enemyObj.Length; i++)
        {
            theEnemy[i] = enemyObj[i].GetComponent<EnemyManager>();

        }
        theItem = new ItemManager[itemObj.Length];
        for (int i = 0; i < itemObj.Length; i++)
        {
            theItem[i] = itemObj[i].GetComponent<ItemManager>();

        }
    }

    void Update()
    {

        EnemiesNearCheck();
        ItemNearCheck();

        if (nearFlag_Enemy)
        {
            red.SetActive(true); //괴물이 주변에있다면 인터페이스 활성화


        }
        else
        {
            red.SetActive(false);
        }

        if (nearFlag)
        {
            if (thePlayerMoving.currentTool == "rader")
            {
                blue.SetActive(true); //레이더를든 상태로 아이템이 주변에 있다면 인터페이스 활성화
            }
        }
        else
        {
            blue.SetActive(false);
        }
    }


    private void EnemiesNearCheck() // 적이 주변에있는지 확인합니.
    {
        nearFlag_Enemy = false;

        for (int i = 0; i < enemyObj.Length; i++)
        {
            if (theEnemy[i].isNear_Enemy)
            {
                nearFlag_Enemy = true;
                break;
            }
        }
    }
    private void ItemNearCheck() // 아이템이 주변에 있는지 확인합니.
    {
        nearFlag = false;

        for (int i = 0; i < itemObj.Length; i++)
        {
            if (theItem[i].isNear)
            {
                nearFlag = true;
                break;
            }
        }
    }
}
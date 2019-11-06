using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start()
    {
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
            red.SetActive(true);


        }
        else
        {
            red.SetActive(false);
        }

        if (nearFlag)
        {
            if (thePlayerMoving.currentTool == "rader")
            {
                blue.SetActive(true);
            }
        }
        else
        {
            blue.SetActive(false);
        }
    }


    private void EnemiesNearCheck()
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
    private void ItemNearCheck()
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

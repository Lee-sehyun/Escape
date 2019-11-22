using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public GameObject[] enemyObj;
    public GameObject[] itemObj;

    private EnemyManager[] theEnemy;
    private ItemManager[] theItem;

    public AudioSource beep;

    private CharcterMoving thePlayerMoving;

    public bool nearFlag = false;

    public GameObject thePlayer;

    void Start()
    {
        thePlayerMoving = thePlayer.GetComponent<CharcterMoving>();
        theEnemy = new EnemyManager[enemyObj.Length];
        theItem = new ItemManager[itemObj.Length];

        var Key_ran = GameObject.Find("key_o").GetComponent<Keyrandom>();
        for (int i = 0; i < Key_ran.key.Length; i++)
        {
            if (Key_ran.cnt[i] == 1)
            {
                enemyObj[1] = Key_ran.key[i];
                itemObj[1] = Key_ran.key[i];
            }
        }
        var Po_ran = GameObject.Find("po_o").GetComponent<Keyrandom>();
        for (int i = 0; i < Po_ran.key.Length; i++)
        {
            if (Po_ran.cnt[i] == 1)
            {
                enemyObj[0] = Po_ran.key[i];
                itemObj[0] = Po_ran.key[i];
            }
        }

        for (int i = 0; i < enemyObj.Length; i++)
        {
            theEnemy[i] = enemyObj[i].GetComponent<EnemyManager>();

        }
        for (int i = 0; i < itemObj.Length; i++)
        {
            theItem[i] = itemObj[i].GetComponent<ItemManager>();

        }
    }


    void Update()
    {

        //EnemiesNearCheck();


        ItemNearCheck();

        if (nearFlag)
        {
            //if (!beep.isPlaying)
            if (thePlayerMoving.currentTool == "rader")
            {
                beep.Play();
            }

            //StopAndPlaySound(beep);
        }
        else
        {
            StopSounds();
        }

    }


    private void EnemiesNearCheck()
    {
        nearFlag = false;

        for (int i = 0; i < enemyObj.Length; i++)
        {
            if (theEnemy[i].isNear_Enemy)
            {
                nearFlag = true;
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


    private void StopAndPlaySound(AudioSource _audio)
    {
        //StopSounds();
        _audio.Play();
    }


    private void StopSounds()
    {
        beep.Stop();
    }
}

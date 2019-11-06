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

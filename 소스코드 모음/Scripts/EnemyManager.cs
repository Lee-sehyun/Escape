using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//이 코드는 적의 위치를 파악해, 주변에 있는지 체크합니.

public class EnemyManager : MonoBehaviour
{
    public GameObject thePlayer;

    public float reactDist;
    private float distance;

    public bool isNear_Enemy = false;

    void Start()
    {
        
    }


    void Update()
    {
        distance = Vector3.Distance(thePlayer.transform.position, transform.position);
        //Debug.Log(distance);

        NearCheck();
    }

    private void NearCheck() // 괴물과의 거리를 확인하고 주면에 있다면 isNear_Enemy를 True로 합니다.
    {
        if (distance <= reactDist)
        {
            isNear_Enemy = true;
        }
        else
        {
            isNear_Enemy = false;
        }
    }
   
}
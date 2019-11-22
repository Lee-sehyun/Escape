using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 해당 코드는 플레이어의 상태를 받아서, Back ground를 호출합니다.
public class BackgroundManager : MonoBehaviour
{
    public GameObject exhustedBG;
    public GameObject thePlayer;

    private CharcterMoving charcter;

    void Start()
    {
        charcter = thePlayer.GetComponent<CharcterMoving>(); //플레이어의 상태를 받아옵니다.
    }

    // Update is called once per frame
    void Update()
    {
        ExhustedOnOff();
    }


    private void ExhustedOnOff() //플레이어의 상태가 탈진상태이면 탈진 BackGround를 호출합니.
    {
        if (charcter.isExhausted)
        {
            exhustedBG.gameObject.SetActive(true);
        }
        else
        {
            exhustedBG.gameObject.SetActive(false);
        }
    }
}
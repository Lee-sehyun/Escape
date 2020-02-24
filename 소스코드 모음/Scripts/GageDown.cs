using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//플레이어가 shift키를 사용하여,대쉬를 사용할때 게이지 그래픽이 작아지는 인터페이스를 위한 코드입니다.
public class GageDown : MonoBehaviour
{
    public int size;
    public float Y;

    private CharcterMoving charcter;

    public GameObject thePlayer;

    // Start is called before the first frame update
    void Start()
    {
        charcter = thePlayer.GetComponent<CharcterMoving>(); //플레이어의 상태를 파악합니다.

    }

    // Update is called once per frame
    void Update()
    {
        size = charcter.runcount * 3;

        SizeDown();
    }
    void SizeDown()
    {
        gameObject.transform.localScale = new Vector3(size, Y, 0); // 게이지바의 크기를 선언합니다.
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 해당 스크립트는 아이템에 가시적인 효과를 주는 기능입니다.
public class get_item : MonoBehaviour
{
    public bool canGetItem = false;
    public bool check_item = false;

    public GameObject item_sub;
    public GameObject thePlayer;

    private float distance;

    public float flashItemsLimit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(thePlayer.transform.position, transform.position); // 마우스와 물체의 거리
    }

    // 마우스를 올렸을 때
    private void OnMouseEnter()
    {
        // 거리가 리미트 안이면 활성화
        if (distance <= flashItemsLimit)
        {
            item_sub.SetActive(true); 
            canGetItem = true;
        }

        // 밖이면 비활성화
        if (distance > flashItemsLimit)
        {
            item_sub.SetActive(false);
            canGetItem = false;
        }
            
    }

    // 마우스 나가면 비활성화
    private void OnMouseExit()
    {
        item_sub.SetActive(false);
        canGetItem = false;
    }

    // 마우스 클릭하면 아이템 먹음
    private void OnMouseUp()
    {
        if (canGetItem)
        {
            check_item = true;
            this.gameObject.SetActive(false);
        }
        

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 이 스크립트는 아이템을 먹으면 UI가 활성화 됩니다.
public class get_item_flash : MonoBehaviour
{
    public GameObject[] on_item;
    public GameObject[] get_item;
    public GameObject[] tools;
    public GameObject block;

    public bool[] check;

    private int[] connectToToolInfo;

    private ToolInformation[] toolsInfo;


    // Start is called before the first frame update
    // 도구 상태를 파악합니다.
    void Start()
    {
        toolsInfo = new ToolInformation[tools.Length];
        connectToToolInfo = new int[tools.Length];

        for (int i = 0; i < tools.Length; i++)
        {
            toolsInfo[i] = tools[i].GetComponent<ToolInformation>();
            connectToToolInfo[i] = toolsInfo[i].connectToOnOff;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // 랜덤으로 설정된 아이템을 가져옵니다.
        var Key_ran = GameObject.Find("key_o").GetComponent<Keyrandom>();
        for (int i = 0; i < Key_ran.key.Length; i++)
        {
            if (Key_ran.cnt[i] == 1)
            {
                get_item[1] = Key_ran.key[i];
            }
        }
        var Po_ran = GameObject.Find("po_o").GetComponent<Keyrandom>();
        for (int i = 0; i < Po_ran.key.Length; i++)
        {
            if (Po_ran.cnt[i] == 1)
            {
                get_item[0] = Po_ran.key[i];
            }
        }
        flash_item();
        clear_Game();
    }

    // 아이템을 먹었을 경우 아이템 UI가 활성화 됩니다.
    void flash_item()
    {
        for (int i = 0; i < on_item.Length; i++)
        {
            if (get_item[i])
            {
                check[i] = get_item[i].GetComponent<get_item>().check_item;  
                
            }
            if (check[i])
            {
                on_item[i].SetActive(true);
                for (int j = 0; j < tools.Length; j++)
                {
                    if (i == connectToToolInfo[j])
                    {
                        toolsInfo[j].isActive = true;
                        break;
                    }
                }
            }
        }

    }

    // 아이템 두개를 습득하면 문이 열립니다.
    void clear_Game()
    {
        if (check[0] == true && check[1] == true)
        {
            Debug.Log("Clear");
            block.SetActive(false);
        }

    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    void clear_Game()
    {
        if (check[0] == true && check[1] == true)
        {
            Debug.Log("Clear");
            block.SetActive(false);
        }

    }
}

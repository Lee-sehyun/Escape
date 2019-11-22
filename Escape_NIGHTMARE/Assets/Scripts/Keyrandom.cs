using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyrandom : MonoBehaviour
{

	public GameObject[] key;
	public int count;
    public int[] cnt;


	void Start()
    {
		count = Random.Range(0, key.Length);

        for (int i = 0; i < key.Length; i++)
		{
            if (i == count)
			{
				key[i].SetActive(true);
                cnt[i] = 1;
			}
            else
			{
				key[i].SetActive(false);
                cnt[i] = 0;
			}
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class On_off_message : MonoBehaviour
{
    public GameObject[] off_item;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseUp()
    {
        off_item[0].SetActive(true);
        off_item[1].SetActive(false);
    }
}

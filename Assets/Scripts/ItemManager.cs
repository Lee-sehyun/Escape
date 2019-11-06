using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameObject thePlayer;

    public float reactDist;
    private float distance;
    public bool check_onMouse;

    public bool isNear = false;

    void Start()
    {

    }


    void Update()
    {

        distance = Vector3.Distance(thePlayer.transform.position, transform.position);
        //Debug.Log(distance);

        NearCheck();
    }

    private void NearCheck()
    {
        if (distance <= reactDist && check_onMouse == false)
        {
            isNear = true;
        }
        else
        {
            isNear = false;
        }
    }
    private void OnMouseEnter()
    {
        check_onMouse = true;
    }
    private void OnMouseExit()
    {
        check_onMouse = false;
    }
}

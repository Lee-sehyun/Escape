using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonStart : MonoBehaviour
{
    public int number = 0;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void StartButton()
    {
        Application.LoadLevel(number);
    }

}

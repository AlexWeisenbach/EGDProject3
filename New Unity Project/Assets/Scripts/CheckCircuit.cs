using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Uduino;

public class CheckCircuit : MonoBehaviour
{
    UduinoManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = UduinoManager.Instance;
        manager.pinMode(3, PinMode.Input);   
    }

    // Update is called once per frame
    void Update()
    {
        int downValue = manager.digitalRead(3);
        print(downValue);
        if(downValue == 0)
        {
            //print("closed");
           // print("hello");

        }

        else
        {
           // print("open");
        }
    }
}

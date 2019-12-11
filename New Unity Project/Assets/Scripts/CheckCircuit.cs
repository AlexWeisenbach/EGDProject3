using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Uduino;

public class CheckCircuit : MonoBehaviour
{
    UduinoManager manager;
    public bool closedCircuit;

    // Start is called before the first frame update
    void Start()
    {
        closedCircuit = false;
        manager = UduinoManager.Instance;
        manager.pinMode(3, PinMode.Input);   
    }

    // Update is called once per frame
    void Update()
    {
        int downValue = manager.digitalRead(3);

        if(downValue == 0)
        {
            closedCircuit = true;
        }

        else
        {
            closedCircuit = false;
        }
    }
}

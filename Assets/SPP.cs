using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SPP : MonoBehaviour
{
    SerialPortUtility.SerialPortUtilityPro serialPort = null;

    void Start()
    {
        serialPort = this.GetComponent<SerialPortUtility.SerialPortUtilityPro>();
        serialPort.OpenMethod = SerialPortUtility.SerialPortUtilityPro.OpenSystem.BluetoothSSP;
        Debug.Log("serialPort:" + serialPort);

        if (serialPort != null)
        {
            //Debug.Log("serial port is not null");
            serialPort.Open();
            /*if (serialPort.IsOpened())
			{
				Debug.Log("writing");
				serialPort.WriteCRLF("Open");
				Debug.Log("wrote");
				Debug.Log("serialPort:" + serialPort);
			}
			else
			{
				Debug.Log("serial port is not opened");
			}*/
            //			Debug.Log("done");
        }
    }

    void Update()
    {
        if (!serialPort.IsOpened())
        {
            serialPort.Open();
            Debug.Log("serialport is opening");
        }
        if (Input.GetKeyDown("space") || Input.touchCount > 0)
        {
            Debug.Log("key was pressed");
            Debug.Log("writing");
            serialPort.WriteCRLF("unity");
            Debug.Log("wrote");
        }
    }


    public void ReadComplateString(object data)
    {
        var text = data as string;
        Debug.Log(text);
    }

}

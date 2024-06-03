using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System;

public class BluetoothManager : MonoBehaviour
{
    public string deviceName = "MyBluetoothDevice";
    public int baudRate = 9600;
    private SerialPort serialPort;

    void Start()
    {
        string[] ports = SerialPort.GetPortNames();
        foreach (string port in ports)
        {
            if (port.Contains("COM4")) // �Ϲ������� Windows���� ��������� COM ��Ʈ�� ����մϴ�
            {
                try
                {
                    serialPort = new SerialPort(port, baudRate);
                    serialPort.ReadTimeout = 1000;
                    serialPort.Open();
                    Debug.Log("Connected to port: " + port);
                    break;
                }
                catch (Exception e)
                {
                    Debug.LogWarning("Failed to open port: " + port + " - " + e.Message);
                }
            }
        }

        if (serialPort == null || !serialPort.IsOpen)
        {
            Debug.LogError("No suitable Bluetooth port found or unable to open port.");
        }
    }

    void Update()
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            try
            {
                string data = serialPort.ReadLine();
                Debug.Log("Received data from Bluetooth device: " + data);
                HandleReceivedData(data);
            }
            catch (TimeoutException)
            {
                // �б� Ÿ�Ӿƿ��� �����մϴ�.
            }
            catch (Exception e)
            {
                Debug.LogError("Error reading from serial port: " + e.Message);
            }
        }
    }

    void HandleReceivedData(string data)
    {
        if (data.Trim() == "w")
        {
            // w Ű ó��
        }
        else if (data.Trim() == "s")
        {
            // s Ű ó��
        }
    }

    public void SendData(string data)
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.Write(data);
        }
    }

    void OnDestroy()
    {
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.Close();
        }
    }
}
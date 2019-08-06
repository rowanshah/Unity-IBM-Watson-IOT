using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using IBMWIoTP;

public class Subscribe : MonoBehaviour
{
    public string orgId;
    public string deviceType;
    public string deviceId;
    public string authToken;
    public DeviceClient deviceClient;

    private static string mood;
    
    // Start is called before the first frame update
    void Start()
    {
        // enter your device details here
        mood = "";
        orgId = "";
        deviceType = "";
        deviceId = "";
        authToken = "";

        
        deviceClient = new DeviceClient(orgId,deviceType,deviceId,"token",authToken);
        /* try{
            
            deviceClient.publishEvent("current_emotion", "json", mood , 2);
            Debug.Log("connected");
        }
        catch(Exception ex){
            Debug.Log(ex);
        }*/
      

        
        try{
            deviceClient.connect();
            // change details here 
            deviceClient.subscribeCommand("event name", "format", 2);
            deviceClient.commandCallback += processCommand;
        }
        catch(Exception ex){
            Debug.Log(ex);
        }
        
        
        
    }

    public static void processCommand(string cmdName, string format, string data) {
        Debug.Log("Processed Command");
        Debug.Log(cmdName + " " + data);
        if (cmdName == "set_emotion"){
            mood = data;
        }
        Debug.Log(mood);
    }
}

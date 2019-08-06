using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using IBMWIoTP;

public class Publish : MonoBehaviour
{
    public string orgId;
    public string appId;
    public string apiKey;
    public string authToken;

    // Start is called before the first frame update
    void Start()
    {
        // enter your device details here
        orgId = "";
        appId = "";
        apiKey = "";
        authToken = "";

        ApplicationClient applicationClient = new ApplicationClient(orgId, appId, apiKey, authToken);
        try{
            applicationClient.connect();
            Debug.Log("Connected");
        }
        catch(Exception ex){
            Debug.Log(ex);
        }
        /* try{
            applicationClient.eventCallback += processEvent;
            applicationClient.subscribeToDeviceEvents("ChildApp", "123456");
        }
        catch(Exception ex){
            Debug.Log(ex);
        }*/

        try{
            // change details here
            applicationClient.publishCommand("device type", "device ID", "event Name", "format", "data", 2);
        }
        catch(Exception ex){
            Debug.Log(ex);
        }

    }
    public static void processEvent(string deviceType,string deviceId ,string eventName, string format, string data) {
        Debug.Log(eventName + " " + data);
        return;
    }
}

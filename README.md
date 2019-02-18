# CentralDatabase
# Author : Pankaj Verma

Share date between two or more unity app using Plugin

#USE:
Place class file to \Assets\Plugins\Android Directory
Place AndroidManifest file to \Assets\Plugins Directory 



#Script
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PluginTest : MonoBehaviour {


    public Text result;
    public InputField inputFieldKey;
    public InputField inputFieldValue;

    AndroidJavaObject androidJavaClass;

    private void Awake()
    {
        AndroidJavaClass objct = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject context = objct.GetStatic<AndroidJavaObject>("currentActivity");
        androidJavaClass = new AndroidJavaObject("com.example.dbprovider.KVDBHandler");
        androidJavaClass.Call("SetContext", context);
    }


    public void AddKey()
    {
        string key = inputFieldKey.text.ToString();
        string value = inputFieldValue.text.ToString();

        if (key == null || key == "")
            result.text = "Error : Key is empty";
        else
        {
            if(androidJavaClass.Call<bool>("HasKey", key))
            {
                result.text = "Key Updated";
            }
            else
            {
                result.text = "Key Added";
            }

            androidJavaClass.Call("SetKey", key, value);
        }
    }


    public void GetKey()
    {
        string key = inputFieldKey.text.ToString();

        if (key == null || key == "")
            result.text = "Error : Key is empty";
        else
        {
            if (androidJavaClass.Call<bool>("HasKey", key))
            {
                result.text = androidJavaClass.Call<string>("GetValue", key);
            }
            else
            {
                result.text = "Error : Key Not found";
            }
        }

    }


    public void DeleteKey()
    {
        string key = inputFieldKey.text.ToString();

        if (key == null || key == "")
            result.text = "Error : Key is empty";
        else
        {
            if (androidJavaClass.Call<bool>("HasKey", key))
            {
                androidJavaClass.Call("DeleteKey", key);
                result.text = "Key Deleted";
            }
            else
            {
                result.text = "Error : Key Not found";
            }
        }
    }


}




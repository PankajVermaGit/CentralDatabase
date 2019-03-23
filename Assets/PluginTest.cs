using KVDB;
using UnityEngine;
using UnityEngine.UI;

public class PluginTest : MonoBehaviour {

    KVDBHandler kVDBHandler;

    public Text result;
    public InputField inputFieldKey;
    public InputField inputFieldValue;

    private void Start()
    {
        kVDBHandler = new KVDBHandler();
    }


    public void AddKey()
    {
        string key = inputFieldKey.text.ToString();
        string value = inputFieldValue.text.ToString();

        if (key == null || key == "")
            result.text = "Error : Key is empty";
        else
        {
            kVDBHandler.AddKey(key, value);
            result.text = "Key Added";
        }
    }


    public void GetKey()
    {
        string key = inputFieldKey.text.ToString();

        if (key == null || key == "")
            result.text = "Error : Key is empty";
        else
        {
            if (kVDBHandler.HasKey(key))
            {
                result.text = kVDBHandler.GetValue(key);
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
            if (kVDBHandler.HasKey( key))
            {
                kVDBHandler.DeleteKey( key);
                result.text = "Key Deleted";
            }
            else
            {
                result.text = "Error : Key Not found";
            }
        }
    }

}

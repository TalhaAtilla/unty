using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class sql : MonoBehaviour
{
    void Start()
    {
        // A correct website page.
       StartCoroutine(GetRequest("http://localhost/sql/sql.php"));

        // A non-existing page.
       
    }

    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    string raw = webRequest.downloadHandler.text;
                    string[] data = raw.Split("/");
                    foreach (string way in data) { 
                        
                        string[] lost = way.Split(",");
                        foreach (string one in lost)
                            Debug.Log(pages[page] + ":\nReceived: " + one);
                    }
                    
                    break;
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        StartCoroutine(GetRequest("http://localhost/sql/sql.php"));
    }
}

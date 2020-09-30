using SubstrateNetApi;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class MetaDataCrawler : MonoBehaviour
{
    private const string WEBSOCKETURL = "wss://boot.worldofmogwais.com";

    private SubstrateClient _client;

    public Image ImgConnect;

    public Text TxtConnect;

    public Text TxtButton;

    public Text TxtMetaData;

    private Task _awaitableTask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_awaitableTask != null && _awaitableTask.IsCompleted)
        {
            if (_client != null && _client.IsConnected)
            {
                ImgConnect.color = Color.green;
                TxtConnect.text = "On";
                TxtButton.text = "Disconnect";
                TxtMetaData.text = _client.MetaData.Serialize();
            } 
            else
            {
                ImgConnect.color = Color.red;
                TxtConnect.text = "Off";
                TxtButton.text = "Connect";

            }
            
            _awaitableTask = null;
        }
    }

    private async Task ConnectAsync()
    {
        _client = new SubstrateClient(new Uri(WEBSOCKETURL));
        await _client.ConnectAsync();
    }

    private async Task CloseAsync()
    {
        _client = new SubstrateClient(new Uri(WEBSOCKETURL));
        await _client.CloseAsync();
    }

    public void GetMetaDataClicked()
    {
        if (_client != null && _client.IsConnected)
        {
            _awaitableTask = CloseAsync();
        }
        else
        {
            _awaitableTask = ConnectAsync();
        }

    }
}

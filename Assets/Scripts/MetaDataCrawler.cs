using SubstrateNetApi;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class MetaDataCrawler : MonoBehaviour
{
    private const string WEBSOCKETURL = "wss://boot.worldofmogwais.com";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetMetaDataClickedAsync()
    {
        var client = new SubstrateClient(new Uri(WEBSOCKETURL));

        var connect = client.ConnectAsync();
        //connect.Wait();

        //var systemName = client.System.NameAsync();
        //systemName.Wait();

        //var systemVersion = client.System.VersionAsync();
        //systemVersion.Wait();

        //var systemChain = client.System.ChainAsync();
        //systemChain.Wait();

        //Debug.Log($"Connected to System: {systemName} Chain: {systemChain} Version: {systemVersion}.");

        //Debug.Log(client.MetaData.Serialize());

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using Unity.Mathematics;

public class Map : MonoBehaviour
{
    public string apiKey;
    public float lat=0.0f;
    public float lon=0.0f;
    public int zoom=14;
    public enum resolution {low=1,high=2};
    public resolution mapResolution=resolution.low;
    public enum type {roadmap,satellite,hybrid,terrain};
    public type mapType=type.roadmap;
    private string url="";
    private int mapWidth=200;
    private int mapHeight=200;
    private bool mapIsLoading=false;
    private Rect rect;
    private string apiKeyLast;

    private float latLast=0.0f;
    private float lonLast=0.0f;
    private int zoomLast=14;
    private resolution mapResolutionLast=resolution.low;
    private type mapTypeLast=type.roadmap;
    private bool updateMap=true;

    void Start()
    {
        StartCoroutine(GetGoogleMap());
        rect=gameObject.GetComponent<RawImage>().rectTransform.rect;
        mapWidth=(int)Math.Round(rect.width);
        mapHeight=(int)Math.Round(rect.height);
    }

    void Update()
    {
        if(updateMap && (apiKeyLast!=apiKey || !Mathf.Approximately(latLast,lat) || !Mathf.Approximately(lonLast,lon) || zoomLast != zoom || mapResolutionLast != mapResolution || mapTypeLast != mapType))
        {
            rect=gameObject.GetComponent<RawImage>().rectTransform.rect;
            mapWidth=(int)Math.Round(rect.width);
            mapHeight=(int)Math.Round(rect.height);
            StartCoroutine(GetGoogleMap());
            updateMap=false;
        }
    }

    IEnumerator GetGoogleMap()
    {
        url="https://maps.googleapis.com/maps/api/staticmap?center="+lat+","+lon+"&zoom="+zoom+"&size="+mapWidth+"x"+mapHeight+"&scale="+mapResolution+"&maptype="+mapType+"&key="+apiKey;
        mapIsLoading=true;
        UnityWebRequest www=UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();
        if(www.result!=UnityWebRequest.Result.Success)
        {
            Debug.Log("WWW ERROR: "+www.error);
        }else
        {
            mapIsLoading=false;
            Texture2D texture=DownloadHandlerTexture.GetContent(www);
            gameObject.GetComponent<RawImage>().texture=texture;

            apiKeyLast=apiKey;
            latLast=lat;
            lonLast=lon;
            zoomLast=zoom;
            mapResolutionLast=mapResolution;
            mapTypeLast=mapType;
            updateMap=true;
        }
    }
}

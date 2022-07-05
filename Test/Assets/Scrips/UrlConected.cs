using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class UrlConected : MonoBehaviour
{

    [SerializeField] RawImage quad;
    public WeatherCityEvent weatherEvent;

    public void ReciveWeatherCity(WeatherCity weather)
    {
        weatherEvent.Invoke(weather);
    }

    public void ReadWeatherCity(string city)
    {
        string uri = $"https://goweather.herokuapp.com/weather/ {city}";
        StartCoroutine(GetRequest<WeatherCity>(uri, ReciveWeatherCity));
    }

    public void ReciveIpInfo(IpInfo info)
    {

    }

    public void ReciveDogsImage(DogImages dogs)
    {
        StartCoroutine(GetImageRequest(dogs.message, AsingImageToUI));
    }

    public void ReadIpInfo(string uri)
    {
        StartCoroutine(GetRequest<IpInfo>(uri, ReciveIpInfo));
    }

    public void ReadDogsImage()
    {
        string uri = "https://dog.ceo/api/breeds/image/random";
        StartCoroutine(GetRequest<DogImages>(uri, ReciveDogsImage));
    }

    public void AsingImageToUI(Texture2D texture)
    {
        quad.texture = texture;
    }

    IEnumerator GetRequest<T>(string uri, Action<T> callback)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();


            switch (webRequest.result)
            {
                case UnityWebRequest.Result.Success:

                    string result = webRequest.downloadHandler.text;

                    T jsonClass = JsonUtility.FromJson<T>(result);

                    callback?.Invoke(jsonClass);

                    break;
            }
        }
    }

    IEnumerator GetImageRequest(string uri, Action<Texture2D> callback)
    {
        using (UnityWebRequest webRequestTexture = UnityWebRequestTexture.GetTexture(uri))
        {
            yield return webRequestTexture.SendWebRequest();

            if (webRequestTexture.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(webRequestTexture.error);
            }
            else
            {
                callback?.Invoke(DownloadHandlerTexture.GetContent(webRequestTexture));
            }
        }
    }

}


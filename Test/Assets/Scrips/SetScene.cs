using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetScene : MonoBehaviour
{
    [SerializeField] Slider rainIntensive;
    [SerializeField] Slider hour;

    [SerializeField] Terrain terrain;
    CityInput city;

    private void Awake()
    {
        city = GameObject.Find("CityInput").GetComponent<CityInput>();
    }
    void Start()
    {
        if (city.weather.description.Contains("rain")) 
        {
            rainIntensive.value = 1f;
        }
        else
        {
            rainIntensive.value = 1f;
        }

        terrain.terrainData.wavingGrassSpeed = float.Parse(city.weather.wind.Split(' ')[0]); //Chequear
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

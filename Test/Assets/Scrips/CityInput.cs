
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class CityInput : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    public UnityEvent<string> cityEvent;
    public WeatherCity weather;

    string city;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        inputField.onEndEdit.AddListener(UpdateWeather);
    }

    void UpdateWeather(string IFcity)
    {
        city = IFcity;
          
        //Se deberia chequear que sea correcta la ciudad

        cityEvent.Invoke(city);
    }
        
    public void ReciveWeatherCity(WeatherCity weatherCity)
    {
        weather = weatherCity;

        SceneManager.LoadScene("WeatherScene");
    }

    
}

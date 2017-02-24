using UnityEngine;

public class WeatherController : MonoBehaviour
{
    [SerializeField]
    private Material sky;
    [SerializeField]
    private Light sun;

    private float _fullIntensity;
    private float _cloudValue = 0f;
    private float _currentCloudValue = 0f;

    void Awake()
    {
        Messenger.AddListener(GameEvent.WEATHER_UPDATED, OnWeatherUpdated);
    }

    void Start()
    {
        _fullIntensity = sun.intensity;
    }

    void Update()
    {
        if (0f != _currentCloudValue)
        {
            SetOvercast(_cloudValue);

            if (_cloudValue < _currentCloudValue)
            {
                _cloudValue = _cloudValue + 0.002f;
            }
            else
            {
                _cloudValue = _currentCloudValue;
            }
        }
    }

    void OnDestroy()
    {
        Messenger.RemoveListener(GameEvent.WEATHER_UPDATED, OnWeatherUpdated);
    }

    private void OnWeatherUpdated()
    {
        _currentCloudValue = Managers.Weather.cloudValue;
        // SetOvercast(_currentCloudValue);
    }

    private void SetOvercast(float value)
    {
        sky.SetFloat("_Blend", value);
        sun.intensity = _fullIntensity - (_fullIntensity * value);
    }
}

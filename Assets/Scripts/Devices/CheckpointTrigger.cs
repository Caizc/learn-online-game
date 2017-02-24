using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    public string identifier;

    private bool _isTriggered;

    void OnTriggerEnter(Collider other)
    {
        if (_isTriggered)
        {
            return;
        }

        Managers.Weather.LogWeather(identifier);
        _isTriggered = true;
    }
}

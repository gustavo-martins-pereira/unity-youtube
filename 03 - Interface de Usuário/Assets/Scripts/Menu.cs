using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject startMenu, settingsMenu;
    public Light lamp;

    public void OpenMenu(bool open)
    {
        startMenu.SetActive(open);
        settingsMenu.SetActive(!open);
    }

    public void SetLightIntensity(float intensity)
    {
        lamp.intensity = intensity;
    }

    public void SetLight(bool on)
    {
        lamp.enabled = on;
    }
}

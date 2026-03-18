using UnityEditor.Events;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    public Slider slider;
    void Start()
    {
        UnityEventTools.RemovePersistentListener(slider.onValueChanged, 0);
        UnityEventTools.AddPersistentListener(slider.onValueChanged, findGameObjectWithTag("SoundManager").getcomponent.)
    }

    void Update()
    {
    }
}

using Unity.VisualScripting;
using UnityEditor.Events;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    public Slider slider;
    AudioSource audioSource;
    void Start()
    {
        //UnityEventTools.RemovePersistentListener(slider.onValueChanged, 0);
        //UnityAction<float> tempAction = new UnityAction<float>(GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManagerScript>().UpdateVolume);
        //UnityEventTools.AddFloatPersistentListener(slider.onValueChanged, tempAction, slider.value);
        audioSource = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<AudioSource>();
        slider.value = audioSource.volume;
    }

    void Update()
    {
    }
}

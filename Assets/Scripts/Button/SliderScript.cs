using Unity.VisualScripting;
using UnityEditor.Events;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    public Slider slider;
    void Start()
    {
        //UnityEventTools.RemovePersistentListener(slider.onValueChanged, 0);
        //UnityAction<float> tempAction = new UnityAction<float>(GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManagerScript>().UpdateVolume);
        //UnityEventTools.AddFloatPersistentListener(slider.onValueChanged, tempAction, slider.value);
        
    }

    void Update()
    {
    }
}

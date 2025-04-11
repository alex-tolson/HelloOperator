using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource _audiosource;
    [SerializeField] private AudioClip[] _pluginCableAudio;
    [SerializeField] private AudioClip[] _lightSwitchAudio;
    [SerializeField] private AudioClip[] _unplugCableAudio;
    [SerializeField] private AudioClip[] _turnPageAudio;

    [SerializeField] AudioClip _pluginCable0;
    [SerializeField] AudioClip _pluginCable1;
    [SerializeField] AudioClip _pluginCable2;
    [SerializeField] AudioClip _pluginCable3;
    [SerializeField] AudioClip _pluginCable4;
    [SerializeField] AudioClip _pluginCable5;
    [SerializeField] AudioClip _pluginCable6;
    [SerializeField] AudioClip _pluginCable7;

    [SerializeField] AudioClip _unplugCable0;
    [SerializeField] AudioClip _unplugCable1;
    [SerializeField] AudioClip _unplugCable2;
    [SerializeField] AudioClip _unplugCable3;

    [SerializeField] AudioClip _lightSwitch0;
    [SerializeField] AudioClip _lightSwitch1;
    [SerializeField] AudioClip _lightSwitch2;
    [SerializeField] AudioClip _lightSwitch3;
    [SerializeField] AudioClip _lightSwitch4;
    [SerializeField] AudioClip _lightSwitch5;

    [SerializeField] AudioClip _buttonClick;
    [SerializeField] AudioClip _bellSound;

    [SerializeField] AudioClip _turnPage0;
    [SerializeField] AudioClip _turnPage1;
    [SerializeField] AudioClip _turnPage2;
    [SerializeField] AudioClip _turnPage3;
    [SerializeField] AudioClip _turnPage4;
    [SerializeField] AudioClip _turnPage5;
    [SerializeField] AudioClip _turnPage6;


    // Start is called before the first frame update
    void Start()
    {
        _audiosource = GetComponent<AudioSource>();
        _pluginCableAudio = new AudioClip[] { _pluginCable0, _pluginCable1, _pluginCable2, _pluginCable3, _pluginCable4,
        _pluginCable5, _pluginCable6, _pluginCable7};
        _lightSwitchAudio = new AudioClip[] { _lightSwitch0, _lightSwitch1, _lightSwitch2, _lightSwitch3, _lightSwitch4, _lightSwitch5 };
        _unplugCableAudio = new AudioClip[] { _unplugCable0, _unplugCable0, _unplugCable2, _unplugCable3 };
        _turnPageAudio = new AudioClip[] { _turnPage0, _turnPage1, _turnPage2, _turnPage3, _turnPage4, _turnPage5, _turnPage6 };

    }

    public void PlayRandomPlugin()
    {
        int randomElement = (Random.Range(0, 8));
        _audiosource.PlayOneShot(_pluginCableAudio[randomElement]);
    }
    public void PlayRandomUnPlug()
    {
        int randomElement = (Random.Range(0, 4));
        _audiosource.PlayOneShot(_unplugCableAudio[randomElement]);
    }
    public void PlayRandomLightSwitch()
    {
        int randomElement = (Random.Range(0, 6));
        _audiosource.PlayOneShot(_lightSwitchAudio[randomElement]); 
    }

    public void PlayRandomTurnPage()
    {
        int randomElement = (Random.Range(0, 7));
        _audiosource.PlayOneShot(_turnPageAudio[randomElement]);
    }

    public void PlayButtonClick()
    {
        _audiosource.PlayOneShot(_buttonClick);
    }
    
    public void PlayBell()
    {
        _audiosource.PlayOneShot(_bellSound);
    }
}

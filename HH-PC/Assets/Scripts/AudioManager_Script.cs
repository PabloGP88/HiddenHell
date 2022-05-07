using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager_Script : MonoBehaviour
{
    private AudioSource _audio;

    [SerializeField] private AudioClip[] sounds;


    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
    }

    public void SelectSound(int id_Array, float volume)
    {
        _audio.PlayOneShot(sounds[id_Array], volume);
    }

}

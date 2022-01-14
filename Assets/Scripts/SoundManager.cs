using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour {
    public bool MuteMasterSound = false;
    [Range(0f, 1f)]
    public float MasterSoundVolume = 1f;



    public Sound[] sounds;

    public static SoundManager instance;

    public static SoundManager getInstance() {
        return instance;
    }


    void Awake() {
        if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound _sound in sounds) {
            _sound.init(gameObject.AddComponent<AudioSource>());
        }
    }

    public Sound getSound(string name) {
        return Array.Find(sounds, sound => sound.name == name);
    }

    public void play(string name) {
        try {
            Sound sound = Array.Find(sounds, sound => sound.name == name);
            sound.playSound();
        } catch (NullReferenceException) {
            Debug.LogWarning("The sound with the name '" + name + "' does not exist in our list. Make sure you register the sound.");
            return;
        }
    }

    public void mute(string name, bool status) {
        try {
            Sound sound = Array.Find(sounds, sound => sound.name == name);
            sound.setMute(status);
        } catch (NullReferenceException) {
            Debug.LogWarning("The sound with the name '" + name + "' does not exist in our list. Make sure you register the sound.");
            return;
        }
    }

    public void stop(string name) {
        try {
            Sound sound = Array.Find(sounds, sound => sound.name == name);
            sound.stopSound();
        } catch (NullReferenceException) {
            Debug.LogWarning("The sound with the name '" + name + "' does not exist in our list. Make sure you register the sound.");
            return;
        }
    }

    public void setVolume(string name, float volume) {
        try {
            Sound sound = Array.Find(sounds, sound => sound.name == name);
            sound.setVolume(volume);
        } catch (NullReferenceException) {
            Debug.LogWarning("The sound with the name '" + name + "' does not exist in our list. Make sure you register the sound.");
            return;
        }
    }
}

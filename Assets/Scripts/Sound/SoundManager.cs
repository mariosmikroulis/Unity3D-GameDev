using System;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    // Allows to control master sounds, SFX, Music

    // All global volume controllers.
    public bool MuteMasterSound = false;
    [Range(0f, 1f)]
    public float MasterSoundVolume = 1f;

    public bool MuteMusicSound = false;
    [Range(0f, 1f)]
    public float MusicSoundVolume = 1f;

    public bool MuteSFXSound = false;
    [Range(0f, 1f)]
    public float SFXSoundVolume = 1f;


    public Sound[] sounds;

    public static SoundManager instance;

    // Gets the SoundManager instance
    public static SoundManager getInstance() {
        return instance;
    }


    void Awake() {
        /*
         if (instance == null) {
            instance = this;
        } else {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        */
        instance = this;

        foreach (Sound _sound in sounds) {
            if (_sound.clip) {
                if (_sound.custom) {
                    Debug.LogWarning("An audio source and a custom object were added. If will ignore the custom object instead.");
                }

                _sound.setSource(gameObject.AddComponent<AudioSource>());
            } else if(_sound.custom) {
                _sound.setCustomSource();
            } else {
                Debug.LogWarning("An audio source for '" + name + "' was not loaded because both gameObject and clip are not set. Setup one of them if you want settings to take effect.");
            }
        }
    }

    // Checks if master sounnd is muted
    public bool isMasterSoundMuted() {
        return MuteMasterSound;
    }

    // Mutes master sound
    public void setMasterSoundMuted(bool status) {
        MuteMasterSound = status;

        foreach(Sound _sound in sounds) {
            _sound.setMute(_sound.isMuted());
        }
    }

    // Gets the volume of master sound
    public float getMasterSoundVolume() {
        return MasterSoundVolume;
    }

    // Sets the volume of master sound
    public void setMasterSoundVolume(float _volume) {
        Debug.Log(_volume);
        if (_volume < .0f) {
            _volume = .0f;
        } else if (_volume > 1f) {
            _volume = 1f;
        }

        MasterSoundVolume = _volume;

        foreach (Sound _sound in sounds) {
            _sound.setVolume(_sound.getVolume());
        }
    }

    // Checks if music is muted
    public bool isMusicSoundMuted() {
        return MuteMusicSound;
    }

    // Sets music to muted
    public void setMusicSoundMuted(bool status) {
        MuteMusicSound = status;

        foreach (Sound _sound in sounds) {
            if (_sound.getType() == SoundType.Music) {
                _sound.setMute(_sound.isMuted());
            }
        }
    }

    // Gets music volume
    public float getMusicSoundVolume() {
        return MusicSoundVolume;
    }

    // Sets music volume
    public void setMusicSoundVolume(float _volume) {
        if (_volume < .0f) {
            _volume = .0f;
        } else if (_volume > 1f) {
            _volume = 1f;
        }

        MusicSoundVolume = _volume;

        foreach (Sound _sound in sounds) {
            _sound.setVolume(_sound.getVolume());
        }
    }

    // Checks if SFX is muted
    public bool isSFXSoundMuted() {
        return MuteSFXSound;
    }

    // Mutes SFX
    public void setSFXSoundMuted(bool status) {
        MuteSFXSound = status;

        foreach (Sound _sound in sounds) {
            if (_sound.getType() == SoundType.SFX) {
                _sound.setMute(_sound.isMuted());
            }
        }
    }

    // Gets SFX volume
    public float getSFXSoundVolume() {
        return SFXSoundVolume;
    }

    // Sets SFX volume
    public void setSFXSoundVolume(float _volume) {
        if (_volume < .0f) {
            _volume = .0f;
        } else if (_volume > 1f) {
            _volume = 1f;
        }

        SFXSoundVolume = _volume;

        foreach (Sound _sound in sounds) {
            _sound.setVolume(_sound.getVolume());
        }
    }

    // Gets a sound by name
    public Sound getSound(string name) {
        return Array.Find(sounds, sound => sound.name == name);
    }

    // Plays a sound by name
    public void play(string name) {
        try {
            foreach (Sound _sound in sounds) {
                if (_sound.name == name) {
                    _sound.playSound();
                }
            }
        } catch (NullReferenceException) {
            Debug.LogWarning("The sound with the name '" + name + "' does not exist in our list. Make sure you register the sound.");
            return;
        }
    }

    // Toggles mute on a sound
    public void mute(string name, bool status) {
        try {
            foreach (Sound _sound in sounds) {
                if (_sound.name == name) {
                    _sound.setMute(status);
                }
            }
        } catch (NullReferenceException) {
            Debug.LogWarning("The sound with the name '" + name + "' does not exist in our list. Make sure you register the sound.");
            return;
        }
    }

    // Stops a sound
    public void stop(string name) {
        try {
            foreach (Sound _sound in sounds) {
                if (_sound.name == name) {
                    _sound.stopSound();
                }
            }
        } catch (NullReferenceException) {
            Debug.LogWarning("The sound with the name '" + name + "' does not exist in our list. Make sure you register the sound.");
            return;
        }
    }

    // Sets volume on a sound
    public void setVolume(string name, float volume) {
        try {
            foreach (Sound _sound in sounds) {
                if (_sound.name == name) {
                    _sound.setVolume(volume);
                }
            }
        } catch (NullReferenceException) {
            Debug.LogWarning("The sound with the name '" + name + "' does not exist in our list. Make sure you register the sound.");
            return;
        }
    }
}

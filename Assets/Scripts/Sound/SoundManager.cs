using System;
using UnityEngine;

public class SoundManager : MonoBehaviour {
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

    public bool isMasterSoundMuted() {
        return MuteMasterSound;
    }

    public void setMasterSoundMuted(bool status) {
        MuteMasterSound = status;

        foreach(Sound _sound in sounds) {
            _sound.setMute(_sound.isMuted());
        }
    }

    public float getMasterSoundVolume() {
        return MasterSoundVolume;
    }

    public void setMasterSoundVolume(float _volume) {
        if (_volume < .0f) {
            _volume = .0f;
        } else if (_volume > 1f) {
            _volume = 1f;
        }

        MasterSoundVolume = _volume;
    }

    public bool isMusicSoundMuted() {
        return MuteMusicSound;
    }

    public void setMusicSoundMuted(bool status) {
        MuteMusicSound = status;

        foreach (Sound _sound in sounds) {
            if (_sound.getType() == SoundType.Music) {
                _sound.setMute(_sound.isMuted());
            }
        }
    }

    public float getMusicSoundVolume() {
        return MusicSoundVolume;
    }

    public void setMusicSoundVolume(float _volume) {
        if (_volume < .0f) {
            _volume = .0f;
        } else if (_volume > 1f) {
            _volume = 1f;
        }

        MusicSoundVolume = _volume;
    }

    public bool isSFXSoundMuted() {
        return MuteSFXSound;
    }

    public void setSFXSoundMuted(bool status) {
        MuteSFXSound = status;

        foreach (Sound _sound in sounds) {
            if (_sound.getType() == SoundType.SFX) {
                _sound.setMute(_sound.isMuted());
            }
        }
    }

    public float getSFXSoundVolume() {
        return SFXSoundVolume;
    }

    public void setSFXSoundVolume(float _volume) {
        if (_volume < .0f) {
            _volume = .0f;
        } else if (_volume > 1f) {
            _volume = 1f;
        }

        SFXSoundVolume = _volume;
    }

    public Sound getSound(string name) {
        return Array.Find(sounds, sound => sound.name == name);
    }

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

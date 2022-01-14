using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string name;

    // Use either an Audio Clip or a gameObject to set the audio settings etc.
    public AudioClip clip;
    public Transform custom;

    public SoundType type = SoundType.Music;

    [Range(0f, 1f)]
    public float volume = 1f;

    [Range(.1f, 3f)]
    public float pitch = 1f;

    public bool play = false;
    public bool mute = false;
    public bool loop = false;

    [HideInInspector]
    public AudioSource source;

    public string getName() {
        return name;
    }

    public void setName(string _name) {
        name = _name;
    }

    public SoundType getType() {
        return type;
    }

    public void setType(SoundType _type) {
        type = _type;
        setVolume(volume);
    }

    public AudioClip getClip() {
        return clip;
    }

    public void setClip(AudioClip _clip) {
        clip = _clip;
    }

    public float getPitch() {
        return pitch;
    }

    public void setPitch(float _pitch)
    {
        if (_pitch < .1f)
        {
            _pitch = .1f;
        }
        else if (_pitch > 3f)
        {
            _pitch = 3f;
        }

        pitch = _pitch;
        source.pitch = _pitch;
    }

    public void setVolume(float _volume) {
        SoundManager master = SoundManager.getInstance();

        if (_volume < .0f) {
            _volume = .0f;
        } else if(_volume > 1f) {
            _volume = 1f;
        }

        volume = _volume;

        if (type == SoundType.Music) {
            source.volume = _volume * master.getMasterSoundVolume() * master.getMusicSoundVolume();
        } else if(type == SoundType.SFX) {
            source.volume = _volume * master.getMasterSoundVolume() * master.getSFXSoundVolume();
        }
    }

    public float getSourceVolume() {
        return source.volume;
    }

    public float getVolume() {
        return volume;
    }

    public void setMute(bool status) {
        mute = status;
        source.mute = isSourceMuted();
    }

    public bool isMuted() {
        return mute == true;
    }

    public bool isSourceMuted() {
        SoundManager master = SoundManager.getInstance();
        return mute || master.isMasterSoundMuted() || type == SoundType.Music && master.isMusicSoundMuted() || type == SoundType.SFX && master.isSFXSoundMuted();
    }

    public void setLoop(bool _loop) {
        loop = _loop;
        source.loop = _loop;
    }

    public bool isLooped() {
        return loop == true;
    }

    public AudioSource getSource() {
        return source;
    }

    public void setSource(AudioSource _source) {
        source = _source;

        setClip(clip);

        setVolume(volume);
        setType(type);
        setPitch(pitch);
        setLoop(loop);
        setMute(mute);
    }

    public void setCustomSource() {
        source = custom.GetComponent<AudioSource>();
        clip = source.clip;
        pitch = source.pitch;
        loop = source.loop;
        setVolume(source.volume);
        setMute(source.mute);
    }

    public void playSound() {
        source.Play();
        play = true;
    }

    public void stopSound() {
        source.Stop();
        play = false;
    }

    public bool isPlaying() {
        return source.isPlaying;
    }
}

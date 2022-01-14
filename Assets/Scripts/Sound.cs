using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume = 1f;

    [Range(.1f, 3f)]
    public float pitch = 1f;

    public bool play = false;
    public bool mute = false;
    public bool loop = false;

    [HideInInspector]
    public AudioSource source;

    public void init(AudioSource _source) {
        setSource(_source);
        setClip(clip);

        setVolume(volume);
        setPitch(pitch);
        setLoop(loop);
        setMute(mute);
    }

    public string getName() {
        return name;
    }

    public void setName(string _name) {
        name = _name;
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
        if(_volume < .0f) {
            _volume = .0f;
        } else if(_volume > 1f) {
            _volume = 1f;
        }

        volume = _volume;
        source.volume = _volume;
    }

    public float getVolume() {
        return volume;
    }

    public void setMute(bool status) {
        mute = status;
        source.mute = status;
    }

    public bool isMuted() {
        return mute == true;
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
    }

    public void playSound() {
        source.Play();
        play = true;
    }

    public void stopSound() {
        source.Stop();
        play = false;
    }
}

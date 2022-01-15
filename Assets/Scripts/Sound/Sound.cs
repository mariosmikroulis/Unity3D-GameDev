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

    //Return sound name
    public string getName() {
        return name;
    }

    //Set sound name
    public void setName(string _name) {
        name = _name;
    }

    //Get sound type
    public SoundType getType() {
        return type;
    }

    //Set sound type
    public void setType(SoundType _type) {
        type = _type;
        setVolume(volume);
    }

    //Gets sound clip
    public AudioClip getClip() {
        return clip;
    }

    //Sets sound clip
    public void setClip(AudioClip _clip) {
        clip = _clip;
    }

    //Gets sound pitch
    public float getPitch() {
        return pitch;
    }

    //Sets sound pitch
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

    //Sets sound volume
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

    //Get the source volume of the sound
    public float getSourceVolume() {
        return source.volume;
    }

    //Get the current volume
    public float getVolume() {
        return volume;
    }

    //Toggles mute on the sound
    public void setMute(bool status) {
        mute = status;
        source.mute = isSourceMuted();
    }

    //Checks if sound is muted
    public bool isMuted() {
        return mute == true;
    }

    //Checks if source is muted
    public bool isSourceMuted() {
        SoundManager master = SoundManager.getInstance();
        return mute || master.isMasterSoundMuted() || type == SoundType.Music && master.isMusicSoundMuted() || type == SoundType.SFX && master.isSFXSoundMuted();
    }

    //Allows sound to play in a loop
    public void setLoop(bool _loop) {
        loop = _loop;
        source.loop = _loop;
    }

    //Checks if sound is on a loop
    public bool isLooped() {
        return loop == true;
    }

    //Get sound AudioSource
    public AudioSource getSource() {
        return source;
    }

    //Set sound AudioSource
    public void setSource(AudioSource _source) {
        source = _source;

        setClip(clip);

        setVolume(volume);
        setType(type);
        setPitch(pitch);
        setLoop(loop);
        setMute(mute);
    }

    //Sets a custom AudioSource
    public void setCustomSource() {
        source = custom.GetComponent<AudioSource>();
        clip = source.clip;
        pitch = source.pitch;
        loop = source.loop;
        setVolume(source.volume);
        setMute(source.mute);
    }

    //Plays the sound
    public void playSound() {
        source.Play();
        play = true;
    }

    //Stops the sound
    public void stopSound() {
        source.Stop();
        play = false;
    }

    //Checks if sound is playing
    public bool isPlaying() {
        return source.isPlaying;
    }
}

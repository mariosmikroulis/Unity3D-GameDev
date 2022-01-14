using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour {
    PlayerController cc;
    Sound footsteps_sound;
    Sound running_sound;
    Sound jumping_sound;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<PlayerController>();
        footsteps_sound = SoundManager.getInstance().getSound("footsteps");
        running_sound = SoundManager.getInstance().getSound("running");
        jumping_sound = SoundManager.getInstance().getSound("jumping");
    }

    // Update is called once per frame
    void Update()
    {
        //bool touchingFloor = cc.touchingFloor;
        bool touchingFloor = true;

        //if (cc.touchingFloor && cc.moveValue.magnitude != 0 && !sound.play) {
        if (cc.moveValue.magnitude != 0 && !footsteps_sound.isPlaying()) {
            if (!cc.running && touchingFloor) {
                footsteps_sound.setVolume(Random.Range(0.8f, 1));
                footsteps_sound.setPitch(Random.Range(0.8f, 1.1f));
                footsteps_sound.playSound();
            } else if(cc.running && touchingFloor) {
                running_sound.setVolume(Random.Range(0.8f, 1));
                running_sound.setPitch(Random.Range(0.8f, 1.1f));
                running_sound.playSound();
            } else if(touchingFloor) {
                jumping_sound.setVolume(Random.Range(0.8f, 1));
                jumping_sound.setPitch(Random.Range(0.8f, 1.1f));
                jumping_sound.playSound();
            }
        }
    }
}

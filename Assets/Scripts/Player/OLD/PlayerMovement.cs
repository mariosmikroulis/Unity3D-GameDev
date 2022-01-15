using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    private static PlayerMovement instance;

    Sound footsteps_sound;
    Sound running_sound;
    Sound jumping_sound;

    public float speed = 12f;
    public float runningSpeed = 18f;
    public float gravity = -19.62f;
    public float jumpHeight = 3f;
    public float currentSpeed = 12f;

    public Transform groundCheck;
    public float groundDistance = 0.1f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool grounded = false;
    bool running = false;
    bool jump_key_pressed = false;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    private void Start() {
        footsteps_sound = SoundManager.getInstance().getSound("footsteps");
        running_sound = SoundManager.getInstance().getSound("running");
        jumping_sound = SoundManager.getInstance().getSound("jumping");
    }

    public static PlayerMovement getInstance() {
        return instance;
    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        jump_key_pressed = false;

        if(grounded && velocity.y < 0) {
            // could remove Health Life.
            velocity.y = -2f;

            running = false;
            currentSpeed = speed;

            if (Input.GetKey(KeyCode.LeftShift) && Generic.getStamina() > 0 && !PlayerManagement.getInstance().isRecoveryingStamina()) {
                running = true;
                currentSpeed = runningSpeed;
                Generic.removeStamina(1.5f * Time.deltaTime);
            }
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if(Input.GetButtonDown("Jump") && grounded && Generic.getStamina() > 0 && !PlayerManagement.getInstance().isRecoveryingStamina()) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            currentSpeed = (float)(speed * 0.7);
            jump_key_pressed = true;
            Generic.removeStamina(3f);
        }

        PlayerManagement.getInstance().setRunningStatus(running);

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * currentSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (move.magnitude > .2f) {
            if (!running && grounded && !jump_key_pressed && !footsteps_sound.isPlaying()) {
                running_sound.stopSound();
                jumping_sound.stopSound();
                footsteps_sound.setVolume(Random.Range(0.8f, 1));
                footsteps_sound.setPitch(Random.Range(0.8f, 1.1f));
                footsteps_sound.playSound();
            } else if (running && !jump_key_pressed && !running_sound.isPlaying()) {
                footsteps_sound.stopSound();
                running_sound.setVolume(Random.Range(0.8f, 1));
                running_sound.setPitch(Random.Range(0.8f, 1.1f));
                running_sound.playSound();
            }
        } else {
            footsteps_sound.stopSound();
            running_sound.stopSound();
        }

        if (grounded && jump_key_pressed && !jumping_sound.isPlaying()) {
            running_sound.stopSound();
            footsteps_sound.stopSound();
            jumping_sound.setVolume(Random.Range(0.8f, 1));
            jumping_sound.setPitch(Random.Range(0.8f, 1.1f));
            jumping_sound.playSound();
        }
    }

    public bool isInAir() {
        return !grounded;
    }
}

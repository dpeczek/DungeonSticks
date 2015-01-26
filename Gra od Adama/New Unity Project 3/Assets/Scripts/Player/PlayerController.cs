using System;
using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float mouseSensitivity;
    public float upDownRange;
    public float timeForSlide = 1.5f;
    public float slidesCooldown;

    float verticalrotation = 0;
    
    CharacterController characterController;
    Animator anim;

    private bool hasCrossbow = false;

    //public float health;
    //public float mana;

    private PlayerHealth hp;
    private PlayerMana mana;

    void SetCrossbow(bool status)
    {
        hasCrossbow = status;
    }

    // Use this for initialization
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        hp = GetComponent<PlayerHealth>();
        mana = GetComponent<PlayerMana>();
    }

    // Update is called once per frame
    void Update()
    {
        //movement 
        float forwardSpeed = Input.GetAxis("Vertical");
        float sideSpeed = Input.GetAxis("Horizontal");

        Move(sideSpeed, forwardSpeed);
        //rotation
        Rotate();
        
        Animate(forwardSpeed, sideSpeed);
        AnimateHasCrossbow();
        
    }

    void Move(float sideSpeed, float forwardSpeed)
    {
        Vector3 speed = new Vector3(sideSpeed * moveSpeed, 0, forwardSpeed * moveSpeed);
        speed = transform.rotation * speed;
        characterController.Move(speed * Time.deltaTime);
    }

    void Rotate()
    {
        float rotateLeftRight = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, rotateLeftRight, 0);

        verticalrotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;
        verticalrotation = Mathf.Clamp(verticalrotation, -upDownRange, upDownRange);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalrotation, 0, 0);
    }

    void Animate(float forwardSpeed, float sideSpeed)
    {
        bool walking = forwardSpeed != 0f || sideSpeed != 0f;
        if (hasCrossbow == true)
        {
            anim.SetBool("IsWalkingC", walking);
        }
        else
        {
            anim.SetBool("IsWalkingWC", walking);
        }
    }

    void AnimateHasCrossbow()
    {
        if (Input.GetKeyDown("h"))
        {
            if (hasCrossbow == true)
            {
                SetCrossbow(false);
                anim.SetBool("HasCrossbow", false);
            }
            if (hasCrossbow == false)
            {
                SetCrossbow(true);
                anim.SetBool("HasCrossbow", true);
            }
        }
    }

    
}

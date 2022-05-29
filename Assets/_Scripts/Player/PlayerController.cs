using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CharacterController _charController;
    [SerializeField] private Transform _meshPlayer;
    [SerializeField] private Animator anim;

    private float inputX;
    private float inputY;
    private Vector3 _vMovement;
    private float moveSpeed = 0.14f;
    private float gravity = 0.5f;

    private void FixedUpdate()
    {
        float h = SimpleInput.GetAxis("Horizontal");
        float v = SimpleInput.GetAxis("Vertical");

        //gravity
        if (_charController.isGrounded)
        {
            _vMovement.y = 0f;
        }
        else
        {
            _vMovement.y -= gravity * Time.deltaTime;
        }

        //movement
        Move(h, v);

        //animation
        Animating(h, v);

        //rotation
        Rotation(h, v);
    }

    void Move(float h, float v)
    {
        _vMovement = new Vector3(h * moveSpeed, _vMovement.y, v * moveSpeed);
        _charController.Move(_vMovement);
    }

    void Animating(float h, float v)
    {
        bool walking = h != 0f || v != 0f;
        anim.SetBool("IsWalking", walking);
    }

    void Rotation(float h, float v) 
    {
        if (h != 0 || v != 0)
        {
            Vector3 lookDir = new Vector3(_vMovement.x, 0, _vMovement.z);
            _meshPlayer.rotation = Quaternion.LookRotation(lookDir);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private CharacterController _characterController;
    [SerializeField]
    Joystick _joystick;

    [SerializeField]
    private Animator _animator;

    [SerializeField]
    private float _speed;

    private float horizontalMove;
    private float verticalMove;
    private void Update()
    {

        horizontalMove = _joystick.Horizontal * _speed;
        verticalMove = _joystick.Vertical * _speed;

        if (horizontalMove != 0 || verticalMove != 0)
        {
            Vector3 move = new Vector3(horizontalMove, 0, verticalMove);
            _characterController.Move(move * Time.deltaTime);

            _animator.SetBool("IsMoving", true);
        }
        else
        {
            _animator.SetBool("IsMoving", false);
        }


        if(Input.GetKeyDown(KeyCode.W))
        {
            _animator.SetBool("IsFire", true);
        }
      
    }
}

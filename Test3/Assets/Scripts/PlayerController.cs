using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Controller
    [SerializeField] private CharacterController _characterController;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpHeight = 1.0f;
    [SerializeField] private float _gravityValue = 20.0f;
    [SerializeField] private float _rotationSpeed;

    // Joystick
    [SerializeField] Joystick _joystick;
    private float _horizontalMove;
    private float _verticalMove;

    [SerializeField] private Animator _animator;
    [SerializeField] private string _movementAnimationKey;
    [SerializeField] private string _fireAnimationKey;
    [SerializeField] private string _jumpingAnimationKey;

    private Vector3 _moveDirection = Vector3.zero;

    private Vector3 _rotationDirection;

    private bool _isMoving = false;
    public bool IsMoving
    {
        get => _isMoving;
    }

    private void Update()
    {
        _horizontalMove = _joystick.Horizontal * _speed;
        _verticalMove = _joystick.Vertical * _speed;

        Move();
        Rotate();

        if (_moveDirection.y <= 0)
        {
            _animator.SetBool(_jumpingAnimationKey, false);
        }

        if (!_characterController.isGrounded)
        {
            _moveDirection.y -= _gravityValue * Time.deltaTime;
            _characterController.Move(_moveDirection * Time.deltaTime);
            
        }
    }

    private void Move()
    {
        if (_horizontalMove != 0 || _verticalMove != 0)
        {
            Vector3 move = new Vector3(_horizontalMove, 0, _verticalMove);
            _characterController.Move(move * Time.deltaTime);
            _isMoving = true;

            _animator.SetBool(_movementAnimationKey, _isMoving);
        }
        else
        {
            _isMoving = false;
            _animator.SetBool(_movementAnimationKey, _isMoving);
        }
    }
    private void Rotate()
    {
        if (_horizontalMove != 0 || _verticalMove != 0)
        {
            _rotationDirection = new Vector3(0, _horizontalMove * _rotationSpeed * Time.deltaTime, 0);
            _characterController.transform.Rotate(_rotationDirection);
        }
    }
    public void Aim(bool isNeedAim)
    {
        if (isNeedAim)
        {
            _animator.SetBool(_fireAnimationKey, true);
        }
        else
        {
            _animator.SetBool(_fireAnimationKey, false);
        }
    }
    public void Jump()
    {
        _moveDirection.y = _jumpHeight;
        _animator.SetBool(_jumpingAnimationKey, true);
    }
}

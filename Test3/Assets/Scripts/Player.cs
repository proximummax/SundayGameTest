using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private FootSteps _footStep;
    [SerializeField] private PlayerController _playerController;
    private CharacterController _characterController;

    private float TimeToCreateNewFootStep = 0.7f;

    private float currentTime = 0;

    private void Start()
    {
        _characterController = gameObject.GetComponent<CharacterController>();
    }
    private void Update()
    {
        currentTime += Time.deltaTime;

        if (_playerController.IsMoving && _characterController.transform.position.y <= 0.07f  && currentTime > TimeToCreateNewFootStep)
        {
            Instantiate(_footStep, transform.position, _footStep.transform.rotation);
            currentTime = 0;
        }
    }
}

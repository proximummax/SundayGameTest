using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private Vector2 _rotationAngleRange;
    [SerializeField] private InputController _inputController;
    [SerializeField] private ParticleSystem _boomParticleEffect;

    private float _currentRotationRoll = 0.0f;
    private void Start()
    {
        GenerateRotationRoll();
    }

    private void OnEnable()
    {
        _inputController.CoinTouched += OnCoinToched;
    }
    private void OnDisable()
    {
        _inputController.CoinTouched -= OnCoinToched;
    }

    private void Update()
    {
        transform.Rotate(0.0f, 0.0f, _currentRotationRoll);
    }

    private void GenerateRotationRoll()
    {
        float direction = (Random.value > 0.5f) ? 1.0f : -1.0f;
        _currentRotationRoll = Random.Range(_rotationAngleRange.x, _rotationAngleRange.y) * direction;
    }

    private void ChangeColor()
    {
        GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
    }

    private void OnCoinToched()
    {
        ChangeColor();
        GenerateRotationRoll();
        _boomParticleEffect.Play();
    }
    

}

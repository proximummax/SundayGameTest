using UnityEngine;
using UnityEngine.Events;

public class InputController : MonoBehaviour
{
    public event UnityAction CoinTouched;

    private void Update()
    {
        //change touch
        if (Input.GetMouseButtonDown(0))
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.TryGetComponent(out Coin coin))
                {
                    CoinTouched?.Invoke();
                }
            }

        }
    }
}

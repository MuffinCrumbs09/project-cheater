using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 2f;
    private Vector2 _movementDir;
    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update() 
    {
        _movementDir = InputManager.Instance.MovementValue;
    }

    private void FixedUpdate()
    {
        _rb.linearVelocity = _movementDir * movementSpeed;
    }
}

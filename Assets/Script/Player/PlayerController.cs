using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]private int _maxHealth = 100;
    [SerializeField]private float _movementSpeed = 4.5f;
    [SerializeField]private float _jumpHeight = 2;
    [SerializeField]private float _sensorSize = 1;
    [SerializeField]private LayerMask _groundLayer;
    [SerializeField]private Transform _groundSensor;

    private InputAction _pauseAction;

    private Rigidbody2D _rigidbody2D;
    private InputAction _jumpAction;
    private InputAction _moveAction;
    private Vector2 _moveInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        _moveAction = InputSystem.actions["Move"];
        _jumpAction = InputSystem.actions["Jump"];
        _pauseAction = InputSystem.actions["Pause"];
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(_pauseAction.WasPressedThisFrame())
        {
            GameManager.Instance.Pause();
        }

        if(GameManager.Instance.IsPaused())
        {
            return;
        }
        
        
        
        _moveInput = _moveAction.ReadValue<Vector2>();

        if(_moveInput.x < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if(_moveInput.x > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }


        if(_jumpAction.WasPressedThisFrame() && IsGrounded())
        {
            Jump();
        }

        
    }

    void FixedUpdate()
    {
         _rigidbody2D.linearVelocity = new Vector2(_moveInput.x * _movementSpeed, _rigidbody2D.linearVelocity.y);
    }

    void Jump()
    {
        _rigidbody2D.AddForce(Vector2.up * Mathf.Sqrt(_jumpHeight * -2 * Physics2D.gravity.y), ForceMode2D.Impulse);
    }
    
    bool IsGrounded()
    {
        Collider2D[] colliders2D = Physics2D.OverlapCircleAll(_groundSensor.position, _sensorSize);

        foreach (Collider2D item in colliders2D)
        {
            if(item.gameObject.layer == 6)
            {
                return true;
            }
        }
        return false;
    }
}

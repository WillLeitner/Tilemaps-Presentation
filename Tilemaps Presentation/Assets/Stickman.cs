using UnityEngine;

public class Stickman : MonoBehaviour
{
    [SerializeField] private KeyCode _rightButton;
    [SerializeField] private KeyCode _leftButton;
    [SerializeField] private KeyCode _jumpButton;

    private Rigidbody2D _rb;
    private SpriteRenderer _sr;

    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float _jumpForce = 5.0f;

    private float direction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
    }
    
    void FixedUpdate()
    {
        _rb.linearVelocityX = direction * speed;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 movement = new Vector2(direction * speed, 0.0f);
        Vector2 jump = new Vector2(direction * speed, _jumpForce);
        
        if (Input.GetKeyDown(_rightButton))
        {
            direction = 1.0f;
            _sr.flipX = false;
        }
        if (Input.GetKeyDown(_leftButton))
        {
            direction = -1.0f;
            _sr.flipX = true;
        }

        if (Input.GetKeyUp(_rightButton) || Input.GetKeyUp(_leftButton))
        {
            direction = 0.0f;
        }
        if (Input.GetKeyDown(_jumpButton))
        {
            _rb.AddForce(jump, ForceMode2D.Impulse);
        }
    }
}

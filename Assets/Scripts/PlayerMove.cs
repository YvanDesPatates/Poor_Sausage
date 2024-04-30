using UnityEngine;

public class PlayerMove : MonoBehaviour, IGameOverObserver
{
    [SerializeField] private float speed = 10;
    [SerializeField] private float rotationSpeed = 100;
    [SerializeField] private float jumpForce = 10;
    [SerializeField] private Transform groundCheck;

    private float _horizontalInput;
    private float _verticalInput;
    private float _horizontalMouseInput;

    private Rigidbody _rigidBody;
    private GameControllerScript _gameController;
    private bool _isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        _gameController = GameObject.FindWithTag("GameController").GetComponent<GameControllerScript>();
        _gameController.SubscribeToGameOverNotification(this);
        _rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isGameOver)
        {
            return;
        }

        _horizontalInput = Input.GetAxisRaw("Horizontal");
        _verticalInput = Input.GetAxisRaw("Vertical");
        _horizontalMouseInput = Input.GetAxis("Mouse X");

        Vector3 direction = new Vector3(_horizontalInput, 0, _verticalInput);

        transform.Translate(speed * Time.deltaTime * direction);
        transform.Rotate(Vector3.up, _horizontalMouseInput * rotationSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            _rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    public void GameOverNotification()
    {
        _isGameOver = true;
        _rigidBody.isKinematic = true;
    }

    private bool IsGrounded()
    {
        return Physics.OverlapBoxNonAlloc(groundCheck.position,
            new Vector3(transform.localScale.x / 2, 0.1f, transform.localScale.z / 2), new Collider[1], transform.rotation,
            LayerMask.GetMask("Ground")) > 0;
    }
}
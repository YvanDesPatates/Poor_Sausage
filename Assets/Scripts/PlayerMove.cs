using UnityEngine;

public class PlayerMove : MonoBehaviour, IGameOverObserver
{
    public float speed = 10;
    public float rotationSpeed = 100;
    public float jumpForce = 10;

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
        _horizontalInput = Input.GetAxis("Horizontal");
        _verticalInput = Input.GetAxis("Vertical");
        _horizontalMouseInput = Input.GetAxis("Mouse X");

        Vector3 direction = new Vector3(_horizontalInput, 0, _verticalInput);

        transform.Translate(speed * Time.deltaTime * direction);
        transform.Rotate(Vector3.up, _horizontalMouseInput * rotationSpeed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    public void GameOverNotification()
    {
        _isGameOver = true;
        _rigidBody.isKinematic = true;
    }
}
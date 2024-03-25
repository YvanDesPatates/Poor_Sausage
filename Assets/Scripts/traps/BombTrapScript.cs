using System.Collections;
using UnityEngine;

public class BombTrapScript : MonoBehaviour, IGameOverObserver
{
    public GameObject bombAndLightParent;
    public GameObject bomb;
    public float coolDownBetweenBombsInS = 5;
    public float secondsBeforeBombFalls = 3;
    public float minimalSpotAngle = 10;

    private Transform _playerTransform;
    private Light _spotLight;
    private float _baseSpotAngle;
    private Color _baseSpotColor;
    private float _yPosition;
    private bool _isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        _playerTransform = GameObject.FindWithTag("Player").transform;
        _spotLight = GetComponentInChildren<Light>();
        _yPosition = transform.position.y;
        _baseSpotAngle = _spotLight.spotAngle;
        _baseSpotColor = _spotLight.color;
        PrepareAndThrowBomb();
    }

    public void BombHasExploded()
    {
        if (!_isGameOver)
        {
            bomb.SetActive(false);
            bombAndLightParent.SetActive(false);
            bomb.transform.SetLocalPositionAndRotation(Vector3.zero, bomb.transform.rotation);
            StartCoroutine(ThrowNextBomb());
            //TODO: add explosion effect
        }
    }

    private IEnumerator ThrowNextBomb()
    {
        yield return new WaitForSeconds(coolDownBetweenBombsInS);
        bombAndLightParent.SetActive(true);
        PrepareAndThrowBomb();
    }

    private void PrepareAndThrowBomb()
    {
        StartCoroutine(BeforeThrowBomb());
        StartCoroutine(ThrowBomb());
    }

    private IEnumerator BeforeThrowBomb()
    {
        if (!_isGameOver)
        {
            _spotLight.spotAngle = _baseSpotAngle;
            _spotLight.color = _baseSpotColor;

            var playerPosition = _playerTransform.position;
            transform.SetPositionAndRotation(new Vector3(playerPosition.x, _yPosition, playerPosition.z),
                transform.rotation);
            float stepsDuration = secondsBeforeBombFalls / 3;
            float actualSpotAngle = _baseSpotAngle;
            float spotAngleReduction = (actualSpotAngle - minimalSpotAngle) / 3;
            for (int i = 0; i < 3; i++)
            {
                yield return new WaitForSeconds(stepsDuration);
                actualSpotAngle -= spotAngleReduction;
                _spotLight.spotAngle = actualSpotAngle;
            }

            _spotLight.color = Color.red;
        }
    }

    private IEnumerator ThrowBomb()
    {
        if (!_isGameOver)
        {
            yield return new WaitForSeconds(secondsBeforeBombFalls);
            bomb.SetActive(true);
        }
    }

    public void GameOverNotification()
    {
        bomb.GetComponent<Rigidbody>().isKinematic = true;
        _spotLight.enabled = false;
    }
}
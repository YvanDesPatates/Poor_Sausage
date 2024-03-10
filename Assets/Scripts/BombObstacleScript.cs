using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class BombObstacleScript : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject bombAndLightParent;
    public GameObject bomb;
    public float coolDownBetweenBombsInS = 5;
    public float secondsBeforeBombFalls = 3;
    public float minimalSpotAngle = 10;

    private Light _spotLight;
    private float _yPosition;

    // Start is called before the first frame update
    void Start()
    {
        _spotLight = GetComponentInChildren<Light>();
        _yPosition = transform.position.y;
        PrepareAndThrowBomb();
    }

    public void BombHasExploded()
    {
        StartCoroutine(ThrowNextBomb());
        //TODO: add explosion effect
    }

    private IEnumerator ThrowNextBomb()
    {
        bombAndLightParent.SetActive(false);
        bomb.SetActive(false);
        bomb.transform.SetLocalPositionAndRotation(Vector3.zero, bomb.transform.rotation);
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
        var playerPosition = playerTransform.position;
        transform.SetPositionAndRotation( new Vector3(playerPosition.x, _yPosition, playerPosition.z), transform.rotation);
        float stepsDuration = secondsBeforeBombFalls / 3;
        float actualSpotAngle = _spotLight.spotAngle;
        float spotAngleReduction = (actualSpotAngle - minimalSpotAngle) / 3;
        for (int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(stepsDuration);
            actualSpotAngle -= spotAngleReduction;
            _spotLight.spotAngle = actualSpotAngle;
        }

        _spotLight.color = Color.red;
    }

    private IEnumerator ThrowBomb()
    {
        yield return new WaitForSeconds(secondsBeforeBombFalls);
        bomb.SetActive(true);
    }
}
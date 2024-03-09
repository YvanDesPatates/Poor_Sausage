using System.Collections;
using UnityEngine;

public class BombObstacleScript : MonoBehaviour
{
    public GameObject bomb;
    public float secondsBeforeBombFalls = 3;

    private Rigidbody _bombRb;
        
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ThrowBomb());
        _bombRb = bomb.GetComponent<Rigidbody>();
    }

    private IEnumerator ThrowBomb()
    {
        yield return new WaitForSeconds(secondsBeforeBombFalls);
        _bombRb.isKinematic = false;
    }
}

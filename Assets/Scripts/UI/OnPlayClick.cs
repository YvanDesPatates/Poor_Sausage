using UnityEngine;
using UnityEngine.SceneManagement;

public class OnPLayClick : MonoBehaviour
{
    public void OnMouseDown()
    {
        SceneManager.LoadScene("GameScene");
    }
}

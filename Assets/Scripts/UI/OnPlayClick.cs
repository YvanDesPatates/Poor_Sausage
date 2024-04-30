    using UnityEngine;
using UnityEngine.SceneManagement;

public class OnPLayClick : MonoBehaviour
{
    private GameControllerScript _gameController;
    public void OnMouseDown()
    {
        SceneManager.LoadScene("GameScene");
    }
}

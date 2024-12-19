using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    Text text;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "egg")
        {
            // Pause the game, show game over screen
            Time.timeScale = 0;
            text.gameObject.SetActive(true);
            text.text = "Game Over";
            Debug.Log("Game Over");
        }
    }
}

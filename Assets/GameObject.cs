
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject panelUI;
    public GameObject levelCompleteUI;
    bool gameHasEnded = false;
    public void EndGame()
    {
        if(gameHasEnded==false)
        {
            Debug.Log("Game Over!");
            gameHasEnded = true;
            panelUI.SetActive(true);
            FindObjectOfType<BallMovement>().starsCollected = 0;
            FindObjectOfType<Score>().scoreText.enabled = false;
            Invoke("Restart",2f);
        }
        
    }
    
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    public void NewGame()
    {
        Debug.Log("Level Cleared!");
        levelCompleteUI.SetActive(true);
        Invoke("LoadNewScene",2f);

        
    }
    public void LoadNewScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}

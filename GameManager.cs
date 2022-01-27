using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject>targets;// attach target objects in unity for random spawn
    private float spawnRate = 1.5f;
    public TextMeshProUGUI textScore;
    public TextMeshProUGUI gameOver;
    public Button restartButton;
    public GameObject titleScreen;
    private int score;
    public bool isGameActive;
    IEnumerator SpawnTarget()
    {
        while(isGameActive)// wait 1 second, generate a random index,  and spawn a random target, if bool is true
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        textScore.text = "Score: " + score;
    }  
    
    public void GameOver()
    {
        isGameActive = false;
        gameOver.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame() //in the Button’s inspector, click + to add a new On Click event
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartGame(int difficulty)
    {
        isGameActive = true;
        score = 0; 
        spawnRate /= difficulty;// set the difficulty value in inspector

        titleScreen.gameObject.SetActive(false);
        StartCoroutine(SpawnTarget());// method start IEnumenatir SpawnTarget() method
        UpdateScore(0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    public Button button;
    private GameManager gameManger; 
    public int difficulty;
    
    void Start()
    {
        button = GetComponent<Button>();
        gameManger = GameObject.Find("Game Manager").GetComponent<GameManager>();
        button.onClick.AddListener(SetDifficulty);//wait an event
    }

    
    void Update()
    {
        
    }

    void SetDifficulty()
    {
        Debug.Log(gameObject.name + "was clicked");
        gameManger.StartGame(difficulty);//call method frome the Game Manger
    }
}

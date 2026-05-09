using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class DifficultyButton : MonoBehaviour
{
        private Button button;
    private GameManger gameManger;

    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
        gameManger = GameObject.Find("GameManager").GetComponent<GameManger>();
    }

    // Update is called once per frame
    void SetDifficulty ()
    {
        Debug.Log(gameObject.name + " was clicked");
        gameManger.StartGame();
    }
}

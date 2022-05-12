using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    public bool inHand = false;
    public bool carrotsPlaced = false;
    public bool allowMovement = false;
    public bool waterCollected = false;
    public bool waterPlaced = false;
    public bool inDialogue = false;

    private static GameManager _instance;

    public static GameManager GetInstance()
    {
        if(_instance == null)
        {
            _instance = new GameManager();
        }

        return _instance;
    }
}

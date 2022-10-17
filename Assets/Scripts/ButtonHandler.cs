using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour {
    public GameObject loadGameButtonObj;
    
    private Button loadGameButton;
    
    private void Awake() {
        loadGameButton = loadGameButtonObj.GetComponent<Button>();
        DisableLoadGameIfNotExist();
    }

    public void StartNewGame() {
        SceneManager.LoadScene(1);
    }

    public void LoadGame() {
        ;
    }

    private void DisableLoadGameIfNotExist() {
        if (!System.IO.File.Exists("./savedGame.json"))
            loadGameButton.interactable = false;
    }
}
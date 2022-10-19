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
        SavePersist.instance.loadSave = true;
        SceneManager.LoadScene(1);
    }

    private void DisableLoadGameIfNotExist() {
        if (!System.IO.File.Exists("./save.json"))
            loadGameButton.interactable = false;
    }
}
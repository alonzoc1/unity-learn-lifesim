using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject dayCounterObj;
    public GameObject hungerCounterObj;
    public GameObject energyCounterObj;
    public GameObject hygieneCounterObj;
    public GameObject entertainmentCounterObj;
    public GameObject progressCounterObj;

    
    private TextMeshProUGUI dayCounter;
    private TextMeshProUGUI hungerCounter;
    private TextMeshProUGUI energyCounter;
    private TextMeshProUGUI hygieneCounter;
    private TextMeshProUGUI entertainmentCounter;
    private TextMeshProUGUI progressCounter;

    private int day;
    private int hunger;
    private int energy;
    private int hygiene;
    private int entertainment;
    private int progress;

    private void Start() {
        dayCounter = dayCounterObj.GetComponent<TextMeshProUGUI>();
        hungerCounter = hungerCounterObj.GetComponent<TextMeshProUGUI>();
        energyCounter = energyCounterObj.GetComponent<TextMeshProUGUI>();
        hygieneCounter = hygieneCounterObj.GetComponent<TextMeshProUGUI>();
        entertainmentCounter = entertainmentCounterObj.GetComponent<TextMeshProUGUI>();
        progressCounter = progressCounterObj.GetComponent<TextMeshProUGUI>();

        StartNewGame();
    }

    private void Update() {
        if (Input.GetKeyUp(KeyCode.Escape))
            SaveAndQuit();
    }

    private void GameTick() {
        progress += 1;
        if (progress == 100) {
            progress = 0;
            day += 1;
        }

        progressCounter.text = "Progress: " + progress.ToString();
        dayCounter.text = "Day: " + day.ToString();
    }

    private void StartNewGame() {
        dayCounter.text = "Day: 1";
        day = 1;
        hungerCounter.text = "100";
        hunger = 100;
        energyCounter.text = "100";
        energy = 100;
        hygieneCounter.text = "100";
        hygiene = 100;
        entertainmentCounter.text = "100";
        entertainment = 100;
        progressCounter.text = "Progress: 0";
        progress = 0;
        
        InvokeRepeating("GameTick", 1f, 1f);
    }

    private void SaveAndQuit() {
        Debug.Log("Save and Quit");
    }
}

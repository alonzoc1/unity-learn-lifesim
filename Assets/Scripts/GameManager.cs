using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

#if UNITY_EDITOR
using UnityEditor;
#endif

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

        if (SavePersist.instance.loadSave)
            LoadGame();
        else
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

        if (Random.Range(0f, 1f) < .5) {
            hunger -= 1;
            hungerCounter.text = hunger.ToString();
            ColorText(hungerCounter, hunger);
        }
        
        if (Random.Range(0f, 1f) < .1) {
            energy -= 1;
            energyCounter.text = energy.ToString();
            ColorText(energyCounter, energy);
        }
        
        if (Random.Range(0f, 1f) < .1) {
            hygiene -= 1;
            hygieneCounter.text = hygiene.ToString();
            ColorText(hygieneCounter, hygiene);
        }
        
        if (Random.Range(0f, 1f) < .5) {
            entertainment -= 1;
            entertainmentCounter.text = entertainment.ToString();
            ColorText(entertainmentCounter, entertainment);
        }
    }

    private void ColorText(TextMeshProUGUI text, int value) {
        if (value > 3)
            text.color = Color.green;
        else
            text.color = Color.red;
    }

    private void StartNewGame() {
        dayCounter.text = "Day: 1";
        day = 1;
        hungerCounter.text = "10";
        hunger = 10;
        energyCounter.text = "10";
        energy = 10;
        hygieneCounter.text = "10";
        hygiene = 10;
        entertainmentCounter.text = "10";
        entertainment = 10;
        progressCounter.text = "Progress: 0";
        progress = 0;
        
        InvokeRepeating("GameTick", 1f, 1f);
    }

    private void SaveAndQuit() {
        SaveGame save = new SaveGame();
        save.day = day;
        save.progress = progress;
        save.hunger = hunger;
        save.hygiene = hygiene;
        save.energy = energy;
        save.entertainment = entertainment;
        
        System.IO.File.WriteAllText("./save.json", JsonUtility.ToJson(save));
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    private void LoadGame() {
        SaveGame save = JsonUtility.FromJson<SaveGame>(System.IO.File.ReadAllText("./save.json"));
        day = save.day;
        dayCounter.text = "Day: " + day.ToString();
        hunger = save.hunger;
        hungerCounter.text = hunger.ToString();
        energy = save.energy;
        energyCounter.text = energy.ToString();
        hygiene = save.hygiene;
        hygieneCounter.text = hygiene.ToString();
        entertainment = save.entertainment;
        entertainmentCounter.text = entertainment.ToString();
        progress = save.progress;
        progressCounter.text = "Progress: " + progress.ToString();
        
        InvokeRepeating("GameTick", 1f, 1f);
    }

    public void RestoreStat(string stat) {
        switch (stat) {
            case "hunger":
                hunger = 10;
                hungerCounter.text = hunger.ToString();
                break;
            case "energy":
                energy = 10;
                energyCounter.text = energy.ToString();
                break;
            case "hygiene":
                hygiene = 10;
                hygieneCounter.text = hygiene.ToString();
                break;
            case "entertainment":
                entertainment = 10;
                entertainmentCounter.text = entertainment.ToString();
                break;
        }
    }
}

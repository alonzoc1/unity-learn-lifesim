using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SavePersist : MonoBehaviour {
    public static SavePersist instance;
    public bool loadSave;
    private void Start() {
        instance = this;
        loadSave = false;
        DontDestroyOnLoad(gameObject);
    }
}
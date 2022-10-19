using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickResource : MonoBehaviour {
    public string resourceName;
    private GameManager gm;

    private void Start() {
        gm = GameObject.FindWithTag("GM").GetComponent<GameManager>();
    }

    private void OnMouseDown() {
        gm.RestoreStat(resourceName);
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildableNode : MonoBehaviour {
    private List<GameObject> neighbours;
    public int i;
    public int j;

    public bool hit = false;

    public List<GameObject> GetNeighbours() {
        return this.neighbours;
    }

    internal void Init(int i, int j) {
        this.neighbours = new List<GameObject>();
        this.i = i;
        this.j = j;
    }

    public void ChangeColor() {
        Debug.Log(gameObject.GetComponent<Renderer>());
        if (this.hit) {
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
        } else {
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        }
        this.hit = !this.hit;
    }
}
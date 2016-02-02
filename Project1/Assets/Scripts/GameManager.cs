﻿using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	//Gamestate
	private bool isPaused;
	public bool IsPaused { get { return isPaused; } }
	private bool win; // have you won the game?
	private bool gameOver; // is it over?
	public bool GameOver { get { return gameOver; } }
	public void WinGame() { win = true; gameOver = true; } // Creates the winstate

	// s_Instance is used to cache the instance found in the scene so we don't have to look it up every time.
	private static GameManager s_Instance = null;
	
	/// <summary>
	/// This defines a static instance property that attempts to find the manager object in the scene and
	/// returns it to the caller.
	/// </summary>
	/// <value>The instance.</value>
	public static GameManager instance {
		get {
			if (s_Instance == null) {
				// This is where the magic happens.
				//  FindObjectOfType(...) returns the first AManager object in the scene.
				s_Instance =  FindObjectOfType(typeof (GameManager)) as GameManager;
			}
			
			// If it is still null, create a new instance
			if (s_Instance == null) {
				GameObject obj = new GameObject("GameManager");
				s_Instance = obj.AddComponent(typeof (GameManager)) as GameManager;
				Debug.Log ("Could not locate a GameManager object. GameManager was Generated Automaticly.");
			}
			
			return s_Instance;
		}
	}

	// Use this for initialization
	void Start () {
		win = false;
		isPaused = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/// <summary>
	/// Pause the game.
	/// </summary>
	public void Pause () {
		isPaused = true;
		GameObject.Find ("btnPause").GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("btnPlay");
	}

	/// <summary>
	/// Plays the game.
	/// </summary>
	public void Play () {
		isPaused = false;
		GameObject.Find ("btnPause").GetComponent<SpriteRenderer> ().sprite = Resources.Load<Sprite> ("btnPause");
	}

}

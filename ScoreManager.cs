using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Threading;
using System.Threading.Tasks;

public class ScoreManager : MonoBehaviour
{
    // public static ScoreManager instance;

    public Text scoreText;
    public Text highScoreText;

    public GameObject winText;
    public GameObject loseText; 
    public GameObject hotdogText;


    int score = 0;
    public int winScore = 4;

    void Start() {
        scoreText.text = "score: " + score.ToString() + " pts";
        UpdateHighScore();
    }

    void Update() {
        CheckHighScore();
        if (transform.position.y < -5f) {
            loseText.SetActive(true);
            Invoke ("Reload", 2);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "hotdog") {
            other.gameObject.SetActive(false);
            score += 1;
            scoreText.text = "score: " + score.ToString() + " pts";
            ShowHotDog();
            Invoke("StopHotDog", 2);
            
            if (score >= winScore) {  
                winText.SetActive(true);
                Invoke ("Reload", 2);
            }
        }
    }

    private void Reload() { 
        SceneManager.LoadScene("Bootstrap");
    }

    void CheckHighScore () {
        if (PlayerPrefs.GetInt("HighScore") >= 0){
            if (score > PlayerPrefs.GetInt("HighScore")) {
                PlayerPrefs.SetInt("HighScore", score);
                UpdateHighScore();
            }
        }  
    }

    void UpdateHighScore () {
        highScoreText.text = $"highscore: {PlayerPrefs.GetInt("HighScore", 0)} pts";    
    }

    void ShowHotDog() {
        //set hotdog active, rotate it
        hotdogText.SetActive(true);
        transform.Rotate(0, 0, 4);
    }

    void StopHotDog() {
        hotdogText.SetActive(false);
    }
}



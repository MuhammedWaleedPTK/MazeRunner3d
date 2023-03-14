using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Canvas Canvas;
    public TextMeshProUGUI text;
    public AudioSource CoinSound;
    public GameObject gameOverPanel;
    public GameObject Cam2;

    public float collectedCoins = 0;
    public bool isAlive=true;
    public bool isCamOn = true;


    //private void OnEnable()
    //{
    //    SceneManager.sceneLoaded += OnSceneLoaded;
    //}
    //private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    //{
    //    if (scene.name == "Level01")
    //    {
    //        if (isCamOn)
    //        {
    //            Cam2.gameObject.SetActive(false);
    //            isCamOn = false;
    //        }
    //    }
    //}
    private void Update()
    {
        


        if (collectedCoins < 10)
        {
            text.color = Color.red;
        }
        else
        {
            text.color = Color.green;
        }
        text.text="COINS:"+((int)collectedCoins).ToString();
       
    }
    void OnRenderObject()
    {
        if (isCamOn)
        {
            Cam2.gameObject.SetActive(false);
            isCamOn = false;
        }
    }


        public void GameWon()
    {
        Canvas.gameObject.SetActive(true);
        isAlive = false;
    }
    public void CollectedCoin()
    {
        collectedCoins++;
        CoinSound.Play();
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        isAlive = false;
    }
    
}

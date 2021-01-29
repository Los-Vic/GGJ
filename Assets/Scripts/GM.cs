using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour
{
    public GameObject Target;
    public GameUI gameUI;
    private TargetViewCheck viewChecker;
    public float loseTime = 3.0f;
    public float winTime = 6.0f;

    private float winElapsed = 0;
    private float loseElapsed = 0;

    private bool isGaming = true;
    // Start is called before the first frame update
    void Start()
    {
        viewChecker = Target.GetComponent<TargetViewCheck>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (isGaming == false)
            return;

        if(viewChecker.isInCameraView)
        {
            loseElapsed = 0;
            winElapsed += Time.deltaTime;
          
        }
        else
        {
            winElapsed = 0;
            loseElapsed += Time.deltaTime;
        }
        gameUI.winTimeTxt.text = winElapsed.ToString();
        gameUI.loseTimeTxt.text = loseElapsed.ToString();

        if(loseElapsed >= loseTime)
        {
            gameUI.gameOverTxt.text = "Ê§°Ü£¡";
            gameUI.gameOverTxt.gameObject.SetActive(true);
            gameUI.replayBtn.gameObject.SetActive(true);
            isGaming = false;
        }
        if (winElapsed >= winTime)
        {
            gameUI.gameOverTxt.text = "³É¹¦£¡";
            gameUI.gameOverTxt.gameObject.SetActive(true);
            gameUI.replayBtn.gameObject.SetActive(true);
            isGaming = false;
        }
    }
   public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
}

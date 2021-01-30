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
    public float warningDelay = 1.0f;
    private float loseElapsed = 0;

    public bool isGaming = false;


    // Loading UI
    public CanvasGroup introCanvas;
    public float introTime = 2.0f;
    public float alphaFadeSpeed = 10.0f;


 

    // Start is called before the first frame update
    void Start()
    {
        viewChecker = Target.GetComponentInChildren<TargetViewCheck>();
        StartCoroutine(IntroGame());
        gameUI.warnTxt.text = string.Format("Warning!You have {0}s to catch up target", loseTime - warningDelay);
    }

    // Update is called once per frame
    void Update()
    {
        if (isGaming == false)
            return;

        if (viewChecker.isInCameraView)
        {
            loseElapsed = 0;
            Warn(false);
        }
        else
        {
            loseElapsed += Time.deltaTime;
            if (loseElapsed > warningDelay)
                Warn(true);
        }

        gameUI.loseTimeTxt.text = (loseElapsed - warningDelay).ToString("f2");

        if(loseElapsed >= loseTime)
        {
            EndGame();
        }
        
    }
   public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    private void EndGame()
    {
        isGaming = false;

        gameUI.gameOverTxt.text = "Lost the target  !";
        gameUI.gameOverTxt.gameObject.SetActive(true);
        gameUI.replayBtn.gameObject.SetActive(true);
        isGaming = false;
        Warn(false);
    }
    private void Warn(bool isShow)
    {
        if(isShow)
        {
            gameUI.warnTxt.gameObject.SetActive(true);
            gameUI.loseTimeTxt.gameObject.SetActive(true);

        }
        else
        {
            gameUI.warnTxt.gameObject.SetActive(false);
            gameUI.loseTimeTxt.gameObject.SetActive(false);
        }
    }
    
    private IEnumerator IntroGame()
    {
        introCanvas.gameObject.SetActive(true);
        yield return new WaitForSeconds(introTime);

        while(introCanvas.alpha >0)
        {
            introCanvas.alpha -= Time.deltaTime * alphaFadeSpeed;
            yield return null;
        }
        introCanvas.gameObject.SetActive(false);

        yield return new WaitForSeconds(1.0f);

        isGaming = true;
        Target.GetComponent<TargetAI>().StartWalk();
    }
    public void GameSuccess()
    {

    }
   
}

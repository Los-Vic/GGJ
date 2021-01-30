using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneMgr : MonoBehaviour
{
    public GameObject _canvas;
    public Animator _animator;
    public Texture2D _cursorImg;

    public float fadeTime = 1.0f;

    private CanvasGroup _cGroup;
    public GameObject mask;
    public GameObject btn;

    private bool isFading = false;

    private void Start()
    {
        _cGroup = _canvas.GetComponent<CanvasGroup>();
    }

    public void OnClickPlay()
    {
        _animator.SetBool("StartGame", true);
        btn.SetActive(false);
    }
    private void Update()
    {
        if(_animator.GetCurrentAnimatorStateInfo(0).IsName("End"))
        {
            if(!isFading)
                StartCoroutine(StartGameScene());
            
        }
        if(_animator.GetCurrentAnimatorStateInfo(0).IsName("Loop"))
        {
            Cursor.SetCursor(_cursorImg, new Vector2(0.5f, 0.5f), CursorMode.Auto);
        }
        else
        {
            Cursor.SetCursor(null,Vector2.zero,CursorMode.Auto);
        }
    }
    private IEnumerator StartGameScene()
    {
        isFading = true;
        mask.SetActive(true);
        float dt = 0;
        float da = 1.0f / fadeTime;
        while(dt < fadeTime)
        {
            dt = dt + Time.deltaTime;
            _cGroup.alpha += da * Time.deltaTime;
            yield return null;
        }

        SceneManager.LoadScene(1);
        
    }
}

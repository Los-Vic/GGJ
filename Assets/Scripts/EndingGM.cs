using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EndingGM : MonoBehaviour
{
    public CanvasGroup _cGroup;
    public GameObject _endText;
    public Animator _animator;

    private float fadeTime = 2.0f;
    private bool startCG = false;
    private bool playThx = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FadeIn());
    }

    // Update is called once per frame
    void Update()
    {
        if(startCG)
        {
            _animator.SetBool("EndGame", true);
        }
       if( !playThx&&_animator.GetCurrentAnimatorStateInfo(0).IsName("Thx"))
       {
            StartCoroutine(FadeOut());
        }

    }

    IEnumerator FadeIn()
    {
        float dt = 0;
        float da = 1 / fadeTime;
        while (dt < fadeTime)
        {
            dt = dt + Time.deltaTime;
            _cGroup.alpha -= da*Time.deltaTime;
            yield return null;
        }
        startCG = true;
    }
    IEnumerator FadeOut()
    {
        float dt = 0;
        float da = 1 / fadeTime;
        playThx = true;
        while (dt < fadeTime)
        {
            dt = dt + Time.deltaTime;
            _cGroup.alpha += da*Time.deltaTime;
            yield return null;
        }
        _endText.gameObject.SetActive(true);
    }

}

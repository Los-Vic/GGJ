using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneMgr : MonoBehaviour
{
   public void OnClickPlay()
    {
        SceneManager.LoadScene(1);
    }
}

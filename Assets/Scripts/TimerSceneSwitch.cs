using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TimerSceneSwitch: MonoBehaviour
{
    int timer = 0;
    public int SceneNumber;
    void Update()
    {
        timer++;
        if (timer == 300)
        {
            SceneManager.LoadScene(SceneNumber);
        }
     
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadSceneOnCollision : MonoBehaviour
{
    public int SceneNumber;
 void OnTriggerEnter2D(Collider2D other)
 {
    SceneManager.LoadScene(SceneNumber);
 }
}
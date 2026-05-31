using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{
    [SerializeField] private int level;

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadSceneAsync(level);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelNameSelected : MonoBehaviour
{
    [SerializeField] private string nameScene;
    //[SerializeField] private GraphicRaycaster raycaster;

    private void Awake()
    {
        
    }
    public void NavigationScence()
    {
        StartCoroutine(WaitForAnimation());
        Time.timeScale = 1f;
    }

    IEnumerator WaitForAnimation()
    {
        ScenceTransition.instance.PlayTransition();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(nameScene);
        ScenceTransition.instance.EndTransition();
    }
}

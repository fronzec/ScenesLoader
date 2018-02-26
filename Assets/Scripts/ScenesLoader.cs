using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScenesLoader : MonoBehaviour
{
    [SerializeField] private Slider barraDeCarga;
    [SerializeField] private GameObject panelCarga;
    [SerializeField] private GameObject panelControles;
    [SerializeField] private Text textoCarga;


    public void LoadSceneAsync(int sceneIndex)
    {
        StartCoroutine(LoadAsyncronously(sceneIndex));
    }

    IEnumerator LoadAsyncronously(int sceneIndex)
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneIndex);
        panelControles.SetActive(false);
        panelCarga.SetActive(true);
        while (!asyncLoad.isDone)
        {
            float progress = Mathf.Clamp01(asyncLoad.progress / .9f);
            barraDeCarga.value = progress;
            textoCarga.text = progress * 100f + "%";
            // Debug.Log(progress);
            yield return null;
        }
        
    }
}
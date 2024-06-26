using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingTrainingArea : MonoBehaviour
{
    [SerializeField]
    private GameObject slider;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("PerformLoading");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator PerformLoading()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync("Trainning Stage");
        while (!operation.isDone)
        {
            slider.GetComponent<Slider>().value = operation.progress;
            Debug.Log("CArregando: " + operation.progress);
            yield return null;
        }
        Debug.Log("Here");
        
    }
}

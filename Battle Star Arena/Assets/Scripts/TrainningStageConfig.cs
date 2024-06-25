using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrainningStageConfig : MonoBehaviour
{
    [SerializeField]
    private GameObject avengerIPrefab;
    private GameObject selectedSpacecraftPrefab;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickAvengerI()
    {
        selectedSpacecraftPrefab = avengerIPrefab;
        Debug.Log("Prefab selected");
    }

    public void OnClickGoToTrainningArea()
    {
        Debug.Log("click");
        if(selectedSpacecraftPrefab != null)
        {
            SceneManager.LoadScene("Trainning Stage");
        }
       
    }

    public GameObject GetSelectedSpacecraftPrefab()
    {
        return selectedSpacecraftPrefab;
    }


}

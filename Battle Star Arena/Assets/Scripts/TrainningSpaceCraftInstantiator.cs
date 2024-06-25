using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainningSpaceCraftInstantiator : MonoBehaviour
{
    [SerializeField]
    private GameObject avengerIPrefab;

    private GameObject selectedSpacecraft;


    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool SelectSpaceCrat(string name)
    {
        if(name == "Avenger I")
        {
            selectedSpacecraft = avengerIPrefab;
            return true;
        }

        return false;
    }


    public void OnClickAvengerI()
    {
        selectedSpacecraft = avengerIPrefab;

    }
}

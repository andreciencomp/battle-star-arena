using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rig;
    TMPro.TextMeshProUGUI textSpeed;


    void Start()
    {
        textSpeed = GetComponent<TMPro.TextMeshProUGUI>();  
    }

    // Update is called once per frame
    void Update()
    {
        float kmh = rig.velocity.magnitude * 3.6f;
        textSpeed.SetText("speed: " + Mathf.Floor(kmh));
        
    }
}

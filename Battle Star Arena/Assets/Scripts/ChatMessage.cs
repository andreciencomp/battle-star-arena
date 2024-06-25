using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatMessage : MonoBehaviour
{
    private string message;
    void Start()
    {
       // text = GetComponent<TMPro.TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetChatMessage()
    {
        return message;
    }

    public void SetChatMessage(string message)
    {
        this.message = message;
        GetComponent<TMPro.TextMeshProUGUI>().SetText(message);
    }
}

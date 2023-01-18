using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityLibrary;

public class NPC : MonoBehaviour
{
    public UnityEvent gazedEvent;
    public UnityEvent notGazedEvent;
    public NPCDATA data;

    /// <summary>
    /// This method is called by the Main Camera when it starts gazing at this GameObject.
    /// </summary>
    /// 

    public void Start()
    {
        
    }
    public void OnPointerEnter()
    {
        OpenAI.Instance.loadedNpc = data;
        gazedEvent?.Invoke();
    }

    /// <summary>
    /// This method is called by the Main Camera when it stops gazing at this GameObject.
    /// </summary>
    public void OnPointerExit()
    {
        notGazedEvent?.Invoke();
    }
}

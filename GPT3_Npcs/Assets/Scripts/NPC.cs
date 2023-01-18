using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPC : MonoBehaviour
{
    public UnityEvent gazedEvent;
    public UnityEvent notGazedEvent;
    public string context;

    /// <summary>
    /// This method is called by the Main Camera when it starts gazing at this GameObject.
    /// </summary>
    /// 

    public void Start()
    {
        
    }
    public void OnPointerEnter()
    {
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

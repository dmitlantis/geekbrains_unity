using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIHealth : MonoBehaviour
{
    [SerializeField] public LivesMeter livesMeter;
    
    private void OnGUI()
    {
        GUI.Box(new Rect(10,150,50,50), "Health");
        GUI.Label(new Rect(15, 180, 40, 40), livesMeter.health.ToString());
    }
}

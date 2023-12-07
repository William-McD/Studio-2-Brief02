using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Debug.Log("I just got enabled!", this);
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public class WhoIsEnablingThis : MonoBehaviour
    {
        private void OnEnable()
        {
            Debug.Log("I just got enabled!", this);
        }
    }
}

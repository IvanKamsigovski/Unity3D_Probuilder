using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PPSetings : MonoBehaviour
{
   [SerializeField] private PostProcessVolume activeVolume;

    private void Start()
    {
        GetComponent<PostProcessVolume>();
        activeVolume.enabled = false;
        
    }

    private void OnTriggerEnter(Collider collider)
    { 

        if (collider.gameObject.tag == "PowerUP")
        {
            Debug.Log("Ovo");
            activeVolume.enabled = true;
        }
       
    }
}

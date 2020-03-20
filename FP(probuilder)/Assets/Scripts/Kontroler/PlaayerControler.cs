using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlaayerControler : MonoBehaviour
{

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Debug.Log("Radi za neprijatelja");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshCombiner : MonoBehaviour
{
    public void CombineMeshes()
    {
        Quaternion oldRot = transform.rotation;
        Vector3 oldPos = transform.position;

        transform.rotation = Quaternion.identity;
        transform.position = Vector3.zero;

        //Dohvacamo sve Meshove
        MeshFilter[] filters = GetComponentsInChildren<MeshFilter>();

        Debug.Log(name + "  " + filters.Length +" meshes ");

        Mesh finalMesh = new Mesh();//Placeholder za mesheve

        CombineInstance[] combiners = new CombineInstance[filters.Length];

        //Prolazimo kroz sve filtere
        for (int a = 0; a < filters.Length; a++)
        {
            //Iskljucujemo sebe
            if (filters[a].transform == transform)
                continue;

            //Ostale dodajemo u niz
            combiners[a].subMeshIndex = 0;
            combiners[a].mesh = filters[a].sharedMesh;//Odabiremo mesh
            combiners[a].transform = filters[a].transform.localToWorldMatrix;//Odredimo poziciju 
        }

        //Spajamo mesheve
        finalMesh.CombineMeshes(combiners);

        //Stavimo u nas mesh kako bi ga vidili
        GetComponent<MeshFilter>().sharedMesh = finalMesh;

        transform.rotation = oldRot;
        transform.position = oldPos;

        //Turn off children
        for (int a = 0; a < transform.childCount; a++)
        {
            transform.GetChild(a).gameObject.SetActive(false);
        }
    }
}

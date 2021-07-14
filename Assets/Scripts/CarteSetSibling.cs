using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarteSetSibling : MonoBehaviour
{
    private GameObject carte;
    private string carte_active_name;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PutForward()
    {
        carte_active_name = this.name;

        carte = GameObject.Find(carte_active_name);
        carte.transform.SetAsLastSibling();
    }
}

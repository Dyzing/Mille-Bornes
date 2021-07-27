using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationPlate : MonoBehaviour
{
    public GameObject plateau;

    void Start()
    {
        
    }

    void Update()
    {
        plateau.transform.Rotate(new Vector3(0, 1, 0) * 0.5f);
    }


    private void OnTriggerEnter(Collider other)
    {
        ChangeVoiture.voitureInstanciee.transform.SetParent(plateau.transform);
    }
}

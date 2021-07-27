using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeVoiture : MonoBehaviour
{
    public GameObject spawn;
    public GameObject voiturePrefab1;
    public GameObject voiturePrefab2;
    public GameObject voiturePrefab3;
    public GameObject voiturePrefab4;
    public static GameObject voitureInstanciee;
    void Start()
    {
        GarageManager.id_voiture = 1;
    }

    public void SpawnVoiture()
    {
        if (voitureInstanciee)
        {
            Destroy(voitureInstanciee);
        }
        switch (GarageManager.id_voiture)
        {
            case 1:
                voitureInstanciee = Instantiate(voiturePrefab1, spawn.transform.position, Quaternion.identity);
                break;
            case 2:
                voitureInstanciee = Instantiate(voiturePrefab2, spawn.transform.position, Quaternion.identity);
                break;
            case 3:
                voitureInstanciee = Instantiate(voiturePrefab3, spawn.transform.position, Quaternion.identity);
                break;
            case 4:
                voitureInstanciee = Instantiate(voiturePrefab4, spawn.transform.position, Quaternion.identity);
                break;
            default:
                break;
        }
        voitureInstanciee.transform.Rotate(0,180,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickLeft()
    {
        GarageManager.id_voiture--;
        if (GarageManager.id_voiture == 0)
        {
            GarageManager.id_voiture = 4;
        }
        SpawnVoiture();
    }

    [PunRPC]
    private void ChangeIdLeft()
    {
        GarageManager.id_voiture--;
        if (GarageManager.id_voiture == 0)
        {
            GarageManager.id_voiture = 4;
        }
    }

    public void OnClickRight()
    {
        GarageManager.id_voiture++;
        if (GarageManager.id_voiture == 5)
        {
            GarageManager.id_voiture = 1;
        }
        SpawnVoiture();
    }

    [PunRPC]
    private void ChangeIdRight()
    {
        GarageManager.id_voiture++;
        if (GarageManager.id_voiture == 5)
        {
            GarageManager.id_voiture = 1;
        }
    }
}

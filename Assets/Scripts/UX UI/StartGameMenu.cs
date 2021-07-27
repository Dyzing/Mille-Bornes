using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameMenu : ChangeVoiture
{
    public GameObject startGameCanvas;
    public GameObject switchVoitureCanvas;

    private void Start()
    {
        switchVoitureCanvas.SetActive(false);
    }
    public void RemoveStartGameCanvas()
    {
        startGameCanvas.SetActive(false);
        switchVoitureCanvas.SetActive(true);
        SpawnVoiture();
    }
}

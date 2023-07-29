using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TMP_Text titulo;
    public TMP_Text puntaje;
    public TMP_Text txtGameOver;
    public TMP_Text txtWin;

    public Player player;

    public GameObject cherry;

    private void Start()
    {
        puntaje.text = player.countDots.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isDead)
        {
            titulo.gameObject.SetActive(false);
            puntaje.gameObject.SetActive(false);
            txtGameOver.gameObject.SetActive(true);
        }
        else if (player.countDots == 15)
        {
            txtWin.gameObject.SetActive(true);
            cherry.SetActive(true);
        }

        puntaje.text = player.countDots.ToString();
    }


}

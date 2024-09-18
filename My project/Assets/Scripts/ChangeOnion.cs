using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChangeOnion : MonoBehaviour
{
    public Image image;
    public Image pimentao;
    public Image cebolaCortada;
    public Image camarao;
    public List<Sprite> spriteChoices;

    private int counter;
    private int currentSprite = 0;

    void Update()
    {
        // Verifica se a barra de espaço foi pressionada
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextSprite();
        }
    }

    public void NextSprite()
    {
        pimentao.enabled = false;
        cebolaCortada.enabled = false;
        camarao.enabled = false;


        counter++;
        print(counter);
        if (counter == 5)
        {
            currentSprite++;
            counter = 0;
            if (currentSprite >= spriteChoices.Count)
            {   
                image.enabled = false;
                Debug.Log("Sprite removida");
                pimentao.enabled = true;
                cebolaCortada.enabled = true;
                camarao.enabled = true;
             
            }
            image.sprite = spriteChoices[currentSprite];
        }
    }
}

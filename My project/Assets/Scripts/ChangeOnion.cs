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

    void Awake()
    {
        pimentao.enabled = false;
        cebolaCortada.enabled = false;
        camarao.enabled = false;
    }

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
        counter++;
        print(counter);
        if (counter == 2)
        {
            currentSprite++;
            counter = 0;
            if (currentSprite >= spriteChoices.Count)
            {
                image.enabled = false;
                Debug.Log("Sprite removida");
            }

            else if (currentSprite == 4)
            {
                cebolaCortada.enabled = true;
            }

            else if (currentSprite == 5)
            {
                pimentao.enabled = true;
            }

            else if (currentSprite == 6)
            {
                camarao.enabled = true;
            }


            image.sprite = spriteChoices[currentSprite];
        }
    }
}

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {

    public GameObject textBox;
    public GameObject fluteStatique;
    public GameObject fluteCinematique;
    public Text theText;
    public TextAsset textFile;
    public string[] textLines;
    public int currentLine;
    public int endAtLine;
    public PlayerMotor player;
    public bool isActive;
    public bool stopPlayerMovement;


    public void Awake()
    {
        fluteStatique.SetActive(true);
        fluteCinematique.SetActive(false);
    }

    void Start()
    {

        player = FindObjectOfType<PlayerMotor>();

        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
            // on met dans notre array tout ce qu'il y a dans fichier text
        }

        if (endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
            // Comme cela pas de problèmes pour ce qui est de commencer à 0 ou 1

        }

        if (isActive)
        {
            EnableTextBox();
        }
        else
        {
            DisableTextBox();
        }

    }

    void Update()
    {

        if (!isActive)
        {
            return;
            //si notre box n'apparaît pas, pas besoin d'update la variable currentLine
        }
        theText.text = textLines[currentLine];
        // on affiche la première ligne

        if(Input.GetKeyDown("down"))
        {
            currentLine += 1;
            //a chaque fois qu'on appuie sur la flèche du bas le texte du dessous sera affiché
        }

        if (currentLine > endAtLine)
        {
            DisableTextBox();
            //si l'indice est supérieur à la dernière ligne, la textBox disparaît
        }

        if (currentLine == 44)
        {
            fluteStatique.SetActive(false);
            fluteCinematique.SetActive(true);
        }

        if (currentLine == 45)
        {
            fluteCinematique.SetActive(false);
        }
    }

    public void EnableTextBox()
    {
        textBox.SetActive(true);
        isActive = true;

        if (stopPlayerMovement)
        {
            player.canMove = false;
        }
    }

    public void DisableTextBox()
    {
        textBox.SetActive(false);
        isActive = false;
        player.canMove = true;
    }

    public void ReloadScript(TextAsset theText)
    {
        if (theText != null)
        {
            textLines = new string[1];
            textLines = (theText.text.Split('\n'));
        }
    }
}

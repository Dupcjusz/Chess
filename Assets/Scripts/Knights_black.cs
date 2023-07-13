using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class Knights_black : Board_manager
{
    private GameObject knight_B8;
    private GameObject knight_G8;

    void Awake(){
        knight_B8 = GameObject.Find("Canvas/Board/Pieces_black/KnightB8");
        knight_G8 = GameObject.Find("Canvas/Board/Pieces_black/KnightG8");
    }

    void Start(){
        knight_B8.GetComponent<RectTransform>().anchoredPosition = defaultPos;
        knight_G8.GetComponent<RectTransform>().anchoredPosition = defaultPos;
    }
}
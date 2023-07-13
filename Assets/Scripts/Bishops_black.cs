using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class Bishops_black : Board_manager
{
    private GameObject bishop_C8;
    private GameObject bishop_F8;

    void Awake(){
        bishop_C8 = GameObject.Find("Canvas/Board/Pieces_black/BishopC8");
        bishop_F8 = GameObject.Find("Canvas/Board/Pieces_black/BishopF8");
    }

    void Start()
    {
        bishop_C8.GetComponent<RectTransform>().anchoredPosition = defaultPos;
        bishop_F8.GetComponent<RectTransform>().anchoredPosition = defaultPos;
    }
}

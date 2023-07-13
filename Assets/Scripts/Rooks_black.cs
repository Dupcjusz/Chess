using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class Rooks_black : Board_manager
{
    private GameObject rook_A8;
    private GameObject rook_H8;

    void Awake(){
        rook_A8 = GameObject.Find("Canvas/Board/Pieces_black/RookA8");
        rook_H8 = GameObject.Find("Canvas/Board/Pieces_black/RookH8");
    }

    void Start(){
        rook_A8.GetComponent<RectTransform>().anchoredPosition = defaultPos;
        rook_H8.GetComponent<RectTransform>().anchoredPosition = defaultPos;
    }
}

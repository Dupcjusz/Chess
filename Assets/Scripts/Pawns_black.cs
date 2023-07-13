using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class Pawns_black : Board_manager
{
    private GameObject pawn_A7;
    private GameObject pawn_B7;
    private GameObject pawn_C7;
    private GameObject pawn_D7;
    private GameObject pawn_E7;
    private GameObject pawn_F7;
    private GameObject pawn_G7;
    private GameObject pawn_H7;

    void Awake(){
        pawn_A7 = GameObject.Find("Canvas/Board/Pieces_black/PawnA7");
        pawn_B7 = GameObject.Find("Canvas/Board/Pieces_black/PawnB7");
        pawn_C7 = GameObject.Find("Canvas/Board/Pieces_black/PawnC7");
        pawn_D7 = GameObject.Find("Canvas/Board/Pieces_black/PawnD7");
        pawn_E7 = GameObject.Find("Canvas/Board/Pieces_black/PawnE7");
        pawn_F7 = GameObject.Find("Canvas/Board/Pieces_black/PawnF7");
        pawn_G7 = GameObject.Find("Canvas/Board/Pieces_black/PawnG7");
        pawn_H7 = GameObject.Find("Canvas/Board/Pieces_black/PawnH7");
    }

    void Start(){
        pawn_A7.GetComponent<RectTransform>().anchoredPosition = defaultPos;
        pawn_B7.GetComponent<RectTransform>().anchoredPosition = defaultPos;
        pawn_C7.GetComponent<RectTransform>().anchoredPosition = defaultPos;
        pawn_D7.GetComponent<RectTransform>().anchoredPosition = defaultPos;
        pawn_E7.GetComponent<RectTransform>().anchoredPosition = defaultPos;
        pawn_F7.GetComponent<RectTransform>().anchoredPosition = defaultPos;
        pawn_G7.GetComponent<RectTransform>().anchoredPosition = defaultPos;
        pawn_H7.GetComponent<RectTransform>().anchoredPosition = defaultPos;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class Rooks_white : MonoBehaviour
{
    private GameObject rook_A1;
    private GameObject rook_H1;

    void Awake(){
        rook_A1 = GameObject.Find("Canvas/Board/Pieces_white/RookA1");
        rook_H1 = GameObject.Find("Canvas/Board/Pieces_white/RookH1");
    }

    void Start(){
        rook_A1.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        rook_H1.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
    }
}

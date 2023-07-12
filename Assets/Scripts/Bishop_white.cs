using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class Bishops_white : MonoBehaviour
{
    private GameObject bishop_C1;
    private GameObject bishop_F1;

    void Awake(){
        bishop_C1 = GameObject.Find("Canvas/Board/Pieces_white/BishopC1");
        bishop_F1 = GameObject.Find("Canvas/Board/Pieces_white/BishopF1");
    }

    void Start(){
        bishop_C1.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        bishop_F1.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
    }
}

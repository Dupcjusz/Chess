using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class Knights_white : MonoBehaviour
{
    private GameObject knight_B1;
    private GameObject knight_G1;

    void Awake(){
        knight_B1 = GameObject.Find("Canvas/Board/Pieces_white/KnightB1");
        knight_G1 = GameObject.Find("Canvas/Board/Pieces_white/KnightG1");
    }

    void Start(){
        knight_B1.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        knight_G1.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class Queen_white : MonoBehaviour
{
    private GameObject queen_D1;

    void Awake(){
        queen_D1 = GameObject.Find("Canvas/Board/Pieces_white/QueenD1");
    }

    void Start(){
        queen_D1.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
    }
}

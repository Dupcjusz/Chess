using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class Queen_black : MonoBehaviour
{
    private GameObject queen_D8;

    void Awake(){
        queen_D8 = GameObject.Find("Canvas/Board/Pieces_black/QueenD8");
    }

    void Start(){
        queen_D8.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
    }
}

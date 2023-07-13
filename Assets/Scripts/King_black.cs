using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class King_black : Board_manager
{
    private GameObject king_E8;

    void Awake(){
        king_E8 = GameObject.Find("Canvas/Board/Pieces_black/KingE8");
    }

    void Start(){
        king_E8.GetComponent<RectTransform>().anchoredPosition = defaultPos;
    }
}

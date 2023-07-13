using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class King_white : Board_manager
{
    private GameObject king_E1;

    void Awake(){
        king_E1 = GameObject.Find("Canvas/Board/Pieces_white/KingE1");
    }

    void Start(){
        king_E1.GetComponent<RectTransform>().anchoredPosition = defaultPos;
    }
}

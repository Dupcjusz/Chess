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
    private Image king_E1;

    void Awake(){
        Setup();

        king_E1 = boardFields[4];
    }

    void Start(){
        
    }
}

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
    private Image king_E8;

    void Awake(){
        Setup();

        king_E8 = boardFields[60];
    }

    void Start(){
        
    }
}

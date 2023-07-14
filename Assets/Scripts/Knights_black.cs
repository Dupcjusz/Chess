using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class Knights_black : Board_manager
{
    private Image knight_B8;
    private Image knight_G8;

    void Awake(){
        Setup();

        knight_B8 = boardFields[57];
        knight_G8 = boardFields[62];
    }

    void Start(){
        
    }
}
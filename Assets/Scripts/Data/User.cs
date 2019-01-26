using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UserData", menuName = "CreatUserData")]
[System.Serializable]
public class User : ScriptableObject {
    public string userName;
    public int score;
}

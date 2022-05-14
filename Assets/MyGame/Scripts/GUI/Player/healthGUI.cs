
using UnityEngine;

public class healthGUI : MonoBehaviour
{
    [SerializeField] int health = 100;
    GUIStyle myStyle = new GUIStyle();

    private void Awake()
    {
        myStyle.fontSize = 38;
    }
    private void OnGUI()
    {
        GUI.Label(new Rect(0, Screen.height - 50, 100, 50), health.ToString(), myStyle);
    }
}
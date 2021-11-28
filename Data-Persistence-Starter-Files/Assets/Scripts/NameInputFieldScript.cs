using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NameInputFieldScript : MonoBehaviour
{
    public string NameInputName;
    public Text CurrentNameText;
    public Text CurrentHighscoreText;
    private void Awake()
    {
        var input = gameObject.GetComponent<InputField>();
        input.text = DataManager.Instance.LastName;
    }
    void Start()
    {
        var input = gameObject.GetComponent<InputField>();
        var se = new InputField.SubmitEvent();
        se.AddListener(SubmitName);
        input.onEndEdit = se;
    }
    private void SubmitName(string name)
    {
        Debug.Log(name);
        NameInputName = name;
        SetNameText(name);
        DataManager.Instance.LastName = name;
        DataManager.Instance.SaveName();
    }
    public void SetNameText(string name)
    {
        CurrentNameText.text = "Name " + name;
    }
}

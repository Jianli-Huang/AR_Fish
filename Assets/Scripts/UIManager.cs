using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour {

	[SerializeField]
	Transform canvasTransform;

	AnimalControl openAnimalControl;
	Button returnBtn;
	Button eatBtn;
	Text nameText;
	static UIManager _instance;

	public static UIManager Instance
	{
		get
		{
			return _instance;
		}
	}

	void Awake()
	{
		_instance = this;
		returnBtn = canvasTransform.Find("ReturnButton").GetComponent<Button>();
		eatBtn = canvasTransform.Find("EatButton").GetComponent<Button>();
		nameText = canvasTransform.Find("Name/Text").GetComponent<Text>();
	}
	// Use this for initialization
	void Start () 
	{
		nameText.transform.parent.gameObject.SetActive(false);
		returnBtn.onClick.AddListener(ReturnBtnClick);
		eatBtn.onClick.AddListener(EatBtnClick);
	}
	
	void ReturnBtnClick()
	{
		SceneManager.LoadScene("loading");
	}

	void EatBtnClick()
	{
		Debug.Log(" 单击 ' 进食 ' 按钮 ");
		if (openAnimalControl != null)
		{
			openAnimalControl.PlayAnimation(AnimalControl.AnimType.Eat);
		}
	}

	public void ShowAnimalName(AnimalControl _ac)
	{
		openAnimalControl = _ac;
		nameText.text = _ac.AnimalName;
		nameText.transform.parent.gameObject.SetActive(true);
		eatBtn.gameObject.SetActive(true);
	}
	
	public void HideAnimalName()
	{
		nameText.transform.parent.gameObject.SetActive(false);
		eatBtn.gameObject.SetActive(false);
	}
}

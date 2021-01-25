using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour {

	[SerializeField]
	Transform canvasTransform;
	Button startBtn;
	Button quitBtn;
	AsyncOperation asyncOperation;
	Image progressImage;

	// Use this for initialization
	void Start () 
	{
		startBtn = canvasTransform.Find("StartButton").GetComponent<Button>();
		quitBtn = canvasTransform.Find("QuitButton").GetComponent<Button>();
		progressImage = canvasTransform.Find("ProgressBar/progress").GetComponent<Image>();

		progressImage.transform.parent.gameObject.SetActive(false);

		startBtn.onClick.AddListener(() => StartBtnClick(startBtn.gameObject));
		quitBtn.onClick.AddListener(QuitBtnClick);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (asyncOperation != null)
		{
			progressImage.fillAmount = asyncOperation.progress;
		}
	}

	void StartBtnClick(GameObject btn)
	{
		Debug.Log(" 单击开始按钮 " + btn.name);
		startBtn.gameObject.SetActive(false);
		quitBtn.gameObject.SetActive(false);
		progressImage.transform.parent.gameObject.SetActive(true);
		asyncOperation = SceneManager.LoadSceneAsync("arScene");
	}
	void QuitBtnClick()
	{
#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit();
#endif
	}
}

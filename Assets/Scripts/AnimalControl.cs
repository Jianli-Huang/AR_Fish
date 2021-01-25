using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

[RequireComponent(typeof(RotateControl))]
public class AnimalControl : MonoBehaviour, ITrackableEventHandler
{
	[SerializeField]
	string animalName = " 白鲸 ";
	private TrackableBehaviour mTrackableBehaviour;
	private RotateControl rotateControl;
	private Animator anim;

	public string AnimalName
	{
		get
		{
			return animalName;
		}
	}
	public enum AnimType
	{
		Swim,
		Eat,	
	}

	// Use this for initialization
	void Start () 
	{
		mTrackableBehaviour = transform.parent.GetComponent<TrackableBehaviour>();
		rotateControl = transform.GetComponent<RotateControl>();
		anim = transform.GetComponentInChildren<Animator>();
		if (mTrackableBehaviour)
		{
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
		}
	}
	
	
	public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
	{
		if (newStatus == TrackableBehaviour.Status.DETECTED ||
			newStatus == TrackableBehaviour.Status.TRACKED ||
			newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
		{
			gameObject.SetActive(true);
			if (UIManager.Instance != null)
			{
				UIManager.Instance.ShowAnimalName(this);
			}
		}
		else
		{
			gameObject.SetActive(false);
			rotateControl.Init();
			if (UIManager.Instance != null)
			{
				UIManager.Instance.HideAnimalName();
			}
		}
	}

	public void PlayAnimation(AnimType _type)
	{
		if(_type == AnimType.Swim)
		{
			anim.SetTrigger("Swim");
		}
		else
		{
			anim.SetTrigger("Eat");
		}
	}

	// Update is called once per frame
	void Update()
	{

	}
}

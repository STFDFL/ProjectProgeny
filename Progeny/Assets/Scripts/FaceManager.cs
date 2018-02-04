using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceManager : MonoBehaviour {

    List<GameObject> faces;
    public GameObject face_Neutral;
    public GameObject face_Happy;
    public GameObject face_Angry;



    public enum FaceState { Neutral, Happy, Angry, }

    // Use this for initialization
    void Start()
    {
        faces = new List<GameObject>();
        faces.Add(face_Neutral);
        faces.Add(face_Happy);
        faces.Add(face_Angry);

        SetFaceState(FaceState.Neutral);
    }

    public void ButtonFaceSetter(string facetype)
    {        
        SetFaceState((FaceState)Enum.Parse(typeof(FaceState),facetype));
    }

	public void SetFaceState(FaceState faceState)
    {
        switch (faceState)
        {
            case FaceState.Neutral:
                StartCoroutine(SetFaceNeutral());
                break;

            case FaceState.Happy:
                StartCoroutine(SetFaceHappy());
                break;

            case FaceState.Angry:
                StartCoroutine(SetFaceAngry());
                break;

            default:
                break;
        }
    }


    IEnumerator SetFaceNeutral()
    {
        foreach (GameObject faceType in faces)
        {
            faceType.SetActive(false);
        }
        face_Neutral.SetActive(true);

        yield return new WaitForSeconds(.1f);
        

    }

    IEnumerator SetFaceHappy()
    {
        foreach (GameObject faceType in faces)
        {
            faceType.SetActive(false);
        }
        face_Happy.SetActive(true);

        yield return new WaitForSeconds(.1f);

    }

    IEnumerator SetFaceAngry()
    {
        foreach (GameObject faceType in faces)
        {
            faceType.SetActive(false);
        }
        face_Angry.SetActive(true);

        yield return new WaitForSeconds(.1f);

    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    private Material currentMaterial;
    public float     Speed;
    private float    OffSet;

	// Use this for initialization
	void Start () {
        currentMaterial = GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
        //OffSet += Speed * Time.deltaTime;
        //currentMaterial.SetTextureOffset("_MainTex", new Vector2(OffSet, 0));
        if (MinigameManager.Instance.IsGamePlaying())
        {
            OffSet += Speed * Time.deltaTime;
            if (Mathf.Abs(OffSet) > 1.0f)
            {
                // Se Offset ultrapassar 1, reinicie para evitar deformações
                OffSet = 0.0f;
            }

            currentMaterial.SetTextureOffset("_MainTex", new Vector2(OffSet, 0));
        }
    }
}

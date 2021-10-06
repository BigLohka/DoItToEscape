using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Parameters")]
    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    private string playerTag;
    [SerializeField]
    private float movingSpeed;
    [SerializeField]
    private int xOffset;
    [SerializeField]
    private int yOffset;
    [SerializeField]
    private int zOffset;


    private void Awake()
    {
        if (this.playerTransform == null)
        {
            if (this.playerTag == "")
            {
                this.playerTag = "Player";
            }

            this.playerTransform = GameObject.FindGameObjectWithTag(this.playerTag).transform;
        }

        this.transform.position = new Vector3()
        {
            x = this.playerTransform.position.x + xOffset,
            y = this.playerTransform.position.y + yOffset,
            z = this.playerTransform.position.z - zOffset,
        };
    }

    private void Update()
    {
        if(this.playerTransform)
        {
            Vector3 target = new Vector3()
            {
                x = this.playerTransform.position.x + xOffset,
                y = this.playerTransform.position.y + yOffset,
                z = this.playerTransform.position.z - zOffset,
            };

            Vector3 pos = Vector3.Lerp(this.transform.position, target, this.movingSpeed * Time.deltaTime);

            this.transform.position = pos;
        }
    }
}

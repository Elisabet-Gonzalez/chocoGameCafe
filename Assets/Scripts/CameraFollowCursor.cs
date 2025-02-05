using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowCursor : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed = 3f;
    float fixedZ = -10f;
    
    

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;

        Vector2 worldMousePos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, 0f, fixedZ));

        float targetX = Mathf.Clamp(worldMousePos.x, -2.6f, 24f);

        transform.position = Vector3.Lerp(transform.position, new Vector3(targetX, 0f, fixedZ), speed * Time.deltaTime);

    }
}

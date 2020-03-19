using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBackgroundSizeToScreenSize : MonoBehaviour
{
  //  Vector2 screenBounds;
    private void Start()
    {
        // screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        //  gameObject.transform.localScale = new Vector2(screenBounds.x, screenBounds.y);

        var height = Camera.main.orthographicSize * 2.0f;
        var width = height * Screen.width / Screen.height;

        transform.localScale = new Vector2(width, height);
    }


}

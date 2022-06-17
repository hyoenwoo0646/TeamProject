using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMove : MonoBehaviour
{

    public GameObject prfAtkDial;
    public GameObject canvas;

    Player player;

    RectTransform atkDial;

    //public Image atkDial;
    private float maxLimit = 5.0f;
    private float limittime;
    // Start is called before the first frame update

    private void Awake()
    {
        limittime = maxLimit;
    }
    void Start()
    {
         atkDial = Instantiate(prfAtkDial, canvas.transform).GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player2").GetComponent<Player>();
        Vector2 dialPos = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + 2.2f, transform.position.z));

        atkDial.position = dialPos;

        if (player.Usedgun == true)
        {

            limittime -= Time.deltaTime;
            //atkDial.fillAmount = limittime / maxLimit;
            atkDial.GetComponent<Image>().fillAmount = limittime / maxLimit;
            player.Fire();
        }

        if (limittime < 0f)
        {
            player.Usedgun = false;
            limittime = maxLimit;
        }

        player.Reload();
        
    }
}

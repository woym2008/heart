using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteController : MonoBehaviour
{
    public float ShineTime = 1.5f;

    SpriteRenderer _renderer;
    // Start is called before the first frame update
    void Start()
    {
        _renderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            Shine();
        }
    }

    public void Shine()
    {
        StartCoroutine(shineupdate());
        ;
    }

    IEnumerator shineupdate()
    {
        float curtime = 0;
        float targettime = ShineTime * 0.5f;
        while (curtime <= targettime)
        {
            yield return 0;
            curtime += Time.deltaTime;

            var alpha = Mathf.Lerp(0, 1f, curtime/ targettime);
            _renderer.color = new Color(_renderer.color.r, _renderer.color.g, _renderer.color.b, alpha);

        }


        StartCoroutine(shineupdate2());
    }

    IEnumerator shineupdate2()
    {
        float curtime = 0;
        float targettime = ShineTime * 0.5f;
        while (curtime <= targettime)
        {
            yield return 0;
            curtime += Time.deltaTime;

            var alpha = Mathf.Lerp(1.0f, 0, curtime / targettime);
            _renderer.color = new Color(_renderer.color.r, _renderer.color.g, _renderer.color.b, alpha);

        }
    }
}

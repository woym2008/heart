using UnityEngine;
using System.Collections;

public class DialogController : MonoBehaviour
{
    public Animator _anim;

    private void Start()
    {
        _anim = this.gameObject.GetComponent<Animator>();
    }

    public void Play(string name)
    {
        if(_anim != null)
        {
            _anim.Play(name);
        }
    }
}

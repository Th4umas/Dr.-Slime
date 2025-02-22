using UnityEngine;
using UnityEngine.SceneManagement;

public class LaboSlimes : MonoBehaviour
{
    private MeshRenderer m_meshrenderer;
    //private Animator m_animator;

    public Color hoverColor = Color.gray;
    private Color startColor;
    void Start()
    {
        //m_animator = GetComponent<Animator>();
        m_meshrenderer = GetComponent<MeshRenderer>();

        startColor = m_meshrenderer.material.color;
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            SceneManager.LoadScene(0);
        }
    }

    private void OnMouseEnter()
    {
        m_meshrenderer.material.color = hoverColor;
    }
    private void OnMouseExit()
    {
        m_meshrenderer.material.color = startColor;
    }

    private void OnMouseDown()
    {
        select();
    }

    private void select()
    {
        //m_animator.SetBool("select", true);
    }
}

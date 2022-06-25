using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    // Variaveis
    private Vector3 minhaPosicao;
    private float meuY;
    public float velocidade = 12;
    private float limite = 3.5f;
    public bool automatico = false;
    public Transform transformBall;

    // Start is called before the first frame update
    void Start()
    {
        // Pegando a posição inicial do Player e atribuindo a minhaPosicao
        minhaPosicao = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Passando o meuY para o eixo Y da minhaPosicao
        minhaPosicao.y = meuY;

        // Modifica a posição do meu Player
        transform.position = minhaPosicao;

        // Velocidade*DeltaTime
        float velocidadeDelta = velocidade * Time.deltaTime;

        // Se a i.a estiver false o player pode se mover
        if (!automatico)
        {
            // Movimentação player 1
            if (minhaPosicao.x == -7.5f)
            {
                if (Input.GetKey(KeyCode.W))
                {
                    meuY += velocidadeDelta;
                }

                if (Input.GetKey(KeyCode.S))
                {
                    meuY -= velocidadeDelta;
                }
            }

            // Movimentação player 2
            if (minhaPosicao.x == 7.5f)
            {
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    meuY += velocidadeDelta;
                }

                if (Input.GetKey(KeyCode.DownArrow))
                {
                    meuY -= velocidadeDelta;
                }
            }
        }
        
        // I.A
        if (automatico)
        {
            meuY = Mathf.Lerp(meuY, transformBall.position.y, 0.03f);
        }

        // Ativa a i.a no player2 se apertar enter
        if (minhaPosicao.x == 7.5f && Input.GetKey(KeyCode.Return))
        {
            automatico = true;
        }

        // Desativa a i.a se o player2 tentar se mover
        else
        {
            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
            {
                automatico = false;
            }
        }

        // Limitando o player não sair da scene
        if (meuY < -limite)
        {
            // baixo
            meuY = -limite;
        }

        if (meuY > limite)
        {
            // cima
            meuY = limite;
        }
    }
}
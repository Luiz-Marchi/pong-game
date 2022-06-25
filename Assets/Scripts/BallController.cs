using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    public Rigidbody2D meuRB;
    private Vector2 minhaVelocidade;
    public float velocidade = 7f;
    public float limitePontos = 12f;
    public AudioClip boingSound;
    public Transform cameraPosition;
    public float delay = 2f;
    private bool jogoIniciado = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Iniciando a bola com delay
        delay -= Time.deltaTime;

        if (delay <= 0 && !jogoIniciado)
        {
            // Alterando o valor da variavel de controle
            jogoIniciado = true;

            // Escolhendo a direção inicial da bola
            int direcao = Random.Range(0, 4);

            // Diagonal superior direita
            if (direcao == 0)
            {
                minhaVelocidade.x = velocidade;
                minhaVelocidade.y = velocidade;
            }

            // Diagonal inferior direita
            if (direcao == 1)
            {
                minhaVelocidade.x = velocidade;
                minhaVelocidade.y = -velocidade;
            }

            // Diagonal inferior esquerda
            if (direcao == 2)
            {
                minhaVelocidade.x = -velocidade;
                minhaVelocidade.y = -velocidade;
            }

            // Diagonal inferior esquerda
            if (direcao == 3)
            {
                minhaVelocidade.x = -velocidade;
                minhaVelocidade.y = velocidade;
            }

            // Aplicando velocidade na bola
            meuRB.velocity = minhaVelocidade;
        }

        // Checa se a bola saiu da tela
        if (transform.position.x <= -limitePontos || transform.position.x >= limitePontos)
        {
            // Restarta a scene
            SceneManager.LoadScene("Jogo");
        }
    }

    // Evento de colisão
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(boingSound, cameraPosition.transform.position);
    }
}
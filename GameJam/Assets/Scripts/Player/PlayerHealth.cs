using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int _maxHealth = 100;
    //[SerializeField] GameObject _deathPanel = null;
    [SerializeField] AudioSource _playerDeath;
    [SerializeField] AudioSource _playerHurt;
    [SerializeField] AudioSource _playerDrink;
    [SerializeField] AudioSource _playerAttack;
    [SerializeField] int _maxStamina = 100;

    public int _currentStamina = 100;

    public int _currentHealth = 100;

    public int _damageToTake = 30;
    public int _staminaToUse = 50;

    public HealthBar _healthBar = null;
    public StaminaBar _staminaBar = null;

    public static StaminaBar instance;

    private void Start()
    {
        instance = _staminaBar;

        //_deathPanel.SetActive(false);
        _currentHealth = _maxHealth;
        _currentStamina = _maxStamina;
        _healthBar.SetMaxHealth(_maxHealth);
        _staminaBar.SetMaxStamina(_maxStamina);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TakeDmg(_damageToTake);
        }

        if (_currentHealth <= 0)
        {

            PlayerDeath();
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            UseStamina(_staminaToUse);
        }
    }

    public void AddHealth(int slurp)
    {
        _currentHealth += slurp;
        if (_currentHealth > 100)
        {
            _currentHealth = 100;
        }

        _healthBar.SetHealth(_currentHealth);
        
        _playerDrink.Play(0);
        if (_playerDrink != null)
        {
            AudioSource newSound = Instantiate(_playerDrink, transform.position, Quaternion.identity);
            Destroy(newSound.gameObject, newSound.clip.length);
        }
    }

    public void UseStamina(int sprint)
    {
        _currentStamina -= sprint;

        _staminaBar.SetStamina(_currentStamina);

        StartCoroutine(RegenStamina());
    }

    public void TakeDmg(int damage)
    {
        _currentHealth -= damage;

        _healthBar.SetHealth(_currentHealth);

        if(_playerHurt != null)
        {
            AudioSource newSound = Instantiate(_playerHurt, transform.position, Quaternion.identity);
            Destroy(newSound.gameObject, newSound.clip.length);
        }
        
    }
    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(2);

        while(_currentStamina < _maxStamina)
        {
            _currentStamina += _maxStamina / 10;
            _staminaBar.SetStamina(_currentStamina);
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void PlayerDeath()
    {
        _playerDeath.Play(0);
        SceneManager.LoadScene("LoseScreen");
        /*
        //Debug.Log("You have died");

        AudioSource newSound = Instantiate(_playerDeath, transform.position, Quaternion.identity);
        Destroy(newSound.gameObject, newSound.clip.length);

        _deathPanel.SetActive(true);
        //allow the mouse cursor to move around game window
        Cursor.lockState = CursorLockMode.Confined;
        //make the mouse cursor visible
        Cursor.visible = true;
        */
    }

    // health/damage
    public int attack;

    public void TakeDamage(int amount)
    {
        TakeDmg(amount);
        _playerHurt.Play(0);
    }

    public void DealDamage(GameObject Enemy)
    {
        var enemyAtt = Enemy.GetComponent<EnemyAttributes>();
        if (enemyAtt != null)
        {
            enemyAtt.TakeDamage(attack);
            _playerAttack.Play(0);
        }
    }
}

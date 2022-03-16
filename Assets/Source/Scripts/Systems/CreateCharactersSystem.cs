using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Kuhpik;
using Kuhpik.Pooling;
using UnityEngine;

public class CreateCharactersSystem : GameSystem, IIniting
{
    private CharactersSetup _charactersSetup;
    
    public void OnInit()
    {
        CreateAllies();
        CreateEnemies();
    }

    private void CreateAllies()
    {
        for (int i = 0; i < game.AllyPosComponents.Count; i++)
        {
            var characterData = _charactersSetup.GetAlliesList()[i]; //Достали инфу персонажа
            var ally = Instantiate(characterData.CharacterPrefab, game.AllyPosComponents[i].transform);//Создаем персонажа на сцене
            var characterComponent = ally.GetComponent<CharacterComponent>(); //Находим CharacterComponent
            characterComponent.healthBarComponent = characterComponent.GetComponentInChildren<HealthBarComponent>(); // Находим HealthBar пеерсонажа
            characterComponent.healthBarComponent.SetHealthBarMaxValue(characterData.MaxHealth); // Cтавим HealthBar максимальное значение
            characterComponent.baseInitiative = characterData.BaseInitiative; //Задаем базовую инициативу персонажу из characterData
            characterComponent.baseHealth = characterData.BaseHealth; //Задаем базовое здоровье персонажу из characterData
            characterComponent.currentHealth = characterData.MaxHealth; //Задаем максимальное здоровье персонажу из characterData
            characterComponent.isAlly = true; //Задаем тег союзника
            characterComponent.abilities = characterComponent.gameObject.GetComponents<Ability>().ToList();
            game.AllCharactersComponents.Add(characterComponent); //Добавляем компонент в список всех персонажей на поле боя
            game.AllyCharacters.Add(characterComponent); //Добавляем компонент в список союзников на поле боя
        }
    }

    private void CreateEnemies()
    {
        for (int i = 0; i < game.EnemyPosComponents.Count; i++)
        {
            var characterData = _charactersSetup.GetEnemiesList()[i];
            var enemy = Instantiate(characterData.CharacterPrefab, game.EnemyPosComponents[i].transform);
            var characterComponent = enemy.GetComponent<CharacterComponent>();
            characterComponent.healthBarComponent = characterComponent.GetComponentInChildren<HealthBarComponent>();
            characterComponent.healthBarComponent.SetHealthBarMaxValue(characterData.MaxHealth);
            characterComponent.baseInitiative = characterData.BaseInitiative;
            characterComponent.baseHealth = characterData.BaseHealth;
            characterComponent.currentHealth = characterData.MaxHealth;
            characterComponent.isAlly = false;
            game.AllCharactersComponents.Add(characterComponent);
            game.EnemyCharacters.Add(characterComponent);
        }
    }
}

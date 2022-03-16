using System.Collections;
using System.Collections.Generic;
using Kuhpik;
using NaughtyAttributes;
using UnityEngine;

public class CreateBattleEnvironmentSystem : GameSystem, IIniting
{
    [SerializeField] [BoxGroup("Background")] private GameObject battleEnvironment;
    [SerializeField] [BoxGroup("Positions")] private AllyPosComponent allyPosComponent;
    [SerializeField] [BoxGroup("Positions")] private EnemyPosComponent enemyPosComponent;
    [SerializeField] [BoxGroup("Positions")] private float offsetX;
    [SerializeField] [BoxGroup("Positions")] private float posY;

    private CharactersSetup _charactersSetup;
    
    public void OnInit()
    {
        CreateEnvironment();
        CreateAlliesPositions();
        CreateEnemyPositions();
    }

    private void CreateEnvironment()
    {
        var background = Instantiate(battleEnvironment);
        background.transform.position = Vector3.zero;
    }

    private void CreateAlliesPositions()
    {
        float currentOffsetX = -offsetX;
        
        for (int i = 0; i < _charactersSetup.GetAlliesList().Count; i++)
        {
            var allyPos = Instantiate(allyPosComponent, new Vector3(currentOffsetX, posY, 0), Quaternion.identity);
            allyPos.index = i;
            game.AllyPosComponents.Add(allyPos);
            
            currentOffsetX -= offsetX;
        }
    }
    
    private void CreateEnemyPositions()
    {
        float currentOffsetX = offsetX;
        
        for (int i = 0; i < _charactersSetup.GetEnemiesList().Count; i++)
        {
            var enemyPos = Instantiate(enemyPosComponent, new Vector3(currentOffsetX, posY, 0), Quaternion.identity);
            game.EnemyPosComponents.Add(enemyPos);

            currentOffsetX += offsetX;
        }
    }
}

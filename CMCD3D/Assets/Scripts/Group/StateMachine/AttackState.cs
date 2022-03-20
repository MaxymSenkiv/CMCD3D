namespace CMC3D
{
    public class AttackState : State
    {
        private PlayerUnitsController _playerUnitsController;

        private void Awake()
        {
            _playerUnitsController = GetComponent<PlayerUnitsController>();
        }

        private void Update()
        {
            foreach (var unit in _playerUnitsController.UnitsGroup)
            {
                unit.GetComponent<UnitAttack>().Attack(_playerUnitsController.Opponent.AverageUnitsPosition);
            }
        }
    }
}

using VOD.Film.Common.Enums;

namespace VOD.Film.Common.ViewModels
{
    public class EntitySelectionViewModel
    {
        private Entity _selectedEntity;

        public Entity SelectedEntity
        {
            get => _selectedEntity;
            set => _selectedEntity = value;
        }
        public IEnumerable<Entity> AvailableEntities => Enum.GetValues(typeof(Entity)).Cast<Entity>();
    }
}

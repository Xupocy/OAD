namespace CharacterSelect.Domain.Character
{
    public class Paladyn : CharacterEntity
    {
        public Paladyn(string name) : base(name)
        {
            Sila = 15;
            Inteligencja = 5;
        }
    }
}
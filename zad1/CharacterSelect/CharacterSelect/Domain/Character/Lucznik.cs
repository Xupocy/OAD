namespace CharacterSelect.Domain.Character
{
    public class Lucznik : CharacterEntity
    {
        public Lucznik(string name) : base(name)
        {
            Sila = 12;
            Inteligencja = 8;
        }
    }
}
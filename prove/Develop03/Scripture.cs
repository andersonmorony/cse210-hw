namespace Develop03
{
    public class Scripture
    {
        private Reference _reference;
        private Phase _phase;

        public Scripture()
        {
            _reference = new Reference("Ether",12, 27);
            _phase = new Phase("And if men come unto me I will show unto them their aweakness. I bgive unto men weakness that they may be humble; and my cgrace is sufficient for all men that dhumble themselves before me; for if they humble themselves before me, and have faith in me, then will I make eweak things become strong unto them.");
        }
        public Scripture(Phase phase)
        {
            _phase = phase;
            _reference = new Reference();
        }
        public Scripture(Reference reference, Phase phase)
        {
            _reference = reference;
            _phase = phase;
        }

        public Reference GetReference()
        {
            return _reference;
        }
        public void SetReference(Reference reference)
        {
            _reference = reference;
        }
        public Phase GetPhase()
        {
            return _phase;
        }
        public void SetPhase(Phase phase)
        {
            _phase = phase;
        }

        public void DisplayScripture()
        {
            string referenceAsText = _reference.GetReferenceAsText();
            string word = _phase.HideWords();

            Console.WriteLine($"{referenceAsText} {word}");
        }

    }
}

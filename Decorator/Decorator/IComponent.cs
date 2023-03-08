namespace Decorator
{
    internal interface IComponent
    {
        decimal Preis { get; }
        string Beschreibung { get; }
    }

    internal class Pizza : IComponent
    {
        public decimal Preis => 5.2m;

        public string Beschreibung => "Pizza";
    }

    internal class Brot : IComponent
    {
        public decimal Preis => 3.5m;

        public string Beschreibung => "Brot";
    }

    internal abstract class Decorator : IComponent
    {
        protected readonly IComponent _parent;

        protected Decorator(IComponent parent)
        {
            _parent = parent;
        }

        public abstract decimal Preis { get; }
        public abstract string Beschreibung { get; }
    }

    internal class Salami : Decorator
    {
        internal Salami(IComponent parent) : base(parent)
        { }
        public override decimal Preis => _parent.Preis + 2.3m;

        public override string Beschreibung => _parent.Beschreibung + " Salami";
    }

    internal class Käse : Decorator
    {
        internal Käse(IComponent parent) : base(parent)
        { }
        public override decimal Preis => _parent.Preis + 1.8m;

        public override string Beschreibung => _parent.Beschreibung + " Käse";
    }
}

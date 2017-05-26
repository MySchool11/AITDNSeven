namespace AITDNSeven
{
    internal class ArbitraryClass
    {
        private string _name;
        public NameChangeHandlerDelegate NameChanges;

        public ArbitraryClass()
        {
            _name = "Unset";  // Constructor to set _name value when an instance of the class is instantiated.
        }

        public string Name
        {
            get => _name; // This is another way of saying get { return _name }

            set
            {
                if (_name != value) // Check to see if the _name value is about to change from its original value, two fold argument here, if you need verbose logging, you may wish to know a change has been made even if the new value is the same as the old, then you would not do this, you would run the delegate anyway. Here we do not care so only run the delegate when the new value is different.
                {
                    NameChanges(_name, value); // pass the old and new names to the delegate.
                }

                _name = value; // set the private sting _name to the passed value.
            }
        }
    }
}

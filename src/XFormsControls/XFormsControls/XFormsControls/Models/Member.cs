namespace XFormsControls.Models
{
    class Member
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return string.Concat(FirstName, ' ', LastName);
        }
    }
}

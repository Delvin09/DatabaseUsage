class Customer_Ado
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }

    public DateTime CreationDate { get; set; }

    public override string ToString()
    {
        return $"{Id}, Name: {Name}, Age: {Age}, Create: {CreationDate}";
    }
}
